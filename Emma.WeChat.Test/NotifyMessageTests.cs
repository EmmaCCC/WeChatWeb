using Emma.WeChat;
using Emma.WeChat.Extensions;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Messages.ReplyMessages;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emma.WeChat.Test
{
    public class NotifyMessageTests
    {

        [Test]
        public async Task NotifyMessageHandlerTest()
        {
            var msg = new ReplyPicTextMessage()
            {
                ToUserName = "sfsd",
                FromUserName = "sdfsf",
                CreateTime = "123",
                ArticleCount = 1,
                Articles = new List<Article>()
                {
                    new Article(){ Description = "xxxx"}
                }

            };

            //var doc = msg.ToXml();
            var str = msg.CreateXml();
            var s = str.ToString(SaveOptions.DisableFormatting);
            //var inner = doc.InnerXml;
        }



    }
}