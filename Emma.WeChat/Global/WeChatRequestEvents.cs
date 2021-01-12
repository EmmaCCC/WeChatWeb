using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Global
{
    public class WeChatRequestEvents
    {
        public virtual Task OnRequestExecuting(WeChatRequestExecutingContext context)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnRequestExecuted(WeChatRequestExecutedContext context)
        {
            return Task.CompletedTask;
        }


    }

    public class WeChatRequestExecutingContext
    {
        public WeChatRequestData RequestData { get; set; }

        public string Url { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public TokenManager Manager { get; set; }
    }

    public class WeChatRequestExecutedContext: WeChatRequestExecutingContext
    {

        public WeChatResponseResult ResponseResult { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }
    }

}