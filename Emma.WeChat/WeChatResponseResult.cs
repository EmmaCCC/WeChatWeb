using System;
using System.Collections.Generic;
using System.Text;

namespace Emma.WeChat
{
    public class WeChatResponseResult
    {
        public int errcode { get; set; }

        public string errmsg { get; set; }

        public bool succeed
        {
            get
            {
                return errcode == 0;
            }
        }

        public void EnsureSuccess()
        {
            if (!succeed)
            {
                throw new WeChatErrorException(errmsg);
            }
        }
    }

    public class WeChatRequestData
    {

    }
}
