using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQ.ApiWeb.Models
{
    /// <summary>
    /// 请求头部信息，当做action参数时，会自动注入值
    /// </summary>
    public class HQRequestHeader
    {
        /// <summary>
        /// APP版本
        /// </summary>
        public string appVersion { get; set; }
        /// <summary>
        /// 设备号
        /// </summary>
        public string hwid { get; set; }
        /// <summary>
        /// 设备类型
        /// </summary>
        public string mobileType { get; set; }
        /// <summary>
        /// 系统类型
        /// </summary>
        public int osType { get; set; }
        /// <summary>
        /// 渠道信息
        /// </summary>
        public string ttid { get; set; }
        /// <summary>
        /// 登录信息
        /// </summary>
        public string userToken { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// 用户ID字符串
        /// </summary>
        public string userIdStr { get; set; }
    }
}