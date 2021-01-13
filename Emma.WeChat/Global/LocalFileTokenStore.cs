using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Global
{
    internal class LocalFileTokenStore : ITokenStore
    {
        private const string TOKN_FILE = "token.txt";
        public Task<WeChatToken> GetTokenAsync(AppConfig config)
        {
            if (File.Exists(TOKN_FILE))
            {
                var text = File.ReadAllText(TOKN_FILE);
                if (!string.IsNullOrEmpty(text))
                {
                    var splits = text.Split(',');
                    var token = splits[1];
                    var time = Convert.ToDateTime(splits[0]);
                    if (time < DateTime.Now)
                    {
                        return null;
                    }
                    return Task.FromResult(new WeChatToken()
                    {
                        access_token = token
                    });
                }
            }
            return Task.FromResult<WeChatToken>(null);
        }

        public Task SaveTokenAsync(AppConfig config, WeChatToken token)
        {
            var expireTime = DateTime.Now.AddSeconds(token.expires_in);
            var text = $"{expireTime},{token.access_token}";
            File.WriteAllText(TOKN_FILE, text);
            return Task.CompletedTask;
        }
    }
}
