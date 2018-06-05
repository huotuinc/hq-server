using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Ddk
{
    /// <summary>
    /// 多多客应用逻辑层
    /// </summary>
    public class DdkAppsBLL
    {
        private readonly DdkAppsDAL dal = new DdkAppsDAL();
        private static readonly DdkAppsBLL instance = new DdkAppsBLL();
        private DdkAppsBLL()
        { }

        public static DdkAppsBLL Instance
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
        public int Add(DdkAppsModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DdkAppsModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AppId)
        {
            return dal.Delete(AppId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DdkAppsModel GetModel(int AppId)
        {
            return dal.GetModel(AppId);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetList(int pageSize, int pageIndex, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, out recordCount);
        }

        /// <summary>
        /// 得到目前启用着的所有多多客应用
        /// </summary>
        /// <returns></returns>
        public List<DdkAppsModel> GetEffectList()
        {
            return dal.GetEffectList();
        }
        #endregion  BasicMethod
    }
}
