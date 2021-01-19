using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class ImageMessage : CommonMessage
    {
        public string PicUrl { get; set; }

        public string MediaId { get; set; }
    }
}
