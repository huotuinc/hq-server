using HQ.Core.DAL.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Rebate
{
    public class RebateStatsMonthlyBLL
    {
        private readonly RebateStatsMonthlyDAL dal = new RebateStatsMonthlyDAL();
        private static RebateStatsMonthlyBLL instance = new RebateStatsMonthlyBLL();
        private RebateStatsMonthlyBLL()
        { }

        public static RebateStatsMonthlyBLL Instance
        {
            get
            {
                return instance;
            }
        }


        public decimal getMonth(int userId)
        {
            return dal.getMonth(userId);
        }

        /// <summary>
        /// 获得上月
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getLastMonth(int userId)
        {
            return dal.getLastMonth(userId);
        }
    }
}
