using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 短信接口定义
    /// </summary>
    public interface ISmsProvider
    {
        bool SendSms(string mobile, string content, out string msg);
        bool SendSmsMulti(string[] mobileList, string content, out string msg);
    }
}
