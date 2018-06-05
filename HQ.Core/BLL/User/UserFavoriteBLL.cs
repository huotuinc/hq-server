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
        public List<UserFavoriteModel> favoriteList(int userId, int platType, int pageIndex, int pageSize)
        {
            //todo 获取相应商品数据
            List<UserFavoriteModel> list = dal.list(userId, platType, pageIndex, pageSize);
            list.ForEach(item =>
            {

            });
            return null;
        }

        public bool favoriteDelete(string ids, int userId, Int16 platType)
        {
            return dal.delete(ids, userId, platType);
        }

    }
}
