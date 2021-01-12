using Emma.WeChat.Messages.TemplateMessages.ResponseResults;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat.Messages.TemplateMessages
{
    public class TemplateMessageManager : TokenManager
    {
        private const string SEND_URL = "https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}";
        public TemplateMessageManager(IConfiguration configuration, IHttpClientFactory httpClientFactory)
            : base(configuration, httpClientFactory)
        {

        }

        public async Task<SendMessageResponseResult> SendMessageAsync(string name)
        {
            var token = await GetTokenAsync();
            var url = string.Format(SEND_URL, token.access_token);
            var message = new
            {
                touser = "o9utb54nn_aLeeO9XxjFJm673duw",
                template_id = "j3mvve7Xyz9oLhNOdy5nNgNgeZjKbPEwyL5O1bG2-cc",
                data = new
                {
                    sender = new
                    {
                        value = $"寄件人：　　　{name}",
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

            return await httpClient.PostAsync<SendMessageResponseResult>(url, message);

        }
    }
}
