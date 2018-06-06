using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;
using HQ.Core.Model.User;
using System.Collections.Generic;
using Micro.Mall.Core.Model;
using Micro.Mall.Core.DAL;
using HQ.Common;

namespace HQ.DAL
{
    /// <summary>
    /// 用户数据访问层
    /// </summary>
    public partial class UsersDAL
    {
        public UsersDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HQ.Model.UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Users(");
            strSql.Append("LevelId,WxNickName,WxHeadImg,RegTime,LoginName,Password,AgentId,IsAgentProxy,BelongOneId,BelongTwoId,BelongThreeId,Balance,LockBalance,TotalRebate,PromotionId,PromotionExtId,RealName,IsLocked,Token,InviteCode)");
            strSql.Append(" values (");
            strSql.Append("@LevelId,@WxNickName,@WxHeadImg,@RegTime,@LoginName,@Password,@AgentId,@IsAgentProxy,@BelongOneId,@BelongTwoId,@BelongThreeId,@Balance,@LockBalance,@TotalRebate,@PromotionId,@PromotionExtId,@RealName,@IsLocked,@Token,@InviteCode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LevelId", SqlDbType.Int,4),
                    new SqlParameter("@WxNickName", SqlDbType.NVarChar,40),
                    new SqlParameter("@WxHeadImg", SqlDbType.VarChar,150),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@Password", SqlDbType.VarChar,40),
                    new SqlParameter("@AgentId", SqlDbType.Int,4),
                    new SqlParameter("@IsAgentProxy", SqlDbType.TinyInt,1),
                    new SqlParameter("@BelongOneId", SqlDbType.Int,4),
                    new SqlParameter("@BelongTwoId", SqlDbType.Int,4),
                    new SqlParameter("@BelongThreeId", SqlDbType.Int,4),
                    new SqlParameter("@Balance", SqlDbType.Decimal,5),
                    new SqlParameter("@LockBalance", SqlDbType.Decimal,5),
                    new SqlParameter("@TotalRebate", SqlDbType.Decimal,5),
                    new SqlParameter("@PromotionId", SqlDbType.VarChar,20),
                    new SqlParameter("@PromotionExtId", SqlDbType.VarChar,30),
                    new SqlParameter("@RealName", SqlDbType.VarChar,30),
                    new SqlParameter("@IsLocked", SqlDbType.TinyInt,1),
                    new SqlParameter("@Token", SqlDbType.VarChar,40),
                    new SqlParameter("@InviteCode", SqlDbType.VarChar,20)};
            parameters[0].Value = model.LevelId;
            parameters[1].Value = model.WxNickName;
            parameters[2].Value = model.WxHeadImg;
            parameters[3].Value = model.RegTime;
            parameters[4].Value = model.LoginName;
            parameters[5].Value = model.Password;
            parameters[6].Value = model.AgentId;
            parameters[7].Value = model.IsAgentProxy;
            parameters[8].Value = model.BelongOneId;
            parameters[9].Value = model.BelongTwoId;
            parameters[10].Value = model.BelongThreeId;
            parameters[11].Value = model.Balance;
            parameters[12].Value = model.LockBalance;
            parameters[13].Value = model.TotalRebate;
            parameters[14].Value = model.PromotionId;
            parameters[15].Value = model.PromotionExtId;
            parameters[16].Value = model.RealName;
            parameters[17].Value = model.IsLocked;
            parameters[18].Value = model.Token;
            parameters[19].Value = model.InviteCode;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HQ.Model.UsersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Users set ");
            strSql.Append("LevelId=@LevelId,");
            strSql.Append("WxNickName=@WxNickName,");
            strSql.Append("WxHeadImg=@WxHeadImg,");
            strSql.Append("RegTime=@RegTime,");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("Password=@Password,");
            strSql.Append("AgentId=@AgentId,");
            strSql.Append("IsAgentProxy=@IsAgentProxy,");
            strSql.Append("BelongOneId=@BelongOneId,");
            strSql.Append("BelongTwoId=@BelongTwoId,");
            strSql.Append("BelongThreeId=@BelongThreeId,");
            strSql.Append("Balance=@Balance,");
            strSql.Append("LockBalance=@LockBalance,");
            strSql.Append("TotalRebate=@TotalRebate,");
            strSql.Append("PromotionId=@PromotionId,");
            strSql.Append("PromotionExtId=@PromotionExtId,");
            strSql.Append("RealName=@RealName,");
            strSql.Append("IsLocked=@IsLocked,");
            strSql.Append("Token=@Token,");
            strSql.Append("InviteCode=@InviteCode");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LevelId", SqlDbType.Int,4),
                    new SqlParameter("@WxNickName", SqlDbType.NVarChar,40),
                    new SqlParameter("@WxHeadImg", SqlDbType.VarChar,150),
                    new SqlParameter("@RegTime", SqlDbType.DateTime),
                    new SqlParameter("@LoginName", SqlDbType.VarChar,20),
                    new SqlParameter("@Password", SqlDbType.VarChar,40),
                    new SqlParameter("@AgentId", SqlDbType.Int,4),
                    new SqlParameter("@IsAgentProxy", SqlDbType.TinyInt,1),
                    new SqlParameter("@BelongOneId", SqlDbType.Int,4),
                    new SqlParameter("@BelongTwoId", SqlDbType.Int,4),
                    new SqlParameter("@BelongThreeId", SqlDbType.Int,4),
                    new SqlParameter("@Balance", SqlDbType.Decimal,5),
                    new SqlParameter("@LockBalance", SqlDbType.Decimal,5),
                    new SqlParameter("@TotalRebate", SqlDbType.Decimal,5),
                    new SqlParameter("@PromotionId", SqlDbType.VarChar,20),
                    new SqlParameter("@PromotionExtId", SqlDbType.VarChar,30),
                    new SqlParameter("@RealName", SqlDbType.VarChar,30),
                    new SqlParameter("@IsLocked", SqlDbType.TinyInt,1),
                    new SqlParameter("@Token", SqlDbType.VarChar,40),
                    new SqlParameter("@InviteCode", SqlDbType.VarChar,20),
                    new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.LevelId;
            parameters[1].Value = model.WxNickName;
            parameters[2].Value = model.WxHeadImg;
            parameters[3].Value = model.RegTime;
            parameters[4].Value = model.LoginName;
            parameters[5].Value = model.Password;
            parameters[6].Value = model.AgentId;
            parameters[7].Value = model.IsAgentProxy;
            parameters[8].Value = model.BelongOneId;
            parameters[9].Value = model.BelongTwoId;
            parameters[10].Value = model.BelongThreeId;
            parameters[11].Value = model.Balance;
            parameters[12].Value = model.LockBalance;
            parameters[13].Value = model.TotalRebate;
            parameters[14].Value = model.PromotionId;
            parameters[15].Value = model.PromotionExtId;
            parameters[16].Value = model.RealName;
            parameters[17].Value = model.IsLocked;
            parameters[18].Value = model.Token;
            parameters[19].Value = model.InviteCode;
            parameters[20].Value = model.UserId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Users ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Users ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserId", SqlDbType.Int,4)
            };
            parameters[0].Value = UserId;

