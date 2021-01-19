using Emma.WeChat;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Messages.ReplyMessages;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Emma.WeChat.Test
{
    public class NotifyMessageTests
    {

        [Test]
        public async Task NotifyMessageHandlerTest()
        {
            ReplyMessage msg = new ReplyImageMessage()
            {
                ToUserName = "sfsd",
                FromUserName = "sdfsf",
                Image = new Image()
                {
                     MediaId = "123123131"
                }
            };

            var doc = msg.ToXml(msg);
            var inner = doc.InnerXml;
        }



    }
}