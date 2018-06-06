using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.User
{
    public class MyTeamView
    {
        public List<MyTeamNumView> nums { get; set; }//推手数量

        public List<MyTeamDevoteView> devote { get; set; }//直接推手贡献
    }

    public class MyTeamNumView
    {
        public string type { get; set; }//团队级别：一级团队，二级团队
        public int total { get; set; }//总人数
        public int today { get; set; }//今日人数
        public int month { get; set; }//本月人数
    }

    public class MyTeamDevoteView
    {
        public int userId { get; set; }//贡献用户id
        public string head { get; set; }//用户头像
        public string mobile { get; set; }//手机号
        public string date { get; set; }//注册日期
        public string inviteCode { get; set; }//邀请码
        public decimal devote { get; set; }//预估贡献钻
    }

}
