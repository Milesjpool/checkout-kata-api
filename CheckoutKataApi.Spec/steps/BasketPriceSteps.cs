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
        private readonly BasketProcessing _basketProcessing = new BasketProcessing();

        [Given(@"I have an empty basket")]
        public void GivenIHaveAnEmptyBasket()
        {
            _basketUri = _basketProcessing.CreateBasket("");
        }

        [When(@"I check the price of my basket")]
        public void WhenICheckThePriceOfMyBasket()
        {
            _basketProcessing.GetBasketResponse(_basketUri);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int expectedPrice)
        {
            _basketProcessing.AssertPriceIsCorrect(expectedPrice);
        }
    }
}
