using HQ.Common.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.DAL.Rebate
{
    public class RebateStatsDailyDAL
    {
        public RebateStatsDailyDAL() { }

        /// <summary>
        /// 昨日收益
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getYesterday(int userId)
        {
            DateTime dt = DateTime.Now.AddDays(-1).Date;
            string strsql = String.Format(@"select RebateAmount from HQ_Rebate_Stats_Daily where UserId={0} and StatDay='{1}'", userId, dt);
            Object obj = DbHelperSQL.GetSingle(strsql);
            if (obj != null)
            {
                return Decimal.Parse(obj.ToString());
            }
            return 0;
        }
        /// <summary>
        /// 本周收益
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getWeek(int userId)
        {
            DateTime dt = DateTime.Now;  //当前时间
            DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一

            string strsql = String.Format(@"select sum(RebateAmount) from HQ_Rebate_Stats_Daily where UserId={0} and StatDay>='{1}'"
                , userId, startWeek.ToString("yyyy-MM-dd"));
            Object obj = DbHelperSQL.GetSingle(strsql);
            if (obj != null)
            {
                return Decimal.Parse(obj.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 上周收益
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal getLastWeek(int userId)
        {
            DateTime dt = DateTime.Now;  //当前时间

            DateTime endWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
            DateTime startWeek = endWeek.AddDays(-7);//上周一
            string strsql = String.Format(@"select sum(RebateAmount) from HQ_Rebate_Stats_Daily where UserId={0} and StatDay>='{1}' and StatDay<'{2}'"
                , userId, startWeek.ToString("yyyy-MM-dd"), endWeek.ToString("yyyy-MM-dd"));
            Object obj = DbHelperSQL.GetSingle(strsql);
            if (obj != null)
            {
                return Decimal.Parse(obj.ToString());
            }
            return 0;
        }
    }
}
