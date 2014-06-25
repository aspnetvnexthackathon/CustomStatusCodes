using System;
using CustomStatusCodes;
using Microsoft.AspNet.Builder;

namespace StatusCodeSample
{
    public class Startup
    {
	    public void Configure(IBuilder app)
	    {
            app.UseKittenStatusCodes();
            // app.UsePuppyStatusCodes();
            // app.UseCustomStatusCodes(context => context.Response.WriteAsync(context.Response.StatusCode.ToString()));


            app.Use(next => new StatusCodePage(next, new CustomStatusCodesOptions()).Invoke);
            app.Run(context =>
            {
                context.Response.StatusCode = 404;
                return context.Response.WriteAsync("Normal Not Found Page");
            });
	    }
    }
}