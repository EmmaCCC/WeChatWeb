using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Emma.WeChat.Extensions
{
    public static class HttpResponseExtension
    {
        public static void WriteXmlAsync(this HttpResponse response, XElement doc)
        {
            if (doc != null)
            {
                response.ContentType = "application/xml";
                response.WriteAsync(doc.ToString(SaveOptions.DisableFormatting));
            }
        }
    }
}
