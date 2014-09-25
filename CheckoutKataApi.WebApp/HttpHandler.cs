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
            var statusCode = HttpStatusCode.OK;
            context.Response.StatusCode = (int) statusCode;
        }

        public bool IsReusable { get; private set; }
    }
}