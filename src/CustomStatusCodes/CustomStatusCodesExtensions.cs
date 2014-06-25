using System;
using System.Threading.Tasks;
using CustomStatusCodes;
using Microsoft.AspNet.Http;

namespace Microsoft.AspNet.Builder
{
    public static class CustomStatusCodesExtensions
    {
        public static IBuilder UseKittenStatusCodes(this IBuilder app)
        {
            return app.UseCustomStatusCodes(new LinkedImagePageGenerator(KittenLinks.Create()).GenerateAsync);
        }

        public static IBuilder UseKittenStatusCodes(this IBuilder app, CustomStatusCodesOptions options)
        {
            if (options.ResponseGenerator == null)
            {
                options.ResponseGenerator = new LinkedImagePageGenerator(KittenLinks.Create()).GenerateAsync;
            }
            return app.UseCustomStatusCodes(options);
        }

        public static IBuilder UsePuppyStatusCodes(this IBuilder app)
        {
            return app.UseCustomStatusCodes(new LinkedImagePageGenerator(PuppyLinks.Create()).GenerateAsync);
        }

        public static IBuilder UsePuppyStatusCodes(this IBuilder app, CustomStatusCodesOptions options)
        {
            if (options.ResponseGenerator == null)
            {
                options.ResponseGenerator = new LinkedImagePageGenerator(PuppyLinks.Create()).GenerateAsync;
            }
            return app.UseCustomStatusCodes(options);
        }

        public static IBuilder UseCustomStatusCodes(this IBuilder app, Func<HttpContext, Task> responseGenerator)
        {
            return app.UseCustomStatusCodes(new CustomStatusCodesOptions() { ResponseGenerator = responseGenerator });
        }

        public static IBuilder UseCustomStatusCodes(this IBuilder app, CustomStatusCodesOptions options)
        {
            return app.Use(next => new CustomStatusCodesMiddleware(next, options).Invoke);
        }
    }
}