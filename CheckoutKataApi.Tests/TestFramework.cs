using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CheckoutKataApi.Tests
{
    [TestFixture]
    public class TestFramework
    {
        [Test]
        public void Get_ok_response_from_http_request()
        {
            var webRequest = WebRequest.Create("http://checkout-kata-api.local/");
            var htmlRequest = (HttpWebResponse) webRequest.GetResponse();
            Assert.That(htmlRequest.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
