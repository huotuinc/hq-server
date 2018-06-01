using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户第三方授权逻辑层
    /// </summary>
    public class UserOAuthBondsBLL
    {
        private readonly UserOAuthBondsDAL dal = new UserOAuthBondsDAL();
        private static UserOAuthBondsBLL instance = new UserOAuthBondsBLL();
        private UserOAuthBondsBLL()
        { }

        public static UserOAuthBondsBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
