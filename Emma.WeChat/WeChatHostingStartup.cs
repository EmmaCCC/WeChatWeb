using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    public class WeChatHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
           
            builder.Configure(app =>
            {
            

            });
        }
    }
}
