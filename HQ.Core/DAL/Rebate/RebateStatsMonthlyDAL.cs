using HQ.Common.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.DAL.Rebate
{
    public class RebateStatsMonthlyDAL
    {

        /// <summary>
        /// 获得本月
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getMonth(int userId)
        {
            DateTime dt = DateTime.Now;  //当前时间

            DateTime startMonth = dt.AddDays(1 - dt.Day);

            string strsql = String.Format(@"select sum(RebateAmount) from HQ_Rebate_Stats_Monthly where UserId={0} and StatMonth>='{1}'"
                , userId, startMonth.ToString("yyyy-MM-dd"));
            Object obj = DbHelperSQL.GetSingle(strsql);
            if (obj != null)
            {
                return Decimal.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 获得上月
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getLastMonth(int userId)
        {
            DateTime dt = DateTime.Now;  //当前时间

            DateTime endMonth = dt.AddDays(1 - dt.Day);
            DateTime startMonth = endMonth.AddMonths(-1);
            string strsql = String.Format(@"select sum(RebateAmount) from HQ_Rebate_Stats_Monthly where UserId={0} and StatMonth>='{1}' and StatMonth<'{2}'"
                , userId, startMonth.ToString("yyyy-MM-dd"), endMonth.ToString("yyyy-MM-dd"));
            Object obj = DbHelperSQL.GetSingle(strsql);
            if (obj != null)
            {
                return Decimal.Parse(obj.ToString());
            }
            return 0;
        }
    }
}
