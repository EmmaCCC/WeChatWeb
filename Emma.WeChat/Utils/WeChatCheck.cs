using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Emma.WeChat.Utils
{
    public class WeChatCheck
    {
        public static async Task<bool> CheckSign(WeChatOptions options, HttpContext context)
        {
            var query = context.Request.Query;
            var signature = query["signature"];
            var timestamp = query["timestamp"];
            var nonce = query["nonce"];
            var echostr = query["echostr"];
            var token = options.Token;

            var list = new List<string>();
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);

            list.Sort();

            var valid = string.Join("", list);

            //加密
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string sign = BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(valid)));
            sign = sign.Replace("-", "").ToLower();

            var result = sign == signature;
            if (result)
            {
                await context.Response.WriteAsync(echostr);
            }
            else
            {
                await context.Response.WriteAsync(result.ToString());
            }
            return result;
        }
    }
}
