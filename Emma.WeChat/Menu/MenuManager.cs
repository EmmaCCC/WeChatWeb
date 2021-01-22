using Emma.WeChat.Attributes;
using Emma.WeChat.Menu.ReponseResults;
using Emma.WeChat.Menu.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Menu
{
    [WeChatApiManager]
    public class MenuManager : WeChatManager
    {
        private const string CREAT_URL = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
        private const string GET_LIST_URL = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}";
        private const string DEL_URL = "https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}";
        private const string CREAT_PERSONALITY_URL = "https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}";
        private const string DEL_PERSONALITY_URL = "https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}";
        private const string TRY_MATCH_PERSONALITY_URL = "https://api.weixin.qq.com/cgi-bin/menu/trymatch?access_token={0}";

        public MenuManager(TokenManager tokenManager) : base(tokenManager)
        {

        }

        public async Task<CreateMenuResponseResult> CreateMenuAsync(CreateMenuRequestData data)
        {
            var url = string.Format(CREAT_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<CreateMenuResponseResult>(url, data);
        }

        public async Task<WeChatResponseResult> DeleteMenuAsync()
        {
            var url = string.Format(DEL_URL, tokenManager.Token.access_token);
            return await httpClient.GetAsync<CreateMenuResponseResult>(url);
        }

        public async Task<CreatePersonalityMenuResponseResult> CreatePersonalityMenuAsync(CreatePersonalityMenuRequestData data)
        {
            var url = string.Format(CREAT_PERSONALITY_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<CreatePersonalityMenuResponseResult>(url, data);
        }

        public async Task<WeChatResponseResult> DeletePersonalityMenuAsync(DeletePersonalityMenuRequestData data)
        {
            var url = string.Format(DEL_PERSONALITY_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<WeChatResponseResult>(url, data);
        }

        public async Task<TryMatchMenuResponseResult> TryMatchPersonalityMenuAsync(TryMatchMenuRequestData data)
        {
            var url = string.Format(TRY_MATCH_PERSONALITY_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<TryMatchMenuResponseResult>(url, data);
        }
    }
}
