using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    public static class HttpClientExtension
    {
        public static async Task<T> PostAsync<T>(this HttpClient httpClient, string url, object obj) where T : WeChatResponseResult
        {
            var json = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, json);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsObjectAsync<T>();
            result.EnsureSuccess();
            return result;
        }

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string url) where T : WeChatResponseResult
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsObjectAsync<T>();
            result.EnsureSuccess();
            return result;

        }
    }
}
