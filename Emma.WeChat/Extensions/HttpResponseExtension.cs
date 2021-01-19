using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Emma.WeChat.Extensions
{
    public static class HttpResponseExtension
    {
        public static void WriteXmlAsync(this HttpResponse response, XmlDocument doc)
        {
            if (doc != null)
            {
                response.ContentType = "application/xml";
                response.WriteAsync(doc.InnerXml);
            }
        }
    }
}
