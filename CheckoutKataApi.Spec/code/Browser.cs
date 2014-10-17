using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace CheckoutKataApi.Spec.code
{
    public class Browser
    {
        private HttpWebResponse _webResponse ;
        public string ResponseBody { get; private set; }

        public void Get(Uri requestUri)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "GET";
            LogRequest(webRequest);

            _webResponse = (HttpWebResponse)webRequest.GetResponse();
            ReadResponseStream(_webResponse);
            LogResponse();
        }

        public void Post(Uri requestUri, string body)
        {
            var webRequest = WebRequest.Create(requestUri);
            webRequest.Method = "POST";
            WriteRequestStream(webRequest, body);
            LogRequest(webRequest, body);

            _webResponse = (HttpWebResponse)webRequest.GetResponse();
            ReadResponseStream(_webResponse);
            LogResponse();
        }

        private static void WriteRequestStream(WebRequest webRequest, string body)
        {
            webRequest.ContentLength = body.Length;
            using (var requestStream = webRequest.GetRequestStream())
            {
                using (var streamWriter = new StreamWriter(requestStream))
                {
                    streamWriter.Write(body);
                }
            }
        }

        private void ReadResponseStream(WebResponse webResponse)
        {
            using (var responseStream = webResponse.GetResponseStream())
            {
                Assert.IsNotNull(responseStream, "responseStream");
                using (var streamReader = new StreamReader(responseStream))
                {
                    ResponseBody = streamReader.ReadToEnd();
                }
            }
        }

        public Uri GetLocationUri()
        {
            return new Uri(_webResponse.GetResponseHeader("Location"));
        }

        public void AssertStatusCodeIs(HttpStatusCode statusCode)
        {
            Assert.That(_webResponse.StatusCode, Is.EqualTo(statusCode));
        }

        private void LogRequest(WebRequest webRequest, string body = null)
        {
            Console.WriteLine("---Request---\nMethod: {0}\nUri: {1}\n{2}",
                              webRequest.Method, webRequest.RequestUri, TrimNewlines(webRequest.Headers));

            if (body != null)
                Console.WriteLine("Request body: {0}", body);
        }

        private void LogResponse()
        {
            Console.WriteLine("\n---Response---\nStatusCode: {0} \n{1}\nResponse body: {2}\n",
                              _webResponse.StatusCode, TrimNewlines(_webResponse.Headers), ResponseBody);
        }

        private string TrimNewlines(WebHeaderCollection headers)
        {
            var newlines = new Regex("[\r\n]+$");
            return newlines.Replace(headers.ToString(), "");
        }
    }
}