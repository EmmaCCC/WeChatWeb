using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Emma.WeChat
{
    public static class HttpContentExtension
    {
        public static async Task<T> ReadAsObjectAsync<T>(this HttpContent httpContent)
        {
            var content = await httpContent.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
