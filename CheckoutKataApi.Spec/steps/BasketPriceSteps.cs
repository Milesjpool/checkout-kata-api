using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Spec.steps
{
    [Binding]
    public class BasketPriceSteps
    {
        private Uri _basketUri;

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
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
