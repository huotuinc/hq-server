using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户变更流水逻辑层
    /// </summary>
    public class UserLogsBLL
    {
        private readonly UserLogsDAL dal = new UserLogsDAL();
        private static UserLogsBLL instance = new UserLogsBLL();
        private UserLogsBLL()
        { }

        public static UserLogsBLL Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
