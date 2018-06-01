using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.MoneyApply
{
    /// <summary>
    /// 提现申请逻辑层
    /// </summary>
    public class MoneyApplyConfigBLL
    {
        private readonly MoneyApplyConfigDAL dal = new MoneyApplyConfigDAL();
        private static MoneyApplyConfigBLL instance = new MoneyApplyConfigBLL();
        private MoneyApplyConfigBLL()
        { }

        public static MoneyApplyConfigBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
