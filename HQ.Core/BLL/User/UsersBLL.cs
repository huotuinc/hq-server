using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户逻辑层
    /// </summary>
    public class UsersBLL
    {
        private readonly UsersDAL dal = new UsersDAL();
        private static UsersBLL instance = new UsersBLL();
        private UsersBLL()
        { }

        public static UsersBLL Instance
        {
            get
            {
                return instance;
            }
        }



    }
}
