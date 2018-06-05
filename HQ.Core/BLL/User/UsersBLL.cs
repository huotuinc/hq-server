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
        #endregion  BasicMethod


        /// <summary>
        /// 我的团队
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MyTeamView MyTeams(int userId)
        {
            MyTeamView view = new MyTeamView();
            view.devote = RebatesBLL.Instance.listDevote(userId);
            //view.nums = ;
            return view;
        }

        public List<UsersModel> listByIds(String ids)
        {
            return dal.listByIds(ids);
        }
    }
}
