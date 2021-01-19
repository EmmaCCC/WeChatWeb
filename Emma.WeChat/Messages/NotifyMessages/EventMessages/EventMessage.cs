using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.EventMessages
{
    public class EventMessage : WeChatNotifyMessage
    {
        public string Event { get; set; }
    }
}
