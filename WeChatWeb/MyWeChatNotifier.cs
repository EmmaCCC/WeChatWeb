using Emma.WeChat.Extensions;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using Emma.WeChat.Messages.ReplyMessages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeChatWeb
{
    public class MyWeChatNotifier : IMessageNotifier
    {
        public Task OnCommonMessage(CommonMessageContext context)
        {
            var doc = new ReplyMessage()
            {
                CreateTime = "123",
                FromUserName = "sn",
                MsgType = "text",
                ToUserName = "ls"
            }.ToXml();
            context.HttpContext.Response.WriteXmlAsync(doc);
            return Task.CompletedTask;
        }

        public Task OnEventMessage(EventMessageContext context)
        {
            var msg = JsonSerializer.Serialize(context.Message);
            context.HttpContext.Response.WriteAsync(msg);
            return Task.CompletedTask;
        }
    }
}
