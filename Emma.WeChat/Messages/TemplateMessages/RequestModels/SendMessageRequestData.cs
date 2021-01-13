using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.TemplateMessages.RequestModels
{
    public class SendMessageRequestData : WeChatRequestData
    {
        public string touser { get; set; }
        public string template_id { get; set; }
        public string url { get; set; }
        public Miniprogram miniprogram { get; set; }
        public object data { get; set; }
    }

    public class Miniprogram
    {
        public string appid { get; set; }
        public string pagepath { get; set; }
    }

}
