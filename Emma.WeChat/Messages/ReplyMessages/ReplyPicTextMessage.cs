using Emma.WeChat.Messages.NotifyMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.ReplyMessages
{
    public class ReplyPicTextMessage : ReplyMessage
    {
        public ReplyPicTextMessage()
        {
            this.MsgType = ReplyMsgTypes.News;
        }

        public int ArticleCount { get; set; }
        public List<Article> Articles { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }
}
