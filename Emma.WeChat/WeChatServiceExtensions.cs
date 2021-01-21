using Emma.WeChat.Attributes;
using Emma.WeChat.Global;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Utils;
using Emma.WeChat.Validations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Reflection;

namespace Emma.WeChat
{
    public static class WeChatServiceExtensions
    {

        private static void RegisterApiManagers(IServiceCollection services)
        {
            var types = Assembly.Load("Emma.WeChat").GetTypes()
                .Where(a => a.GetCustomAttribute(typeof(WeChatApiManagerAttribute)) != null).ToList();

            foreach (var type in types)
            {
                services.AddTransient(type);
            }
        }

        public static IWeChatServiceBuilder AddWeChat(this IServiceCollection services, Action<WeChatOptions> opts)
        {
            services.Configure(opts);
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions
                             <WeChatOptions>, WeChatOptionsValidator>());

            RegisterApiManagers(services);

            services.AddSingleton<NotifyMessageHandler>();
            services.AddHttpClient<WeChatHttpClient>();

            services.AddSingleton<IMessageNotifier, DefaultMessageNotifier>();
            services.AddSingleton<ITokenStore, LocalFileTokenStore>();
            services.AddSingleton<IWeChatRequestFilter, WeChatRequestFilter>();
            return new WeChatServiceBuilder(services);
        }

        public static IWeChatServiceBuilder AddWeChat(this IServiceCollection services, string appId, string secret)
        {
            return AddWeChat(services, opts =>
            {
                opts.AppConfigs.Add(new AppConfig() { AppId = appId, AppSecret = secret });
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

        public static IWeChatServiceBuilder AddRequestFilter<T>(this IWeChatServiceBuilder builder)
        where T : class, IWeChatRequestFilter
        {
            builder.Services.Replace(ServiceDescriptor.Singleton<IWeChatRequestFilter, T>());
            return builder;
        }
    }
}
