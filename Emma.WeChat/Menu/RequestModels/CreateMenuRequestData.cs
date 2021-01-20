using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Menu.RequestModels
{
    public class CreateMenuRequestData : WeChatRequestData
    {
        public List<Button> button { get; set; }
    }

    public class Button
    {
        public string type { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public List<SubButton> sub_button { get; set; }
    }

    public class SubButton
    {
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string appid { get; set; }
        public string pagepath { get; set; }
        public string key { get; set; }
        public string media_id { get; set; }
    }

}
