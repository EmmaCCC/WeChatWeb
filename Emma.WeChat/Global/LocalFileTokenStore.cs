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
        public async Task<WeChatToken> GetTokenAsync(AppConfig config)
        {
            var file = $"{config.AppName}_{config.AppId}_{TOKN_FILE}";
            if (File.Exists(file))
            {
                var text = File.ReadAllText(TOKN_FILE);
                if (!string.IsNullOrEmpty(text))
                {
                    var splits = text.Split(',');

                    var time = Convert.ToDateTime(splits[0]);
                    if (time < DateTime.Now)
                    {
                        return null;
                    }
                    var token = splits[1];
                    var expire = int.Parse(splits[2]);
                    return new WeChatToken()
                    {
                        access_token = token,
                        expires_in = expire
                    };
                }
            }
            await Task.CompletedTask;
            return null;
        }

        public Task SaveTokenAsync(AppConfig config, WeChatToken token)
        {
            var expireTime = DateTime.Now.AddSeconds(token.expires_in);
            var text = $"{expireTime},{token.access_token},{token.expires_in}";
            var file = $"{config.AppName}_{config.AppId}_{TOKN_FILE}";
            File.WriteAllText(file, text);
            return Task.CompletedTask;
        }
    }
}
