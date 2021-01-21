using Emma.WeChat.Attributes;
using Emma.WeChat.Global;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Utils;
using Emma.WeChat.Validations;
using Microsoft.Extensions.Configuration;
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
        public static IWeChatServiceBuilder AddWeChat(this IServiceCollection services)
        {
            return new WeChatServiceBuilder(services);
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
