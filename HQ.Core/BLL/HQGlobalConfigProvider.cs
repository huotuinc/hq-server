using HQ.Common;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 全局配置提供负责人
    /// </summary>
    public class HQGlobalConfigProvider
    {
        private HQGlobalConfigProvider()
        { }

        /// <summary>
        /// 系统基础配置
        /// </summary>
        /// <returns></returns>
        public static BaseConfigModel GetBaseConfig()
        {
            return null;
        }

        /// <summary>
        /// 接口签名秘钥
        /// </summary>
        public static string ApiSecret
        {
            get
            {
                return ConfigHelper.GetConfigString("ApiSecret", "3ab0d4e6a8bf9b5b1cb1d38d00bcf339");
            }
        }
    }
}
