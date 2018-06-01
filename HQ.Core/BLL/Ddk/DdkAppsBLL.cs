using HQ.DAL;
using System;
using System.Collections.Generic;
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
        private static DdkAppsBLL instance = new DdkAppsBLL();
        private DdkAppsBLL()
        { }

        public static DdkAppsBLL Instance
        {
            get
            {
                return instance;
            }
        }

    }
}
