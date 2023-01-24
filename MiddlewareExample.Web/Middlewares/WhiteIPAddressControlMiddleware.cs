using System;
using System.Net;

namespace MiddlewareExample.Web.Middlewares
{
	public class WhiteIPAddressControlMiddleware
	{
		private readonly RequestDelegate _requestDelegate;
        private const string WhiteIpAddress = "192.188.2.1";

        public WhiteIPAddressControlMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var reqIpAddress = context.Connection.RemoteIpAddress;

            bool anyWhiteIpAddress = IPAddress.Parse(WhiteIpAddress).Equals(reqIpAddress);

            if (anyWhiteIpAddress==true)
            {
                await _requestDelegate(context);
            }
            else
            {
                context.Response.StatusCode = HttpStatusCode.Forbidden.GetHashCode();
                await context.Response.WriteAsync("Forbidden");
            }
        }
    }
}

