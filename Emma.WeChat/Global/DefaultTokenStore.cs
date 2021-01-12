using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Global
{
    internal class DefaultTokenStore : ITokenStore
    {
        private static Dictionary<string, WeChatToken> tokens = new Dictionary<string, WeChatToken>();
        public Task<WeChatToken> GetTokenAsync(AppConfig config)
        {
            tokens.TryGetValue(config.AppId, out var token);
            return Task.FromResult(token);
        }

        public Task SaveTokenAsync(AppConfig config, WeChatToken token)
        {
            tokens[config.AppId] = token;
            return Task.CompletedTask;
        }
    }
}
