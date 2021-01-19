using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class LinkMessage : CommonMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
