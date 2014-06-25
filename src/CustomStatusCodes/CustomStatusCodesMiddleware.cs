
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace CustomStatusCodes
{
    public class CustomStatusCodesMiddleware
    {
        private CustomStatusCodesOptions options;
        private RequestDelegate _next;

        public CustomStatusCodesMiddleware(RequestDelegate next, CustomStatusCodesOptions options)
        {
            this.options = options;
            _next = next;
            if (options.ResponseGenerator == null)
            {
                throw new ArgumentNullException("options.ResponseGenerator");
            }
        }

        public async Task Invoke(HttpContext context)
        {
            context.SetFeature<BackupStreamFeature>(new BackupStreamFeature() { Body = context.Response.Body });
            context.Response.Body = new StreamWrapper(context.Response.Body, InspectStatusCode, context);
            await _next.Invoke(context);
            
            StatusCodeAction action;
            int statusCode = context.Response.StatusCode;
            bool? replace = context.GetFeature<BackupStreamFeature>().Replace;
            if (!replace.HasValue)
            {
                // Never evaluated, no response sent yet.
                if (options.StatusCodeActions.TryGetValue(statusCode, out action)
                    && action != StatusCodeAction.Ignore)
                {
                    await options.ResponseGenerator(context);
                }
            }
            else if (replace.Value == true)
            {
                await options.ResponseGenerator(context);
            }
        }

        private bool InspectStatusCode(HttpContext context)
        {
            StatusCodeAction action;
            int statusCode = context.Response.StatusCode;
            if (options.StatusCodeActions.TryGetValue(statusCode, out action)
                && action == StatusCodeAction.ReplaceResponse)
            {
                context.GetFeature<BackupStreamFeature>().Replace = true;
                return action == StatusCodeAction.ReplaceResponse;
            }
            context.GetFeature<BackupStreamFeature>().Replace = false;
            return false;
        }
    }
}