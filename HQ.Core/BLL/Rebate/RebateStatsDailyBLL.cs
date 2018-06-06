using HQ.Core.DAL.Rebate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Rebate
{
    public class RebateStatsDailyBLL
    {
        private readonly RebateStatsDailyDAL dal = new RebateStatsDailyDAL();
        private static RebateStatsDailyBLL instance = new RebateStatsDailyBLL();
        private RebateStatsDailyBLL()
        { }

        public static RebateStatsDailyBLL Instance
        {
            get
            {
                return instance;
            }
        }


        public decimal getYesterday(int userId)
        {
            return dal.getYesterday(userId);
        }
        /// <summary>
        /// 本周收益
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getWeek(int userId)
        {
            return dal.getWeek(userId);
        }

        /// <summary>
        /// 上周收益
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getLastWeek(int userId)
        {
            return dal.getLastWeek(userId);
        }
    }
}
