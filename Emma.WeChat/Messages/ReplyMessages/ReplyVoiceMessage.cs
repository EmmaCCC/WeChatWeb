using Emma.WeChat.Messages.NotifyMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyVoiceMessage : ReplyMessage
    {
        public Voice Voice { get; set; }

        public ReplyVoiceMessage()
        {
            this.MsgType = MsgTypes.Voice;
        }
    }

    public class Voice
    {
        public string MediaId { get; set; }
    }
}
