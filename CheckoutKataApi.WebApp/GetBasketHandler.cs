﻿using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace CheckoutKataApi.WebApp
{
    public class GetBasketHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var basketId = context.Request.RawUrl.Split('/').Last();
            var basket = BasketStore.Fetch(basketId);

            var seralizer = new JavaScriptSerializer();
            var responseBody = seralizer.Serialize(basket);

            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.Write(responseBody);
        }

        public bool IsReusable { get; private set; }
    }
}