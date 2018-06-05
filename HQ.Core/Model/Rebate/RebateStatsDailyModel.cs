using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model.Rebate
{
    public class RebateStatsDailyModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal RebateAmount { get; set; }
        public Int16 RebateType { get;  set; }

        public DateTime StatDay { get; set; }
    }
}
