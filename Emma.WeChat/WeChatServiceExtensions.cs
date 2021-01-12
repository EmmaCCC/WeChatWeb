using Emma.WeChat.Messages.TemplateMessages;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public static class WeChatServiceExtensions
    { 
        public static void AddWeChatServices(this IServiceCollection services)
        {
            services.AddSingleton<TokenManager>();
            services.AddSingleton<TemplateMessageManager>();
        }
    }
}
