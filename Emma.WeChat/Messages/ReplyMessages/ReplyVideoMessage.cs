using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyVideoMessage : ReplyMessage
    {
        public ReplyVideoMessage()
        {
            this.MsgType = ReplyMsgTypes.Video;
        }
        public Video Video { get; set; }
    }

    public class Video
    {
        public string MediaId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
