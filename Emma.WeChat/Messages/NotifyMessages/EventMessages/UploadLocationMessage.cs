using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages.EventMessages
{
    public class UploadLocationMessage : EventMessage
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Precision { get; set; }
    }
}
