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
    /// 热门搜索关键字逻辑层
    /// </summary>
    public class HotKeywordBLL
    {
        private readonly HotKeywordDAL dal = new HotKeywordDAL();
        private static HotKeywordBLL instance = new HotKeywordBLL();
        private HotKeywordBLL()
        { }

        public static HotKeywordBLL Instance
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
        public int Add(HotKeywordModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HotKeywordModel model)
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
        public HotKeywordModel GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        #endregion  BasicMethod
    }
}
