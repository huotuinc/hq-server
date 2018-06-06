using HQ.Common;
using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.User
{
    /// <summary>
    /// 用户等级逻辑层
    /// </summary>
    public class UserLevelBLL
    {
        private readonly UserLevelDAL dal = new UserLevelDAL();
        private static UserLevelBLL instance = new UserLevelBLL();
        private UserLevelBLL()
        { }

        public static UserLevelBLL Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 返回当前等级类型最大的LevelNo
        /// </summary>
        /// <param name="LevelType"></param>
        /// <returns></returns>
        public int GetLevelNo(int LevelType)
        {
            return dal.GetLevelNo(LevelType);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(UserLevelModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HQ.Model.UserLevelModel model)
        {
            return dal.Update(model);
        }
        /// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LevelId)
        {
            return dal.Delete(LevelId);
        }

        /// <summary>
        /// 获取等级列表
        /// </summary>
        /// <returns></returns>
        public List<UserLevelModel> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 用户升级（包括写用户变动日志）
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public bool UpgradeUser(int UserId)
        {
            try
            {
                int AscOrDesc = -1; //0 - 降级,1 - 升级,-1 不动
                List<UserLevelModel> Items = dal.GetList().Where(x => x.LevelModel == 1).ToList();
                int ToLevelId = GetLevelId(UserId, Items, out AscOrDesc);
                if (AscOrDesc != -1)
                {
                    UsersBLL.Instance.UpdateUserLevel(UserId, ToLevelId);

                    UserLevelModel LevelModel = Items.Where(x => x.LevelId == ToLevelId).ToList()[0];

                    UserLogsModel UserLog = new UserLogsModel();
                    UserLog.CreateTime = DateTime.Now;
                    UserLog.UserId = UserId;
                    if (AscOrDesc == 0)
                    {
                        UserLog.LogType = 0;
                        UserLog.Reamark = "用户降级成为"+LevelModel.LevelName;
                    }
                    else if (AscOrDesc == 1)
                    {
                        UserLog.LogType = 1;
                        UserLog.Reamark = "用户升级成为" + LevelModel.LevelName;
                    }
                    UserLogsBLL.Instance.Add(UserLog);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("UserLevelBLL---->UpgradeUser发生异常,异常信息：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 获得等级Id(返回-1则不升级)
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="AscOrDesc">升级还是降级(0-降级,1-升级,-1 不动)</param>
        /// <returns></returns>
        public int GetLevelId(int UserId, List<UserLevelModel> Items, out int AscOrDesc)
        {
            int ToLevelId = -1;
            AscOrDesc = -1;
            int MyMemberNum = UsersBLL.Instance.GetMyMemberNum(UserId);
            int MyBelongOneNum = UsersBLL.Instance.GetMyBelongOneBuddyNum(UserId);
            int MyBelongTwoNum = UsersBLL.Instance.GetMyBelongTwoBuddyNum(UserId);
            int MyMemberOrderNum = OrdersBLL.Instance.GetMyMemberOrderNum(UserId);

            #region 代理商
            List<UserLevelModel> AgentItems = Items.Where(x => x.LevelType == Enum.HQEnums.UserLevelTypeOptions.代理商).OrderBy(x => x.LevelNo).ToList();
            if (AgentItems.Count > 0)
            {
                foreach (UserLevelModel item in AgentItems)
                {
                    int BelongOneNum = -1;
                    foreach (UpgradeConditionModel model in item.UpgradeCondition)
                    {
                        if (model.ConditionKey == "BelongOneNum")
                        {
                            BelongOneNum = model.ConditionValue;
                        }
                    }
                    if (BelongOneNum > -1 && MyMemberNum >= BelongOneNum)
                    {
                        ToLevelId = item.LevelId;
                    }
                }
            }
            #endregion

            #region 运营商
            List<UserLevelModel> OperatorItems = Items.Where(x => x.LevelType == Enum.HQEnums.UserLevelTypeOptions.运营商).ToList();
            if (OperatorItems.Count > 0)
            {
                foreach (UserLevelModel item in OperatorItems)
                {
                    int BuddyBelongOne = -1;
                    int BuddyBelongTwo = -1;
                    int BelongOneOrderNum = -1;
                    foreach (UpgradeConditionModel model in item.UpgradeCondition)
                    {
                        if (model.ConditionKey == "BuddyBelongOne")
                        {
                            BuddyBelongOne = model.ConditionValue;
                        }
                        if (model.ConditionKey == "BuddyBelongTwo")
                        {
                            BuddyBelongTwo = model.ConditionValue;
                        }
                        if (model.ConditionKey == "BelongOneOrderNum")
                        {
                            BelongOneOrderNum = model.ConditionValue;
                        }
                    }
                    if ((MyBelongOneNum >= BuddyBelongOne && MyBelongTwoNum >= BuddyBelongTwo) || MyMemberOrderNum >= BelongOneOrderNum)
                    {
                        ToLevelId = item.LevelId;
                    }
                }
            }
            #endregion

            if (ToLevelId > -1)
            {
                UsersModel userInfo = UsersBLL.Instance.GetModel(UserId);

                UserLevelModel ToLevelModel = Items.Where(x => x.LevelId == ToLevelId).ToList()[0];

                UserLevelModel UserLevelModel = Items.Where(x => x.LevelId == userInfo.LevelId).ToList()[0];
                if (ToLevelModel.LevelType > UserLevelModel.LevelType)
                {
                    AscOrDesc = 1;
                }
                else if (ToLevelModel.LevelType == UserLevelModel.LevelType)
                {
                    if (ToLevelModel.LevelNo > UserLevelModel.LevelNo)
                    {
                        AscOrDesc = 1;
                    }
                    else if (ToLevelModel.LevelNo == UserLevelModel.LevelNo)
                    {
                        AscOrDesc = -1;
                    }
                    else
                    {
                        AscOrDesc = 0;
                    }
                }
                else
                {
                    AscOrDesc = 0;
                }
            }

            return ToLevelId;
        }

    }
}
