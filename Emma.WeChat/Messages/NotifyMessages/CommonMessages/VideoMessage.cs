using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class VideoMessage : CommonMessage
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
}
