using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public class WeChatErrorException : Exception
    {
        public int ErrorCode { get; set; }
        public WeChatErrorException(string msg) : base(msg)
        {

        }

        public WeChatErrorException(int errcode, string msg) : this(msg)
        {
            this.ErrorCode = errcode;
        }

    }


}
