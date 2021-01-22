using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Menu.RequestModels
{
    public class TryMatchMenuRequestData : CreateMenuRequestData
    {
        public string user_id { get; set; }
    }
}