            HQ.Model.UsersModel model = new HQ.Model.UsersModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户token获取用户
        /// </summary>
        /// <param name="userToken"></param>
        /// <returns></returns>
        public UsersModel GetModelByToken(string userToken)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Users ");
            strSql.Append(" where UserToken=@UserToken");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserToken", SqlDbType.VarChar,50)
            };
            parameters[0].Value = userToken;

            HQ.Model.UsersModel model = new HQ.Model.UsersModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UsersModel DataRowToModel(DataRow row)
        {
            HQ.Model.UsersModel model = new HQ.Model.UsersModel();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["LevelId"] != null && row["LevelId"].ToString() != "")
                {
                    model.LevelId = int.Parse(row["LevelId"].ToString());
                }
                if (row["WxNickName"] != null)
                {
                    model.WxNickName = row["WxNickName"].ToString();
                }
                if (row["WxHeadImg"] != null)
                {
                    model.WxHeadImg = row["WxHeadImg"].ToString();
                }
                if (row["RegTime"] != null && row["RegTime"].ToString() != "")
                {
                    model.RegTime = DateTime.Parse(row["RegTime"].ToString());
                }
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["AgentId"] != null && row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["IsAgentProxy"] != null && row["IsAgentProxy"].ToString() != "")
                {
                    model.IsAgentProxy = int.Parse(row["IsAgentProxy"].ToString());
                }
                if (row["BelongOneId"] != null && row["BelongOneId"].ToString() != "")
                {
                    model.BelongOneId = int.Parse(row["BelongOneId"].ToString());
                }
                if (row["BelongTwoId"] != null && row["BelongTwoId"].ToString() != "")
                {
                    model.BelongTwoId = int.Parse(row["BelongTwoId"].ToString());
                }
                if (row["BelongThreeId"] != null && row["BelongThreeId"].ToString() != "")
                {
                    model.BelongThreeId = int.Parse(row["BelongThreeId"].ToString());
                }
                if (row["Balance"] != null && row["Balance"].ToString() != "")
                {
                    model.Balance = decimal.Parse(row["Balance"].ToString());
                }
                if (row["LockBalance"] != null && row["LockBalance"].ToString() != "")
                {
                    model.LockBalance = decimal.Parse(row["LockBalance"].ToString());
                }
                if (row["TotalRebate"] != null && row["TotalRebate"].ToString() != "")
                {
                    model.TotalRebate = decimal.Parse(row["TotalRebate"].ToString());
                }
                if (row["PromotionId"] != null)
                {
                    model.PromotionId = row["PromotionId"].ToString();
                }
                if (row["PromotionExtId"] != null)
                {
                    model.PromotionExtId = row["PromotionExtId"].ToString();
                }
                if (row["RealName"] != null)
                {
                    model.RealName = row["RealName"].ToString();
                }
                if (row["IsLocked"] != null && row["IsLocked"].ToString() != "")
                {
                    model.IsLocked = int.Parse(row["IsLocked"].ToString());
                }
                if (row["Token"] != null)
                {
                    model.Token = row["Token"].ToString();
                }
                if (row["InviteCode"] != null)
                {
                    model.InviteCode = row["InviteCode"].ToString();
                }
            }
            return model;
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
            StringBuilder sbSqlwhere = new StringBuilder();
            if (!String.IsNullOrEmpty(condition.LoginName))
            {
                sbSqlwhere.AppendFormat(" AND LoginName LIKE '%{0}%'", condition.LoginName.Replace("'", ""));
            }
            //更多查询条件....
            return this.GetList(pageSize, pageIndex, sbSqlwhere.ToString(), out recordCount);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="iPageSize"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="iRecordCount"></param>
        /// <returns></returns>
        private DataTable GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            string sql = "select * FROM HQ_Users where 1=1 ";
            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }
            sql += " ORDER BY UserId DESC";
            return DbHelperSQL.GetSplitDataTable(sql, pageSize, pageIndex, out recordCount);
        }

        /// <summary>
        /// 获取该等级是否有用户存在
        /// </summary>
        /// <param name="LevelId">等级Id</param>
        /// <returns></returns>
        public int CountUserNumByLevelId(int LevelId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where LevelId={0})", LevelId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获取我当前的下线人数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int GetMyMemberNum(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongOneId={0}", UserId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获取我当前的下线人数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int GetMyBelongOneBuddyNum(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongOneId={0} and LevelId in(select LevelId from HQ_User_Level where LevelType=1)", UserId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 获取我当前的下线人数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int GetMyBelongTwoBuddyNum(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongTwoId={0} and LevelId in(select LevelId from HQ_User_Level where LevelType=1)", UserId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 更新用户等级
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="ToLevelId">等级Id</param>
        /// <returns></returns>
        public bool UpdateUserLevel(int UserId, int ToLevelId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("UPDATE dbo.HQ_Users SET LevelId={0} WHERE UserId={1}", ToLevelId,UserId);
            return DbHelperSQL.ExecuteSql(strSql.ToString())>0;
        }

        public int GetMyBelongTowNum(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongTwoId={0}", UserId);
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetMyMemberNumToday(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongOneId={0} and RegTime>='{1}'", UserId, DateTime.Now.ToString("yyyy-MM-dd"));
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetMyBelongTowNumToday(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongTwoId={0} and RegTime>='{1}'", UserId, DateTime.Now.ToString("yyyy-MM-dd"));
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }


        public int GetMyMemberNumMonth(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongOneId={0} and RegTime>='{1}'", UserId, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd"));
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public int GetMyBelongTowNumMonth(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from HQ_Users where BelongTwoId={0} and RegTime>='{1}'", UserId, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd"));
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        #endregion  BasicMethod

        /// <summary>
        /// 按ids查询用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<UsersModel> listByIds(String ids)
        {
            List<UsersModel> list = new List<UsersModel>();
            string strsql = String.Format(@"SELECT *  from HQ_Users where  UserId in ({0})", ids);
            using (IDataReader dr = DbHelperSQL.ExecuteReader(strsql))
            {
                list = DbHelperSQL.GetEntityList<UsersModel>(dr);
            }
            return list;
        }


        public List<UsersModel> listBelongOne(int userId, int pageIndex, int pageSize)
        {
            string sqlWhere = "BelongOneId=" + userId;
            //if (sqlWhere.Length > 0) sqlWhere = sqlWhere.Substring(4);
            //初始化分页
            PagingModel paging = new PagingModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = 0,
                PageCount = 0
            };
            PageQueryModel pageQuery = new PageQueryModel()
            {
                TableName = "HQ_Users with(nolock)",
                Fields = "*",
                OrderField = "UserId desc",
                SqlWhere = sqlWhere
            };

            List<UsersModel> list = new CommonPageDAL().GetPageData<UsersModel>(ConfigHelper.MssqlDBConnectionString_Sync, pageQuery, paging);
            return list;

        }

    }
}

