using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using NUnit.Framework;

namespace CheckoutKataApi.WebApp
{
    public class CreateBasketHandler : IHttpHandler
    {
        public bool IsReusable { get; private set; }

        private readonly IDictionary<string, int> _priceLookup = new Dictionary<string, int>
            {
                {"A", 50},
                {"B", 30},
                {"C", 20},
                {"D", 15}
            };

        public void ProcessRequest(HttpContext context)
        {
            var items = GetRequestBody(context);

            var basket = new Basket(items) {Price = Checkout(items)};
            var basketId = BasketStore.Add(basket);

            context.Response.StatusCode = (int) HttpStatusCode.Created;
            context.Response.RedirectLocation = ("http://checkout-kata-api.local/baskets/" + basketId);
        }

        private int Checkout(string items)
        {
            return items.Length == 1 ? _priceLookup[items] : 0;
        }

        private static string GetRequestBody(HttpContext context)
        {
            using (var requestStream = context.Request.InputStream)
            {
                Assert.IsNotNull(requestStream, "requestStream");
                using (var streamReader = new StreamReader(requestStream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}