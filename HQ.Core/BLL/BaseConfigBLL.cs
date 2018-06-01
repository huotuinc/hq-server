using HQ.DAL;
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


    }
}
