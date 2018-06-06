using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.User
{
    public class MyProfitView
    {
        public decimal count { get; set; }//总累计收益

        public decimal today { get; set; }//今日预估
        public decimal yesterday { get; set; }//昨日预估
        public decimal week { get; set; }//本周预估
        public decimal lastWeek { get; set; }//上周预估
        public decimal month { get; set; }//本月预估
        public decimal lastMonth { get; set; }//上月预估
        public List<MyProfitTrendsView> trends { get; set; }//走势

    }

    public class MyProfitTrendsView
    {
        public string date { get; set; }//日期
        public decimal value { get; set; }//当日预估钻
    }
}
