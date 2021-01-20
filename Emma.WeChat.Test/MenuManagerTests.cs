using Emma.WeChat;
using Emma.WeChat.Menu;
using Emma.WeChat.Menu.RequestModels;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Emma.WeChat.Test
{
    public class MenuManagerTests
    {
        private MenuManager manager;
        [SetUp]
        public void Setup()
        {
            var services = ServiceProviderInitializer.Init();
            manager = services.GetRequiredService<MenuManager>();
        }

        [Test]
        public async Task CreateMenuAsyncTest()
        {
            var data = new CreateMenuRequestData()
            {
                button = new List<Button>()
                {
                     new Button()
                     {
                          type = "click",
                          name = "今日歌曲",
                          key = "V1001_TODAY_MUSIC"
                     },
                     new Button()
                     {
                         name = "菜单",
                         sub_button = new List<SubButton>()
                         {
                             new SubButton()
                             {
                                  type = "view",
                                  name ="搜索",
                                  url = "http://www.soso.com/"

                             }
                         }
                     },
                     new Button()
                     {
                         name = "查看",
                         sub_button = new List<SubButton>()
                         {
                             new SubButton()
                             {
                                  type = "view",
                                  name ="获取",
                                  url = "http://www.soso.com/"

                             }
                         }
                     }
                }
            };

            var result = await manager.CreateMenuAsync(data);
        }


        [Test]
        public async Task DeleteMenuAsyncTest()
        {
            var result = await manager.DeleteMenuAsync();
        }


    }
}