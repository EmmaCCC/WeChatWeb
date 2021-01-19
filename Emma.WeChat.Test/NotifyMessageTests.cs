using Emma.WeChat;
using Emma.WeChat.Messages.NotifyMessages;
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
            NotifyMessageHandler handler = new NotifyMessageHandler();
            await handler.HandleMessage(new NotifyMessageContext()
            {
                Body = $@"<xml>
                          <ToUserName><![CDATA[toUser]]></ToUserName>
                          <FromUserName><![CDATA[fromUser]]></FromUserName>
                          <CreateTime>1348831860</CreateTime>
                          <MsgType><![CDATA[text]]></MsgType>
                          <Content><![CDATA[this is a test]]></Content>
                          <MsgId>1234567890123456</MsgId>
                        </xml>"
            });
        }



    }
}