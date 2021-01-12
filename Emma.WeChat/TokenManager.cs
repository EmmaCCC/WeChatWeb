using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    public class TokenManager
    {
        protected readonly IConfiguration configuration;
        protected readonly IHttpClientFactory httpClientFactory;
        protected readonly HttpClient httpClient;
        private const string URL = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        public TokenManager(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.httpClient = httpClientFactory.CreateClient();
        }

        public async Task<WeChatToken> GetTokenAsync()
        {
            var appid = configuration["WeChat:AppId"];
            var secret = configuration["WeChat:AppSecret"];
            var url = string.Format(URL, appid, secret);
            var result = await httpClient.GetAsync<WeChatTokenReponseResult>(url);
            return new WeChatToken()
            {
                access_token = result.access_token,
                expires_in = result.expires_in
            };
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
