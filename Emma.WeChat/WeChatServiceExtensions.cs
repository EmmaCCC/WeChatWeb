using Emma.WeChat.Global;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public static class WeChatServiceExtensions
    {

        public static IWeChatServiceBuilder AddWeChat(this IServiceCollection services, Action<WeChatOptions> opts)
        {
            services.Configure(opts);

            services.PostConfigure<WeChatOptions>(opts =>
            {
                opts.Events = opts.Events ?? new WeChatRequestEvents();
            });

            services.AddSingleton<NotifyMessageHandler>();
            services.AddTransient<TokenManager>();
            services.AddTransient<TemplateMessageManager>();
            services.AddHttpClient<WeChatHttpClient>();

            services.AddSingleton<IMessageNotifier, DefaultMessageNotifier>();
            services.AddSingleton<ITokenStore, LocalFileTokenStore>();
            return new WeChatServiceBuilder(services);
        }

        public static IWeChatServiceBuilder AddWeChat(this IServiceCollection services, string appId, string secret)
        {
            return AddWeChat(services, opts =>
            {
                opts.Events = new WeChatRequestEvents();
                opts.AppConfig = new AppConfig() { AppId = appId, AppSecret = secret };
            });

        }

        public static IWeChatServiceBuilder AddTokenStore<T>(this IWeChatServiceBuilder builder)
            where T : class, ITokenStore
        {
            builder.Services.Replace(ServiceDescriptor.Singleton<ITokenStore, T>());
            return builder;
        }

        public static IWeChatServiceBuilder AddMessageNotifier<T>(this IWeChatServiceBuilder builder)
            where T : class, IMessageNotifier
        {
            builder.Services.Replace(ServiceDescriptor.Singleton<IMessageNotifier, T>());
            return builder;
        }
    }
}
