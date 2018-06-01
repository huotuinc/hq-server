using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户余额变动流水逻辑层
    /// </summary>
    public class UserBalanceLogBLL
    {
        private readonly UserBalanceLogDAL dal = new UserBalanceLogDAL();
        private static UserBalanceLogBLL instance = new UserBalanceLogBLL();
        private UserBalanceLogBLL()
        { }

        public static UserBalanceLogBLL Instance
        {
            get
            {
                return instance;
            }
        }



    }
}
