using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class VoiceMessage : CommonMessage
    {
        public string MediaId { get; set; }
        public string Format { get; set; }
    }
}
