using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.TemplateMessages.ResponseResults
{
    public class GetTemplateMessageListResponseResult : WeChatResponseResult
    {
        public List<TemplateItem> template_list { get; set; }
    }

    public class TemplateItem
    {
        public string template_id { get; set; }
        public string title { get; set; }
        public string primary_industry { get; set; }
        public string deputy_industry { get; set; }
        public string content { get; set; }
        public string example { get; set; }
    }

}
