using HQ.Core.DAL.SystemConfig;
using HQ.Core.Model.SystemConfig;
using HQ.Core.ViewModel.SearchCondition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.SystemConfig
{
    /// <summary>
    /// 后台管理员逻辑层
    /// </summary>
    public class ManagerBLL
    {
        private readonly ManagerDAL dal = new ManagerDAL();
        private static ManagerBLL instance = new ManagerBLL();
        private ManagerBLL()
        { }

        public static ManagerBLL Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Exists(string loginName, string password)
        {
            return dal.Exists(loginName, password);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsEffect(string loginName, string password)
        {
            return dal.ExistsEffect(loginName, password);
        }

        public ManagerModel GetModel(string loginName, string password)
        {
            return dal.GetModel(loginName, password);
        }

        public void UpdatePassword(string loginName, string md5password)
        {
            dal.UpdatePassword(loginName, md5password);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ManagerModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManagerModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ManagerId)
        {
            return dal.Delete(ManagerId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ManagerModel GetModel(int ManagerId)
        {
            return dal.GetModel(ManagerId);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="iPageSize"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="iRecordCount"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetList(int iPageSize, int iPageIndex, out int iRecordCount, ManagerSearchCondition condition)
        {
            return dal.GetList(iPageSize, iPageIndex, out iRecordCount, condition);
        }

        public bool ExistsLoginName(string loginName)
        {
            return dal.ExistsLoginName(loginName);
        }
    }
}
