using Emma.WeChat.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeChatWeb
{
    public class MyWeChatRequestFilter : IWeChatRequestFilter
    {
        public Task OnRequestExecuted(WeChatRequestExecutedContext context)
        {
            return Task.CompletedTask;
        }

        public Task OnRequestExecuting(WeChatRequestExecutingContext context)
        {
            return Task.CompletedTask;
        }
    }
}
