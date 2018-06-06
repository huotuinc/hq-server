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
        /// 返利类型
        /// </summary>
        public enum RebateTypeOptions
        {
            /// <summary>
            /// 一级返利
            /// </summary>
            返利 = 0,
            /// <summary>
            /// 二级返利
            /// </summary>
            管理奖 = 1,
            /// <summary>
            /// 
            /// </summary>
            育成奖 = 2
        }


        public enum UserLevelTypeOptions
        {
            普通会员 = 0,
            代理商 = 10,
            运营商 = 20,
            军团长 = 30,
            分公司 = 40
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

        public enum ClientOsTypeOptions
        {
            unknown = 0,
            miniProgram = 1,
            ios = 2,
            android = 3,
            h5 = 4
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
            /// 失败=302
            /// </summary>
            失败 = 301,
            /// <summary>
            /// 缺少请求参数 400
            /// </summary>
            缺少请求参数 = 400,
            /// <summary>
            /// 签名未传401
            /// </summary>
            签名未传 = 401,
            /// <summary>
            /// 签名错误402
            /// </summary>
            签名错误 = 402,
            /// <summary>
            /// 数据不存在403
            /// </summary>
            没有信息 = 403,

            参数有误 = 404,
            /// <summary>
            /// 服务器错误500
            /// </summary>
            服务器错误 = 500,
            /// <summary>
            /// 没有登录
            /// </summary>
            用户未登录 = 1000,
            /// <summary>
            /// 用户已被冻结
            /// </summary>
            用户已被冻结 = 1001,
            /// <summary>
            /// token与用户不匹配
            /// </summary>
            用户登录信息非法 = 1002,
            /// <summary>
            /// 上传图片失败 1100
            /// </summary>
            上传图片失败 = 1100,


        }
    }
}
