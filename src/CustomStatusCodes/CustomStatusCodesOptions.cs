using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace CustomStatusCodes
{
    public class CustomStatusCodesOptions
    {
        private IDictionary<int, StatusCodeAction> statusCodeActions;

        public CustomStatusCodesOptions()
        {
            statusCodeActions = new Dictionary<int, StatusCodeAction>()
            {
                { 100, StatusCodeAction.Ignore },
                { 101, StatusCodeAction.Ignore },
                { 200, StatusCodeAction.FallbackOnly },
                { 201, StatusCodeAction.FallbackOnly },
                { 202, StatusCodeAction.FallbackOnly },
                { 204, StatusCodeAction.Ignore },
                { 206, StatusCodeAction.FallbackOnly },
                { 207, StatusCodeAction.FallbackOnly },
                { 300, StatusCodeAction.FallbackOnly },
                { 301, StatusCodeAction.Ignore },
                { 302, StatusCodeAction.Ignore },
                { 303, StatusCodeAction.Ignore },
                { 304, StatusCodeAction.FallbackOnly },
                { 305, StatusCodeAction.FallbackOnly },
                { 307, StatusCodeAction.Ignore },
                { 400, StatusCodeAction.FallbackOnly },
                { 401, StatusCodeAction.FallbackOnly },
                { 402, StatusCodeAction.FallbackOnly },
                { 403, StatusCodeAction.FallbackOnly },
                { 404, StatusCodeAction.ReplaceResponse },
                { 500, StatusCodeAction.FallbackOnly },
            };
        }

        public IDictionary<int, StatusCodeAction> StatusCodeActions
        {
            get { return statusCodeActions; }
        }

        public Func<HttpContext, Task> ResponseGenerator { get; set; }
    }
}