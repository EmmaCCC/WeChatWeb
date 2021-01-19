using Emma.WeChat.Messages.NotifyMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyImageMessage : ReplyMessage
    {
        public ReplyImageMessage()
        {
            this.MsgType = MsgTypes.Image;
        }

        public Image Image { get; set; }
    }

    public class Image
    {
        public string MediaId { get; set; }
    }


}
