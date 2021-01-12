using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeChatWeb.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string echostr)
        {
            var client = httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=wxa51f0fc725926089&secret=f22368403feac6a2f78dc45abc65296d");
            var content = result.Content.ReadAsStringAsync();
            await Task.CompletedTask;
            return Ok(echostr);
        }
    }
}
