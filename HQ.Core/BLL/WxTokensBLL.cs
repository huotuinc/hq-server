using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 微信token维护逻辑层
    /// </summary>
    public class WxTokensBLL
    {
        private readonly WxTokensDAL dal = new WxTokensDAL();
        private static WxTokensBLL instance = new WxTokensBLL();
        private WxTokensBLL()
        { }

        public static WxTokensBLL Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
