using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户收藏逻辑层
    /// </summary>
    public class UserFavoriteBLL
    {
        private readonly UserFavoriteDAL dal = new UserFavoriteDAL();
        private static UserFavoriteBLL instance = new UserFavoriteBLL();
        private UserFavoriteBLL()
        { }

        public static UserFavoriteBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
