using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户等级逻辑层
    /// </summary>
    public class UserLevelBLL
    {
        private readonly UserLevelDAL dal = new UserLevelDAL();
        private static UserLevelBLL instance = new UserLevelBLL();
        private UserLevelBLL()
        { }

        public static UserLevelBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
