using Emma.WeChat.Messages.NotifyMessages.CommonMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Emma.WeChat.Messages.NotifyMessages
{
    public class NotifyMessageHandler
    {
        private readonly IMessageNotifier notifier;

        public NotifyMessageHandler(IMessageNotifier notifier)
        {
            this.notifier = notifier;
        }

        public Task HandleMessageAsync(NotifyMessageContext context)
        {
            var request = context.HttpContext.Request;
            if (string.Compare(request.Method, "get", true) == 0
            && request.Query.ContainsKey("signature"))
            {
                return notifier.OnCheckMessage(new CheckMessageContext()
                {
                    HttpContext = context.HttpContext,
                    AppConfig = context.AppConfig
                });
            }
            return ParseMessageAsync(context);
        }

        private Task ParseMessageAsync(NotifyMessageContext context)
        {
            if (string.IsNullOrEmpty(context.Body))
            {
                return Task.CompletedTask;
            }

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(context.Body);
            XmlElement rootElement = doc.DocumentElement;
            var msgType = rootElement.SelectSingleNode("MsgType").InnerText;

            if (msgType != MsgTypes.Event)
            {
                var commonContext = new CommonMessageContext()
                {
                    Body = context.Body,
                    HttpContext = context.HttpContext,
                    AppConfig = context.AppConfig,
                    MsgType = msgType
                };

                if (MsgTypeMaps.MsgMaps.TryGetValue(msgType, out var messageType))
                {
                    commonContext.Message = WeChatNotifyMessage.FromXml(context.Body, messageType);
                }

                this.notifier.OnCommonMessage(commonContext);
            }
            else
            {
                var evt = rootElement.SelectSingleNode("Event").InnerText;
                var eventContext = new EventMessageContext()
                {
                    Body = context.Body,
                    HttpContext = context.HttpContext,
                    AppConfig = context.AppConfig,
                    Event = evt
                };

                if (MsgTypeMaps.EventMaps.TryGetValue(msgType, out var messageType))
                {
                    eventContext.Message = WeChatNotifyMessage.FromXml(context.Body, messageType);
                }
                this.notifier.OnEventMessage(eventContext);
            }

            return Task.CompletedTask;
        }
    }
}
