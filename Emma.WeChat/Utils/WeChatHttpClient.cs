﻿using Emma.WeChat.Global;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat.Utils
{
    public class WeChatHttpClient
    {
        private readonly HttpClient httpClient;
        private readonly WeChatOptions options;
        private TokenManager manager;

        public WeChatHttpClient(HttpClient httpClient, IOptions<WeChatOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        public async Task<T> PostAsync<T>(string url, WeChatRequestData data) where T : WeChatResponseResult
        {
            var events = options.Events;
            await events.OnRequestExecuting(new WeChatRequestExecutingContext()
            {
                RequestData = data,
                HttpMethod = HttpMethod.Post,
                Url = url,
                Manager = manager
            });

            var str = JsonSerializer.Serialize(data,data.GetType());
            var json = new StringContent(str, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, json);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsObjectAsync<T>();

            await events.OnRequestExecuted(new WeChatRequestExecutedContext()
            {
                RequestData = data,
                HttpResponseMessage = response,
                ResponseResult = result,
                HttpMethod = HttpMethod.Post,
                Url = url,
                Manager = manager
            });
            if (options.ThrowExceptionIfError && !result.succeed)
            {
                throw new WeChatErrorException(result.errcode, result.errmsg);
            }
            return result;

        }
        public async Task<T> GetAsync<T>(string url) where T : WeChatResponseResult
        {
            var events = options.Events;
            await events.OnRequestExecuting(new WeChatRequestExecutingContext()
            {
                HttpMethod = HttpMethod.Get,
                Url = url,
                Manager = manager
            });

            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsObjectAsync<T>();

            await events.OnRequestExecuted(new WeChatRequestExecutedContext()
            {
                HttpResponseMessage = response,
                ResponseResult = result,
                HttpMethod = HttpMethod.Get,
                Url = url,
                Manager = manager
            });

            if (options.ThrowExceptionIfError && !result.succeed)
            {
                throw new WeChatErrorException(result.errcode, result.errmsg);
            }
            return result;
        }

        internal void SetManager(TokenManager manager)
        {
            this.manager = manager;
        }
    }
}
