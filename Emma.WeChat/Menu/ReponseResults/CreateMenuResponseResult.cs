using Emma.WeChat.Menu.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Menu.ReponseResults
{
    public class CreateMenuResponseResult : WeChatResponseResult
    {
        public List<Button> button { get; set; }
    }
}
