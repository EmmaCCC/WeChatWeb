using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Emma.WeChat
{
    public class WeChatNotifyMessage
    {
        public string MsgType { get; set; }
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public string CreateTime { get; set; }
        public string Content { get; set; }
        public string MsgId { get; set; }
    }

    
}
