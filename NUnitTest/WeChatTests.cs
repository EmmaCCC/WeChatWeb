using Emma.WeChat;
using Emma.WeChat.Messages.TemplateMessages;
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
            var token = await tm.GetTokenAsync();
        }

        [Test]
        public async Task SendMessageAsyncTest()
        {
            var manager = services.GetRequiredService<TemplateMessageManager>();
            var result = await manager.SendMessageAsync("кнаж");
        }
    }
}