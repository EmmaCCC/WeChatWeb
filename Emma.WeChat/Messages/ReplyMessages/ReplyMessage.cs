using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyMessage
    {
        public string MsgType { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }

        public XmlDocument ToXml()
        {
            XmlDocument doc = new XmlDocument();
            var xml = doc.CreateElement("xml");
            doc.AppendChild(xml);
            doc.AppendChild(CreateXml(doc.DocumentElement, this));
            return doc;
        }

        private XmlElement CreateXml(XmlElement doc, object o)
        {

            if (o != null)
            {
                var props = o.GetType().GetProperties();
                foreach (var item in props)
                {
                    var propType = item.PropertyType;
                    var propXml = doc.OwnerDocument.CreateElement(item.Name);
                    doc.AppendChild(propXml);
                    if (propType.IsClass && propType != typeof(string))
                    {
                        CreateXml(propXml, item.GetValue(o));
                    }
                    else
                    {
                        var cdata = doc.OwnerDocument.CreateCDataSection(item.GetValue(o)?.ToString());
                        propXml.AppendChild(cdata);
                        doc.AppendChild(propXml);
                    }
                }

            }
            return doc;
        }
    }
}
