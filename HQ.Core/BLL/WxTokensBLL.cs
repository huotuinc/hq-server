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
    /// 微信token维护逻辑层
    /// </summary>
    public class WxTokensBLL
    {
        private readonly WxTokensDAL dal = new WxTokensDAL();
        private static WxTokensBLL instance = new WxTokensBLL();
        private WxTokensBLL()
        { }

        public static WxTokensBLL Instance
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
        public int Add(WxTokensModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WxTokensModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WxTokensModel GetModel(int TypeKey)
        {
            return dal.GetModel(TypeKey);
        }

        #endregion  BasicMethod

    }
}
