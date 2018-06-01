using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model.SystemConfig
{
    /// <summary>
    /// 管理员查询条件
    /// </summary>
    public class ManagerSearchCondition : ISearchCondition
    {
        /// <summary>
        /// 账号名
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool FilterSuper { get; set; }
    }
}
