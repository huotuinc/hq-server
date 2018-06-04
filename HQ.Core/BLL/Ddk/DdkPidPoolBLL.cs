using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Ddk
{
    /// <summary>
    /// 多多客PID池逻辑层
    /// </summary>
    public class DdkPidPoolBLL
    {
        private readonly DdkPidPoolDAL dal = new DdkPidPoolDAL();
        private static DdkPidPoolBLL instance = new DdkPidPoolBLL();
        private DdkPidPoolBLL()
        { }

        public static DdkPidPoolBLL Instance
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
        public int Add(DdkPidPoolModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DdkPidPoolModel model)
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
        public DdkPidPoolModel GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        #endregion  BasicMethod
    }
}
