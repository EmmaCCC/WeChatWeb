using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using Emma.WeChat.Messages.NotifyMessages.EventMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public class MsgTypeMaps
    {
        public static Dictionary<string, Type> MsgMaps;
        public static Dictionary<string, Type> EventMaps;
        static MsgTypeMaps()
        {
            MsgMaps = new Dictionary<string, Type>()
            {
                { MsgTypes.Text,typeof(TextMessage) },
                { MsgTypes.Image,typeof(ImageMessage) },
                { MsgTypes.Voice,typeof(VoiceMessage) },
                { MsgTypes.Video,typeof(VideoMessage) },
                { MsgTypes.ShortVideo,typeof(ShortVideoMessage) },
                { MsgTypes.Location,typeof(LocationMessage) },
                { MsgTypes.Link,typeof(LinkMessage) }
            };

            EventMaps = new Dictionary<string, Type>()
            {
                { Events.Subscribe,typeof(SubscribeMessage) },
                { Events.Unsubscribe,typeof(UnSubscribeMessage) },
                { Events.SCAN,typeof(ScanMessage) },
                { Events.CLICK,typeof(MenuClickMessage) },
                { Events.VIEW,typeof(MenuViewMessage) }
            };
        }
    }
}
