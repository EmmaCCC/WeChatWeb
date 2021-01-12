using Emma.WeChat;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using GwlUrm.Test;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class WeChatTests
    {
        private IServiceProvider services;
        [SetUp]
        public void Setup()
        {
            services = ServiceProviderInitializer.Init();
        }

        [Test]
        public async Task GetTokenAsyncTest()
        {
            var tm = services.GetRequiredService<TokenManager>();
        }

        [Test]
        public async Task SendMessageAsyncTest()
        {
            var manager1 = services.GetRequiredService<TemplateMessageManager>();
            var manager2 = services.GetRequiredService<TemplateMessageManager>();
            manager2.ReSetAppConfig(new AppConfig() { AppId = "xxx", AppSecret = "xxxx" });
            var result = await manager1.SendMessageAsync(new SendMessageRequestData());
            var result2 = await manager2.SendMessageAsync(new SendMessageRequestData());
        }
    }
}