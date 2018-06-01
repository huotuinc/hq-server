using HQ.DAL;
using System;
using System.Collections.Generic;
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


    }
}
