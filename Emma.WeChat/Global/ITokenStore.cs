using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Global
{
    public interface ITokenStore
    {
        Task SaveTokenAsync(AppConfig config, WeChatToken token);
        Task<WeChatToken> GetTokenAsync(AppConfig config);
    }
}
