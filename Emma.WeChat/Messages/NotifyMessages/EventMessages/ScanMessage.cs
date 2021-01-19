using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.EventMessages
{
    public class ScanMessage : EventMessage
    {
        public string EventKey { get; set; }
        public string Ticket { get; set; }
    }
}
