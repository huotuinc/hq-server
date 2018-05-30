using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ShortMessage
{
    public class SmsProviderFactory
    {
        public static ISmsProvider GetSmsProvider()
        {
            //todo 短信提供商
            string providerKey = "";
            switch (providerKey)
            {
                case "chuanglan":
                    return new ChuanglanSmsProvider();
            }
            return new ChuanglanSmsProvider();
        }
    }
}
