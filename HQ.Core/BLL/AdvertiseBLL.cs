using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 广告位逻辑层
    /// </summary>
    public class AdvertiseBLL
    {
        private readonly AdvertiseDAL dal = new AdvertiseDAL();
        private static AdvertiseBLL instance = new AdvertiseBLL();
        private AdvertiseBLL()
        { }

        public static AdvertiseBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AdvertiseModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AdvertiseModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AdId)
        {
            return dal.Delete(AdId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AdvertiseModel GetModel(int AdId)
        {
            return dal.GetModel(AdId);
        }

        #endregion  BasicMethod
    }
}
