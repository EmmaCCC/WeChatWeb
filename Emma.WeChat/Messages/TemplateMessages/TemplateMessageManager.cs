using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using Emma.WeChat.Messages.TemplateMessages.ResponseResults;
using Emma.WeChat.Utils;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Emma.WeChat.Messages.TemplateMessages
{
    public class TemplateMessageManager : TokenManager
    {
        private const string SEND_URL = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";

        public TemplateMessageManager(WeChatHttpClient httpClient, AppConfig config) : base(httpClient, config)
        {

        }

        public async Task<SendMessageResponseResult> SendMessageAsync(SendMessageRequestData data)
        {
            var url = string.Format(SEND_URL, Token.access_token);

            data = new SendMessageRequestData()
            {
                touser = "o9utb54nn_aLeeO9XxjFJm673duw",
                template_id = "j3mvve7Xyz9oLhNOdy5nNgNgeZjKbPEwyL5O1bG2-cc",
                data = new
                {
                    sender = new
                    {
                        value = $"寄件人：　　　宋林",
                    },
                    mobile = new
                    {
                        value = $"快递员手机号：13140167513",
                    },
                    expressno = new
                    {
                        value = $"快递单号：　　{DateTime.Now.ToFileTime()}",
                    }
                }

            };
            return await httpClient.PostAsync<SendMessageResponseResult>(url, data);

        }
    }
}
