using Emma.WeChat.Global;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public static class WebHostBuilderExtension
    {
        /// <summary>
        /// Web 主机注入
        /// </summary>
        /// <param name="hostBuilder">Web主机构建器</param>
        /// <param name="assemblyName">外部程序集名称</param>
        /// <returns>IWebHostBuilder</returns>
        public static IWebHostBuilder UseWeChat(this IWebHostBuilder hostBuilder)
        {
            hostBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, WeChatDefaults.AssemblyName);
            return hostBuilder;
        }
    }
}
