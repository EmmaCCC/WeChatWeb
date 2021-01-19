﻿using Emma.WeChat.Global;
using Emma.WeChat.Messages.NotifyMessages;
using Emma.WeChat.Messages.TemplateMessages;
using Emma.WeChat.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Emma.WeChat
{
    public static class WeChatAppBuilderExtensions
    {
        public static void UseWeChat(this IApplicationBuilder app)
        {
            var opts = app.ApplicationServices.GetRequiredService<IOptions<WeChatOptions>>().Value;

            var messageHandler = app.ApplicationServices.GetRequiredService<NotifyMessageHandler>();

            app.Map(opts.NotifyUrl, ap =>
            {
                ap.Use(async (context, next) =>
                {
                    var request = context.Request;
                    request.EnableBuffering();

                    using (var reader = new StreamReader(request.Body, encoding: Encoding.UTF8))
                    {
                        var body = await reader.ReadToEndAsync();

                        await messageHandler.HandleMessageAsync(new NotifyMessageContext()
                        {
                            Body = body,
                            HttpContext = context,
                            WeChatOptions = opts
                        });

                        request.Body.Position = 0;
                    }
                });
            });
        }
    }
}
