using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CheckoutKataApi.WebApp
{
    public class HttpHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.OK;
        }

        public bool IsReusable { get; private set; }
    }
}