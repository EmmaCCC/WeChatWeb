using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public class DefaultMessageNotifier : IMessageNotifier
    {
        public Task OnCommonMessage(CommonMessageContext context)
        {
            var msg = JsonSerializer.Serialize(context.Message, context.Message.GetType());
            context.HttpContext.Response.WriteAsync(msg);
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
