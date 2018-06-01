using HQ.DAL;
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


    }
}
