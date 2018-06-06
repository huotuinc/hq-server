using HQ.Core.BLL.User;
using HQ.Core.ViewModel.User;
using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Rebate
{
   public class RebatesBLL
    {
        private readonly RebatesDAL dal = new RebatesDAL();
        private static RebatesBLL instance = new RebatesBLL();
        private RebatesBLL()
        { }

        public static RebatesBLL Instance
        {
            get
            {
                return instance;
            }
        }

        public List<MyTeamDevoteView> listDevote(int userId)
        {
            List<MyTeamDevoteView> list = dal.listDevote(userId);
            if (list.Count > 0)
            {
                String ids = "";
                list.ForEach(item =>
                {
                    ids += item.userId + ",";
                });
                if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);

                List<UsersModel> users = UsersBLL.Instance.listByIds(ids);
                users.ForEach(item =>
                {
                    MyTeamDevoteView view = list.Find(d => { return d.userId == item.UserId; });
                    if (view != null)
                    {
                        //todo
                        view.head = item.WxHeadImg;
                        view.mobile = item.LoginName;
                        view.date = item.RegTime.Value.ToString("yyyy-MM-dd");
                        view.inviteCode = item.InviteCode;
                    }
                });

            }
            return list;
        }

        public List<MyTeamDevoteView> countDevote(int userId, string contribUserIds)
        {
            return dal.countDevote(userId,contribUserIds);
        }

        public decimal countTodayFinalMoney(int userId)
        {
            return dal.countTodayFinalMoney(userId);
        }
    }
}
