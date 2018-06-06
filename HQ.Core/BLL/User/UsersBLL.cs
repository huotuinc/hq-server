using HQ.Core.BLL.Rebate;
using HQ.Core.Model.User;
using HQ.Core.ViewModel.User;
using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户逻辑层
    /// </summary>
    public class UsersBLL
    {
        private readonly UsersDAL dal = new UsersDAL();
        private static UsersBLL instance = new UsersBLL();
        private UsersBLL()
        { }

        public static UsersBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UsersModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UsersModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId)
        {
            return dal.Delete(UserId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel GetModel(int UserId)
        {
            return dal.GetModel(UserId);
        }

        /// <summary>
        /// 根据用户token获取用户
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public UsersModel GetModelByToken(string userToken)
        {
            return dal.GetModelByToken(userToken);
        }
        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="iPageSize"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="iRecordCount"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetList(int pageSize, int pageIndex, out int recordCount, UsersSearchCondition condition)
        {
            return dal.GetList(pageSize, pageIndex, out recordCount, condition);
        }

        /// <summary>
        /// 获取我当前的下线人数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int GetMyMemberNum(int UserId)
        {
            return dal.GetMyMemberNum(UserId);
        }
        #endregion  BasicMethod


        /// <summary>
        /// 我的团队
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MyTeamView MyTeams(int userId, int pageIndex, int pageSize)
        {
            MyTeamView team = new MyTeamView();

            List<UsersModel> users = dal.listBelongOne(userId, pageIndex, pageSize);
            if (users.Count > 0)
            {
                List<MyTeamDevoteView> list = new List<MyTeamDevoteView>();
                String ids = "";
                users.ForEach(item =>
                {
                    ids += item.UserId + ",";
                    MyTeamDevoteView view = new MyTeamDevoteView();
                    view.userId = item.UserId;
                    //todo
                    view.head = item.WxHeadImg;
                    view.mobile = item.LoginName;
                    view.date = item.RegTime.Value.ToString("yyyy-MM-dd");
                    view.inviteCode = item.InviteCode;
                    list.Add(view);

                });
                if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);

                //获取贡献值
                List<MyTeamDevoteView> devotes = RebatesBLL.Instance.countDevote(userId, ids);
                list.ForEach(item =>
                {
                    MyTeamDevoteView devote = devotes.Find(d => { return d.userId == item.userId; });
                    if (devote != null)
                    {
                        item.devote = devote.devote;
                    }
                    else {
                        item.devote = 0;
                    }
                });
                team.devote = list;
            }

            List<MyTeamNumView> nums = new List<MyTeamNumView>();
            MyTeamNumView num = new MyTeamNumView();
            num.type = "一级团队";
            num.total = dal.GetMyMemberNum(userId);
            num.today = dal.GetMyMemberNumToday(userId);
            num.month = dal.GetMyMemberNumMonth(userId);
            nums.Add(num);

            num = new MyTeamNumView();
            num.type = "二级团队";
            num.total = dal.GetMyBelongTowNum(userId);
            num.today = dal.GetMyBelongTowNumToday(userId);
            num.month = dal.GetMyBelongTowNumMonth(userId);
            nums.Add(num);
            team.nums = nums;
            return team;
        }

        public List<UsersModel> listByIds(String ids)
        {
            return dal.listByIds(ids);
        }


        public MyProfitView myProfit(int userId)
        {
            MyProfitView view = new MyProfitView();
            view.today = RebatesBLL.Instance.countTodayFinalMoney(userId);
            view.yesterday = RebateStatsDailyBLL.Instance.getYesterday(userId);
            view.week = RebateStatsDailyBLL.Instance.getWeek(userId);
            view.lastWeek = RebateStatsDailyBLL.Instance.getLastWeek(userId);
            view.month = RebateStatsMonthlyBLL.Instance.getMonth(userId);
            view.lastMonth = RebateStatsMonthlyBLL.Instance.getLastMonth(userId);
            return view;
        }
    }
}
