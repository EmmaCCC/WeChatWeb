using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public static class WeChatServiceExtensions
    {
        public static void AddWeChatServices(this IServiceCollection services, AppConfig config, WeChatOptions opts)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            if (opts == null) throw new ArgumentNullException(nameof(config));

            services.AddTransient<TokenManager>();
            services.AddTransient<TemplateMessageManager>();
            services.AddHttpClient<WeChatHttpClient>();

            services.AddSingleton(opts);
            services.AddSingleton(config);
        }

        public static void AddWeChatServices(this IServiceCollection services, AppConfig config)
        {
            AddWeChatServices(services, config, new WeChatOptions(){});
        }
    }
}
