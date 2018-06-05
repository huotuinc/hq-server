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

        /// <summary>
        /// 返回当前等级类型最大的LevelNo
        /// </summary>
        /// <param name="LevelType"></param>
        /// <returns></returns>
        public int GetLevelNo(int LevelType)
        {
            return dal.GetLevelNo(LevelType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UserLevelModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HQ.Model.UserLevelModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LevelId)
        {
            return dal.Delete(LevelId);
        }

        /// <summary>
        /// 获取等级列表
        /// </summary>
        /// <returns></returns>
        public List<UserLevelModel> GetList()
        {
            return dal.GetList();
        }

        public int GetLevelId(int UserId)
        {
            UsersBLL.Instance.get

            return -1;
        }

    }
}
