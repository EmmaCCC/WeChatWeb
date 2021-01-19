using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public class NotifyMessageContext
    {
        public HttpContext HttpContext { get; set; }
        public WeChatOptions WeChatOptions { get; set; }
        public string Body { get; set; }
    }
}
