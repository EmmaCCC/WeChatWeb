﻿using Emma.WeChat.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Emma.WeChat
{
    public class AppConfig
    {
        [Required]
        public string AppName { get; set; }
        [Required]
        public string AppId { get; set; }
        [Required]
        public string AppSecret { get; set; }
        public string Url { get; set; }
        public string Token { get; set; }
        public string EncodingAESKey { get; set; }
    }
    public class WeChatOptions
    {
        public bool ThrowExceptionIfError { get; set; }

        public List<AppConfig> AppConfigs { get; set; } = new List<AppConfig>();
    }

}
