using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Common
{
    public class ConfigHelper
    {
        /// <summary>
        /// 默认链接，key=MssqlDBConnectionString
        /// </summary>
        public static string MssqlDBConnectionString_Sync { get { return GetConfigString("MssqlDBConnectionString"); } }

        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetConfigString(string key, string defaultValue)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key] ?? defaultValue;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key] ?? "";
        }
    }
}