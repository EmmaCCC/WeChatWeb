using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.TemplateMessages.ResponseResults
{
    public class SendMessageResponseResult : WeChatResponseResult
    {
        public long msgid { get; set; }
    }
}
