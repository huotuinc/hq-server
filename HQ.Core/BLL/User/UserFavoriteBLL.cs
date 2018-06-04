using HQ.DAL;
using HQ.Model;
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


        public bool favorite(long goodsId, int userId, Int16 platType)
        {
            UserFavoriteModel model = dal.GetModel(userId, goodsId, platType);
            if (model == null)
            {
                model = new UserFavoriteModel();
                model.GoodsId = goodsId;
                model.UserId = userId;
                model.PlatType = platType;
                model.CreateTime = DateTime.Now;
                return dal.Add(model) == 1;
            }
            return true;
        }

    }
}
