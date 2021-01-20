using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyMessage
    {
        public string MsgType { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
    }
}
