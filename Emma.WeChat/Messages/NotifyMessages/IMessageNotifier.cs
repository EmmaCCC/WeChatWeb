using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using Emma.WeChat.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public interface IMessageNotifier
    {
        //默认实现
        async Task OnCheckMessage(CheckMessageContext context)
        {
            await WeChatCheck.CheckSign(context.AppConfig, context.HttpContext);
        }
        Task OnCommonMessage(CommonMessageContext context);
        Task OnEventMessage(EventMessageContext context);
    }
}
