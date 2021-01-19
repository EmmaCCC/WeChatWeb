using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public interface IMessageNotifier
    {
        Task OnCommonMessage(CommonMessageContext context);

        Task OnEventMessage(EventMessageContext context);
    }
}
