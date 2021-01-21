using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Global;
using Emma.WeChat.Validations;
using Microsoft.Extensions.Options;
using Emma.WeChat.Utils;
using System.Reflection;
using System.Linq;
using Emma.WeChat.Attributes;
using Microsoft.AspNetCore.Builder;

[assembly: HostingStartup(typeof(Emma.WeChat.WeChatHostingStartup))]

namespace Emma.WeChat
{
    internal class WeChatHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            IConfiguration configuration = null;
            // 自动装载配置
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                configuration = config.Build();
            });

            builder.ConfigureServices(services =>
            {
                services.AddTransient<IStartupFilter, WeChatStartupFilter>();
                services.Configure<WeChatOptions>(configuration.GetSection(nameof(WeChatOptions)));
                AddWeChatService(services);
            });
        }

        private void AddWeChatService(IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IValidateOptions
                           <WeChatOptions>, WeChatOptionsValidator>());

            RegisterApiManagers(services);

            services.AddSingleton<NotifyMessageHandler>();
            services.AddHttpClient<WeChatHttpClient>();

            services.AddSingleton<IMessageNotifier, DefaultMessageNotifier>();
            services.AddSingleton<ITokenStore, LocalFileTokenStore>();
            services.AddSingleton<IWeChatRequestFilter, WeChatRequestFilter>();
        }

        private  void RegisterApiManagers(IServiceCollection services)
        {
            var types = Assembly.Load(WeChatDefaults.AssemblyName).GetTypes()
                .Where(a => a.GetCustomAttribute(typeof(WeChatApiManagerAttribute)) != null).ToList();

            foreach (var type in types)
            {
                services.AddTransient(type);
            }
        }
    }


    internal class WeChatStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseWeChat();
                next(app);
            };
        }
    }
}
