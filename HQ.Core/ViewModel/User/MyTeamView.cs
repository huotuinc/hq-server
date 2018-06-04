using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.User
{
    public class MyTeamView
    {
        List<MyTeamNumView> nums { get; set; }//推手数量

        List<MyTeamDevoteView> devote { get; set; }//直接推手贡献
    }

    public class MyTeamNumView
    {
        public string type { get; set; }//类型：推荐总监，直接推手，直接推手下级
        public int total { get; set; }//总人数
        public int today { get; set; }//今日人数
        public int month { get; set; }//本月人数
    }

    public class MyTeamDevoteView
    {
        public string head { get; set; }//用户头像
        public string mobile { get; set; }//手机号
        public string date { get; set; }//日期
        public string inviteCode { get; set; }//邀请码
        public decimal devote { get; set; }//预估贡献钻
    }

}
