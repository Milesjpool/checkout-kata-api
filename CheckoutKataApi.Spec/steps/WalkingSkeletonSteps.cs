using System;
using System.Net;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CheckoutKataApi.Spec.steps
{
    [Binding]
    public class WalkingSkeletonSteps
    {
        private HttpWebResponse _htmlResponse;

        [When(@"I make a generic request to the API")]
        public void WhenIMakeAGenericRequestToTheApi()
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/");
            _htmlResponse = (HttpWebResponse)webRequest.GetResponse();
        }

        [Then(@"the API should respond with an OK status code")]
        public void ThenTheApiShouldRespondWithAnOkStatusCode()
        {
            Assert.That(_htmlResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
