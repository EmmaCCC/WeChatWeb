using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public interface IWeChatServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
