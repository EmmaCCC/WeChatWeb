using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public class WeChatNotifyMessage
    {
        public string MsgType { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }

        public static WeChatNotifyMessage FromXml(string body,Type type)
        {
            XmlSerializer serializer = new XmlSerializer(type, new XmlRootAttribute("xml"));
            var message = (WeChatNotifyMessage)serializer.Deserialize(new StringReader(body));
            return message;
        }
    }


}
