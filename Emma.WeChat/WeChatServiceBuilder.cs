using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public class WeChatServiceBuilder : IWeChatServiceBuilder
    {
        public WeChatServiceBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
        public IServiceCollection Services { get; }
    }
}
