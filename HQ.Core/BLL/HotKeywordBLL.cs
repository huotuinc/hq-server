using HQ.DAL;
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
    }
}
