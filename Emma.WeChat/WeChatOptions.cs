using Emma.WeChat.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public class AppConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
    public class WeChatOptions
    {
        public bool ThrowExceptionIfError { get; set; }
        public WeChatRequestFilter Filter { get; set; }
        public AppConfig AppConfig { get; set; }
        public string NotifyUrl { get; set; }
    }

}
