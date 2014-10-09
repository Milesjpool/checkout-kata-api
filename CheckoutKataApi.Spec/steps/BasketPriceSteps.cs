using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Spec.steps
{
    [Binding]
    public class BasketPriceSteps
    {
        private Uri _basketUri;
        private HttpWebResponse _webResponse;

        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketUri = CreateBasket("");
        }

        private Uri CreateBasket(string shoppingList)
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/baskets/");
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            var webResponse = (HttpWebResponse) webRequest.GetResponse();

            Assert.That(webResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            
            return new Uri(webResponse.GetResponseHeader("Location"));
        }

        [When(@"I check the price of my basket")]
        public void WhenICheckThePriceOfMyBasket()
        {
            GetBasket();
        }

        private void GetBasket()
        {
            var webRequest = WebRequest.Create(_basketUri);
            webRequest.Method = "GET";
            _webResponse = (HttpWebResponse) webRequest.GetResponse();

            Assert.That(_webResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedPrice)
        {

            var responseStream = _webResponse.GetResponseStream();
            Assert.IsNotNull(responseStream, "responseStream");
            var streamReader = new StreamReader(responseStream);
            var body = streamReader.ReadToEnd();
            var seralizer = new JavaScriptSerializer();
            var basket = seralizer.Deserialize<Basket>(body);
            Assert.That(basket.Price, Is.EqualTo(expectedPrice));
        }
    }

    public class Basket
    {
        public int Price { get; set; }
    }
}
