using Emma.WeChat.Global;
using Emma.WeChat.Messages.NotifyMessages;
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
        public static void AddWeChatServices(this IServiceCollection services, Action<WeChatOptions> opts)
        {
            services.Configure(opts);

            services.AddSingleton<IMessageNotifier, DefaultMessageNotifier>();
            services.AddSingleton<NotifyMessageHandler>();
            services.AddTransient<TokenManager>();
            services.AddTransient<TemplateMessageManager>();
            services.AddHttpClient<WeChatHttpClient>();
        }

        public static void AddWeChatServices(this IServiceCollection services, string appId, string secret)
        {
            AddWeChatServices(services, opts =>
            {
                opts.Events = new WeChatRequestEvents();
                opts.TokenStore = new LocalFileTokenStore();
                opts.AppConfig = new AppConfig() { AppId = appId, AppSecret = secret };
            });

        }
    }
}
