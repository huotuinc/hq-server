using HQ.DAL;
using HQ.Model;
using HQ.PddOpen.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Ddk
{
    /// <summary>
    /// 多多客主题逻辑层
    /// </summary>
    public class DdkThemeBLL
    {
        private readonly DdkThemeDAL dal = new DdkThemeDAL();
        private static DdkThemeBLL instance = new DdkThemeBLL();
        private DdkThemeBLL()
        { }

        public static DdkThemeBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 从拼多多同步主题数据到数据库中
        /// </summary>
        /// <returns></returns>
        public bool Sync()
        {
            return true;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DdkThemeModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DdkThemeModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ThemeId)
        {
            return dal.Delete(ThemeId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DdkThemeModel GetModel(int ThemeId)
        {
            return dal.GetModel(ThemeId);
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
        #endregion  BasicMethod
    }
}
