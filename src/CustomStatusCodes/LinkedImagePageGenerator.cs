using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;

namespace CustomStatusCodes
{
    internal class LinkedImagePageGenerator
    {
        private IDictionary<int, string> _links;

        public LinkedImagePageGenerator(IDictionary<int, string> links)
        {
            _links = links;
        }

        public Task GenerateAsync(HttpContext context)
        {
            string link;
            if (_links.TryGetValue(context.Response.StatusCode, out link))
            {
                return SendImageLink(context, link);
            }
            return Task.FromResult(0); // TODO: Fallback?
        }

        private Task SendImageLink(HttpContext context, string link)
        {
            context.Response.Body = context.GetFeature<BackupStreamFeature>().Body;
            context.Response.ContentType = "text/html";
            string body = string.Format("<html><body><img src=\"{0}\" /></body></html>",
                WebUtility.HtmlEncode(link));
            body += new string(' ', 512); // Padding to bypass IE's friendly error pages.
            context.Response.ContentLength = body.Length;
            return context.Response.WriteAsync(body);
        }
    }
}