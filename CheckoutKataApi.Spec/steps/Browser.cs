using System;
using System.IO;
using System.Net;
using NUnit.Framework;

namespace CheckoutKataApi.Spec.steps
{
    public class Browser
    {
        private HttpWebResponse _webResponse ;

        public void Get(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "GET";
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }

        public void Post(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            webRequest.ContentLength = 0;
            _webResponse = (HttpWebResponse) webRequest.GetResponse();
        }

        public void AssertStatusCodeIs(HttpStatusCode statusCode)
        {
            Assert.That(_webResponse.StatusCode, Is.EqualTo(statusCode));
        }

        public Uri GetLocationUri()
        {
            return new Uri(_webResponse.GetResponseHeader("Location"));
        }

        public string GetResponseBody()
        {
            using (var responseStream = _webResponse.GetResponseStream())
            {
                Assert.IsNotNull(responseStream, "responseStream");
                using (var streamReader = new StreamReader(responseStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}