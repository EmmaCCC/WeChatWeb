using Emma.WeChat.Messages.NotifyMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyTextMessage: ReplyMessage
    {
        public ReplyTextMessage()
        {
            this.MsgType = MsgTypes.Text;
        }
        public string Content { get; set; }
    }
}
