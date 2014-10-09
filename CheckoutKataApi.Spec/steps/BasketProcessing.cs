using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using NUnit.Framework;

namespace CheckoutKataApi.Spec.steps
{
    public class BasketProcessing
    {
        private HttpWebResponse _webResponse;
        private readonly Browser _browser = new Browser();

        public Uri CreateBasket(string shoppingList)
        {
            _browser.Post(new Uri("http://checkout-kata-api.local/baskets/"));

            _browser.AssertStatusCodeIs(HttpStatusCode.Created);
            
            return _browser.GetLocationUri();
        }

        public void GetBasketResponse(Uri basketUri)
        {
            _browser.Get(basketUri);

            _browser.AssertStatusCodeIs(HttpStatusCode.OK);
        }

        public void AssertPriceIsCorrect(int expectedPrice)
        {
            var basket = GetBasketObject();

            Assert.That((object) basket.Price, Is.EqualTo(expectedPrice));
        }

        private Basket GetBasketObject()
        {
            var body = _browser.GetResponseBody();
            var basket = Deserialize(body);
            return basket;
        }

        private static Basket Deserialize(string body)
        {
            var seralizer = new JavaScriptSerializer();
            return seralizer.Deserialize<Basket>(body);
        }
    }
}