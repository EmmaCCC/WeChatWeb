using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.Hosting;
using WeChatWeb;

namespace GwlUrm.Test
{
    public class ServiceProviderInitializer
    {
        public static IServiceProvider Init()
        {
            var builder = Program.CreateHostBuilder(null)
                .UseDefaultServiceProvider(opts =>
                {
                    opts.ValidateScopes = false;
                })
                .Build();
            return builder.Services;
        }
    }
}
