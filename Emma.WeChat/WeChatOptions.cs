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
        public string Url { get; set; }
        public string Token { get; set; }
        public string EncodingAESKey { get; set; }
    }
    public class WeChatOptions
    {
        public bool ThrowExceptionIfError { get; set; }
        public AppConfig AppConfig { get; set; }
    }

}
