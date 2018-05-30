using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.ViewModel
{
    [Serializable]
    public class ManagerViewModel
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// MD5密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 随机码
        /// </summary>
        public string Noncestr { get; set; }
        /// <summary>
        /// 对应枚举ManagerRoleOptions
        /// </summary>
        public int RoleType { get; set; }
        /// <summary>
        /// 是否超级管理员，后台管理员
        /// </summary>
        public int IsSuper { get; set; }

        public int ManagerId { get; set; }

        /// <summary>
        /// 授权的菜单
        /// </summary>
        public string AuthMenus { get; set; }
        /// <summary>
        /// 授权的功能
        /// </summary>
        public string AuthFuncs { get; set; }
    }
}
