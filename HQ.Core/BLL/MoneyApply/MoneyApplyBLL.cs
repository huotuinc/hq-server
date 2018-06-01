using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.MoneyApply
{
    /// <summary>
    /// 提现申请配置逻辑层
    /// </summary>
    public class MoneyApplyBLL
    {
        private readonly MoneyApplyDAL dal = new MoneyApplyDAL();
        private static MoneyApplyBLL instance = new MoneyApplyBLL();
        private MoneyApplyBLL()
        { }

        public static MoneyApplyBLL Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
