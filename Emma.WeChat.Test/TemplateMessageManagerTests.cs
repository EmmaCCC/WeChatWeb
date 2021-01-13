using Emma.WeChat;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Messages.TemplateMessages.RequestModels;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Emma.WeChat.Test
{
    public class TemplateMessageManagerTests
    {
        private TemplateMessageManager manager;
        [SetUp]
        public void Setup()
        {
            var services = ServiceProviderInitializer.Init();
            manager = services.GetRequiredService<TemplateMessageManager>();
        }

        [Test]
        public async Task SendMessageAsyncTest()
        {
            var result = await manager.SendMessageAsync(new SendMessageRequestData()
            {
                touser = "o9utb54nn_aLeeO9XxjFJm673duw",
                template_id = "j3mvve7Xyz9oLhNOdy5nNgNgeZjKbPEwyL5O1bG2-cc",
                data = new
                {
                    sender = new
                    {
                        value = $"�ļ��ˣ�����������",
                    },
                    mobile = new
                    {
                        value = $"���Ա�ֻ��ţ�13140167513",
                    },
                    expressno = new
                    {
                        value = $"��ݵ��ţ�����{DateTime.Now.ToFileTime()}",
                    }
                }

            });
        }

        [Test]
        public async Task GetTemplateMessageListAsyncTest()
        {
            var result = await manager.GetTemplateMessageListAsync();
        }
    }
}