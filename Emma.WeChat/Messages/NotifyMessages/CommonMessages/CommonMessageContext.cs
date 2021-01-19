using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.CommonMessages
{
    public class CommonMessageContext : NotifyMessageContext
    {
        public WeChatNotifyMessage Message { get; set; }

        public string MsgType { get; set; }
    }
}
