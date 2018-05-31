using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Enum
{
    /// <summary>
    /// 平台枚举汇总
    /// </summary>
    public class HQEnums
    {
        /// <summary>
        /// 对接平台类型
        /// </summary>
        public enum PlatformTypeOptions
        {
            拼多多 = 0,
            京东 = 1,
            淘宝 = 2
        }

        /// <summary>
        /// 后台管理员类型
        /// </summary>
        public enum ManagerRoleOptions
        {
            后台管理员 = 0,
            代理商管理员 = 1
        }

        /// <summary>
        /// 短信发送场景
        /// </summary>
        public enum SmsSceneOptions
        {
            验证码 = 0
        }

        /// <summary>
        /// API接口返回状态枚举
        /// </summary>
        public enum ResultOptionType
        {
            /// <summary>
            /// 成功 200
            /// </summary>
            OK = 200,
            /// <summary>
            /// 参数错误 300
            /// </summary>
            参数错误 = 300,
            /// <summary>
            /// 修改状态失败=301
            /// </summary>
            修改状态失败 = 301,
            /// <summary>
            /// 失败=302
            /// </summary>
            失败 = 302,
            /// <summary>
            /// 没有授权401
            /// </summary>
            没有授权 = 401,
            /// <summary>
            /// 签名无效402
            /// </summary>
            签名无效 = 402,
            /// <summary>
            /// 没有信息=403
            /// </summary>
            没有信息 = 403,

            /// <summary>
            /// 服务器错误=500
            /// </summary>
            服务器错误 = 500,
            /// <summary>
            /// 上传图片失败 501
            /// </summary>
            上传图片失败 = 501,
            /// <summary>
            /// 操作过于频繁
            /// </summary>
            操作过于频繁 = 502,

            /// <summary>
            /// 已经存在 503
            /// </summary>
            已经存在 = 503,
            /// <summary>
            /// 用户已被冻结
            /// </summary>
            用户已被冻结 = 601,

            /// <summary>
            /// 没有登录
            /// </summary>
            没有登录 = 602
        }
    }
}
