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
    /// 基础配置逻辑层
    /// </summary>
    public class BaseConfigBLL
    {
        private readonly BaseConfigDAL dal = new BaseConfigDAL();
        private static BaseConfigBLL instance = new BaseConfigBLL();
        private BaseConfigBLL()
        { }

        public static BaseConfigBLL Instance
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
        public int Add(BaseConfigModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseConfigModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ConfigId)
        {
            return dal.Delete(ConfigId);
        }
        
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseConfigModel GetModel(int ConfigId)
        {
            return dal.GetModel(ConfigId);
        }

        #endregion  BasicMethod
    }
}
