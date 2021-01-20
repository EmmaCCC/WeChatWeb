using Emma.WeChat.Attributes;
using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using Emma.WeChat.Messages.TemplateMessages.ResponseResults;
using Emma.WeChat.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Emma.WeChat.Messages.TemplateMessages
{
    [WeChatApiManager]
    public class TemplateMessageManager : WeChatManager
    {
        private const string SEND_URL = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
        private const string GET_LIST_URL = "https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}";
        private const string DEL_URL = "https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}";

        public TemplateMessageManager(TokenManager tokenManager) : base(tokenManager)
        {

        }

        public async Task<SendMessageResponseResult> SendMessageAsync(SendMessageRequestData data)
        {
            var url = string.Format(SEND_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<SendMessageResponseResult>(url, data);
        }

        public async Task<GetTemplateMessageListResponseResult> GetTemplateMessageListAsync()
        {
            var url = string.Format(GET_LIST_URL, tokenManager.Token.access_token);
            var result = await httpClient.GetAsync<GetTemplateMessageListResponseResult>(url);
            return result;
        }

        public async Task<WeChatResponseResult> DeleteMessageAsync(DeleteMessageRequestData data)
        {
            var url = string.Format(DEL_URL, tokenManager.Token.access_token);
            return await httpClient.PostAsync<WeChatResponseResult>(url, data);
        }
    }
}
