using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Menu.RequestModels
{
    public class CreatePersonalityMenuRequestData : CreateMenuRequestData
    {
        public Matchrule matchrule { get; set; }
    }

    public class Matchrule
    {
        public string tag_id { get; set; }
        public string sex { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string client_platform_type { get; set; }
        public string language { get; set; }
    }

}
