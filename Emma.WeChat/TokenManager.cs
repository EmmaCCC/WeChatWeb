﻿using Emma.WeChat.Utils;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    public class TokenManager
    {
        public WeChatHttpClient httpClient { get; protected set; }
        public WeChatToken Token { get; protected set; }
        public AppConfig Config { get; protected set; }

        private const string URL = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        private readonly WeChatOptions options;

        public TokenManager(WeChatHttpClient httpClient, IOptions<WeChatOptions> options)
        {
            this.httpClient = httpClient;
            this.Config = options.Value.AppConfig;
            this.options = options.Value;
            this.GetTokenAsync().Wait();
        }

        private async Task GetTokenAsync()
        {
            var token = await options.TokenStore.GetTokenAsync(Config);
            if (token == null)
            {
                var url = string.Format(URL, Config.AppId, Config.AppSecret);
                var result = await httpClient.GetAsync<WeChatTokenReponseResult>(url);
                token = new WeChatToken()
                {
                    access_token = result.access_token,
                    expires_in = result.expires_in
                };
             
                await options.TokenStore.SaveTokenAsync(Config, token);
            }
            this.Token = token;
        }
        public void ReSetAppConfig(AppConfig config)
        {
            this.Config = config;
            this.GetTokenAsync().Wait();
        }
    }

    public class WeChatManager
    {
        protected readonly TokenManager tokenManager;
        protected readonly WeChatHttpClient httpClient;

        public WeChatManager(TokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
            this.httpClient = tokenManager.httpClient;
            this.httpClient.SetManager(tokenManager);
        }

        public void ReSetAppConfig(AppConfig config)
        {
            this.tokenManager.ReSetAppConfig(config);
        }
    }

    public class WeChatTokenReponseResult : WeChatResponseResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }

    public class WeChatToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}
