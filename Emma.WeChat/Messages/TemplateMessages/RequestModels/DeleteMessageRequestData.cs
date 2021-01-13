using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.TemplateMessages.RequestModels
{
    public class DeleteMessageRequestData : WeChatRequestData
    {
        public string template_id { get; set; }
    
    }
}
