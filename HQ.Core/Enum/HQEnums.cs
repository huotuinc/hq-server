using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Enum
{
    public class HQEnums
    {
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

    }
}
