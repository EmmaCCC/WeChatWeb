using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyMusicMessage : ReplyMessage
    {
        public ReplyMusicMessage()
        {
            this.MsgType = ReplyMsgTypes.Music;
        }

        public Music Music { get; set; }
    }

    public class Music
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MusicUrl { get; set; }
        public string HQMusicUrl { get; set; }
        public string ThumbMediaId { get; set; }
    }
}
