
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace CustomStatusCodes
{
    public class StatusCodePage
    {
        private CustomStatusCodesOptions statusCodeOptions;
        private RequestDelegate next;

        // Note you may need to disable friendly error pages in IE to see some of the 4xx and 5xx results
        public StatusCodePage(RequestDelegate next, CustomStatusCodesOptions statusCodeOptions)
        {
            this.next = next;
            this.statusCodeOptions = statusCodeOptions;
        }

        // Returns any status code given in the query, e.g. ?status=200, or links to some status codes.
        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path != new PathString("/"))
            {
                return next(context);
            }
            string status = context.Request.Query["status"];
            int statusCode;
            if (!string.IsNullOrEmpty(status) && int.TryParse(status, out statusCode))
            {
                context.Response.StatusCode = statusCode;
                return Task.FromResult(0);
            }

            context.Response.ContentType = "text/html";
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<html><body>");
            builder.AppendLine("Images courtesy of <a href=\"http://www.flickr.com/photos/girliemac/sets/72157628409467125\">HttpStatusCats</a>.<br>");
            foreach (var statusPair in statusCodeOptions.StatusCodeActions)
            {
                if (statusPair.Value != StatusCodeAction.Ignore)
                {
                    builder.AppendFormat("<a href=\"?status={0}\">{0} - {1}</a><br>\r\n",
                        statusPair.Key, (HttpStatusCode)statusPair.Key);
                }
            }
            builder.AppendLine("</body></html>");

            return context.Response.WriteAsync(builder.ToString());
        }
    }
}