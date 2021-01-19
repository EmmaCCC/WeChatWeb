using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public interface IWeChatServiceBuilder
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        IServiceCollection Services { get; }
    }
}
