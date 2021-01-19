using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class EventMessageContext : NotifyMessageContext
    {
        public WeChatNotifyMessage Message { get; set; }

        public string Event { get; set; }
    }
}
