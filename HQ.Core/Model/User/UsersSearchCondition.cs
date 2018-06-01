using HQ.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model.User
{
    /// <summary>
    /// 用户搜索条件
    /// </summary>
    public class UsersSearchCondition : ISearchCondition
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
    }
}
