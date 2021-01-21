using Emma.WeChat.Attributes;
using Emma.WeChat.Global;
using Emma.WeChat.Utils;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    [WeChatApiManager]
    public class TokenManager
    {
        public WeChatHttpClient httpClient { get; protected set; }
        public WeChatToken Token { get; protected set; }
        public AppConfig Config { get; protected set; }

        private const string URL = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";
        private readonly IOptions<WeChatOptions> options;
        private readonly ITokenStore tokenStore;

        public TokenManager(WeChatHttpClient httpClient, IOptions<WeChatOptions> options,
            ITokenStore tokenStore)
        {
            this.httpClient = httpClient;
            this.options = options;
            this.tokenStore = tokenStore;
            this.Config = options.Value.AppConfigs.First();
            this.GetTokenAsync().Wait();
        }

        private async Task GetTokenAsync()
        {
            var token = await tokenStore.GetTokenAsync(Config);
            if (token == null)
            {
                var url = string.Format(URL, Config.AppId, Config.AppSecret);
                var result = await httpClient.GetAsync<WeChatTokenReponseResult>(url);
                token = new WeChatToken()
                {
                    access_token = result.access_token,
                    expires_in = result.expires_in
                };

                await tokenStore.SaveTokenAsync(Config, token);
            }
            this.Token = token;
        }
        public void SelectAppConfig(string nameOrId)
        {
            var config = options.Value.AppConfigs.SingleOrDefault(a => a.AppId == nameOrId
            || a.AppName == nameOrId);
            if (config != null)
            {
                this.Config = config;
                this.GetTokenAsync().Wait();
            }
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

        public void SelectAppConfig(string nameOrId)
        {
            this.tokenManager.SelectAppConfig(nameOrId);
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
