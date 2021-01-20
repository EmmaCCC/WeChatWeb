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

        public Task OnCommonMessage(CommonMessageContext context) => Task.CompletedTask;

        public Task OnEventMessage(EventMessageContext context) => Task.CompletedTask;

    }
}
