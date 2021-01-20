using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Global
{
    public interface IWeChatRequestFilter
    {
        Task OnRequestExecuting(WeChatRequestExecutingContext context);

        Task OnRequestExecuted(WeChatRequestExecutedContext context);
    }
}
