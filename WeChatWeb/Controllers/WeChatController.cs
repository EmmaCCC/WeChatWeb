using Emma.WeChat.Messages.NotifyMessages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeChatWeb.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class WeChatController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public WeChatController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Notify(WeChatNotifyMessage message)
        {
            Request.EnableBuffering();
            
            using (var reader = new StreamReader(Request.Body, encoding: Encoding.UTF8))
            {
                var body = await reader.ReadToEndAsync();
                // Do some processing with body…
                // Reset the request body stream position so the next middleware can read it
                Request.Body.Position = 0;
            }
            return Ok(message);
        }
    }
}
