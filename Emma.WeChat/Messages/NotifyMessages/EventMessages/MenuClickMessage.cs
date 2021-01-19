using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.EventMessages
{
    public class MenuClickMessage : EventMessage
    {
        public string EventKey { get; set; }
    }
}
