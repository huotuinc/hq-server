using HQ.Common.DB;
using HQ.Core.Model.SystemConfig;
using HQ.Core.ViewModel.SearchCondition;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.DAL.SystemConfig
{
    /// <summary>
    /// 管理员数据访问层
    /// </summary>
    public class ManagerDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string loginName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from HQ_Manager");
            strSql.Append(" where LoginName=@LoginName and Password=@Password");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar)
            };
            parameters[0].Value = loginName;
            parameters[1].Value = password;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsEffect(string loginName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from HQ_Manager");
            strSql.Append(" where LoginName=@LoginName and Password=@Password and IsLocked=0");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar)
            };
            parameters[0].Value = loginName;
            parameters[1].Value = password;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public ManagerModel GetModel(string loginName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from HQ_Manager");
            strSql.Append(" where LoginName=@LoginName and Password=@Password");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar),
                    new SqlParameter("@Password", SqlDbType.VarChar)
            };
            parameters[0].Value = loginName;
            parameters[1].Value = password;
            DataTable dt = DbHelperSQL.Query(strSql.ToString(), parameters).Tables[0];
            if (dt.Rows.Count == 0) return null;
            return this.DataRowToModel(dt.Rows[0]);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ManagerModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Manager(");
            strSql.Append("LoginName,Password,LastLoginTime,LastLoginIp,CreateTime,IsLocked,Remark,IsSuper,AuthMenus,AuthFuncs)");
            strSql.Append(" values (");
            strSql.Append("@LoginName,@Password,@LastLoginTime,@LastLoginIp,@CreateTime,@IsLocked,@Remark,@IsSuper,@AuthMenus,@AuthFuncs)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LastLoginIp", SqlDbType.VarChar,30),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsLocked", SqlDbType.SmallInt,2),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@IsSuper", SqlDbType.Bit),
                    new SqlParameter("@AuthMenus", SqlDbType.Text),
                    new SqlParameter("@AuthFuncs", SqlDbType.Text)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.LastLoginTime;
            parameters[3].Value = model.LastLoginIp;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.IsLocked;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.IsSuper;
            parameters[8].Value = model.AuthMenus;
            parameters[9].Value = model.AuthFuncs;

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

        public void UpdatePassword(string loginName, string md5password)
        {
            string sql = string.Format("UPDATE HQ_Manager SET Password='{0}' WHERE LoginName='{1}'", md5password, loginName);
            DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ManagerModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Manager set ");
            strSql.Append("LoginName=@LoginName,");
            strSql.Append("Password=@Password,");
            strSql.Append("LastLoginTime=@LastLoginTime,");
            strSql.Append("LastLoginIp=@LastLoginIp,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("IsLocked=@IsLocked,");
            strSql.Append("Remark=@Remark,");
            strSql.Append("IsSuper=@IsSuper,");
            strSql.Append("AuthMenus=@AuthMenus,");
            strSql.Append("AuthFuncs=@AuthFuncs");
            strSql.Append(" where ManagerId=@ManagerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar,50),
                    new SqlParameter("@Password", SqlDbType.VarChar,50),
                    new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
                    new SqlParameter("@LastLoginIp", SqlDbType.VarChar,30),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsLocked", SqlDbType.SmallInt,2),
                    new SqlParameter("@Remark", SqlDbType.VarChar,200),
                    new SqlParameter("@IsSuper", SqlDbType.Bit),
                    new SqlParameter("@AuthMenus", SqlDbType.Text),
                    new SqlParameter("@AuthFuncs", SqlDbType.Text),
                    new SqlParameter("@ManagerId", SqlDbType.Int,4)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.LastLoginTime;
            parameters[3].Value = model.LastLoginIp;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.IsLocked;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.IsSuper;
            parameters[8].Value = model.AuthMenus;
            parameters[9].Value = model.AuthFuncs;
            parameters[10].Value = model.ManagerId;

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
        public bool Delete(int ManagerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Manager ");
            strSql.Append(" where ManagerId=@ManagerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ManagerId", SqlDbType.Int,4)
            };
            parameters[0].Value = ManagerId;

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
        public ManagerModel GetModel(int ManagerId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Manager ");
            strSql.Append(" where ManagerId=@ManagerId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ManagerId", SqlDbType.Int,4)
            };
            parameters[0].Value = ManagerId;

            ManagerModel model = new ManagerModel();
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
        public ManagerModel DataRowToModel(DataRow row)
        {
            ManagerModel model = new ManagerModel();
            if (row != null)
            {
                if (row["ManagerId"] != null && row["ManagerId"].ToString() != "")
                {
                    model.ManagerId = int.Parse(row["ManagerId"].ToString());
                }
                if (row["LoginName"] != null)
                {
                    model.LoginName = row["LoginName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["LastLoginTime"] != null && row["LastLoginTime"].ToString() != "")
                {
                    model.LastLoginTime = DateTime.Parse(row["LastLoginTime"].ToString());
                }
                if (row["LastLoginIp"] != null)
                {
                    model.LastLoginIp = row["LastLoginIp"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["IsLocked"] != null && row["IsLocked"].ToString() != "")
                {
                    model.IsLocked = bool.Parse(row["IsLocked"].ToString());
                }
                if (row["Remark"] != null)
                {
                    model.Remark = row["Remark"].ToString();
                }
                if (row["IsSuper"] != null && row["IsSuper"].ToString() != "")
                {
                    model.IsSuper = bool.Parse(row["IsSuper"].ToString());
                }

                model.AuthMenus = row["AuthMenus"].ToString();
                model.AuthFuncs = row["AuthFuncs"].ToString();
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
        public DataTable GetList(int iPageSize, int iPageIndex, out int iRecordCount, ManagerSearchCondition condition)
        {
            StringBuilder sbSqlwhere = new StringBuilder();
            if (!String.IsNullOrEmpty(condition.LoginName))
            {
                sbSqlwhere.AppendFormat(" AND LoginName LIKE '%{0}%'", condition.LoginName.Replace("'", ""));
            }
            if (condition.FilterSuper)
            {
                sbSqlwhere.Append(" AND IsSuper=0");
            }
            return this.GetList(iPageSize, iPageIndex, sbSqlwhere.ToString(), out iRecordCount);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="iPageSize"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="iRecordCount"></param>
        /// <returns></returns>
        private DataTable GetList(int iPageSize, int iPageIndex, string strWhere, out int iRecordCount)
        {
            string sql = "select * FROM HQ_Manager where 1=1 ";
            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }
            sql += " ORDER BY ManagerId DESC";
            return DbHelperSQL.GetSplitDataTable(sql, iPageSize, iPageIndex, out iRecordCount);
        }

        public bool ExistsLoginName(string loginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HQ_Manager");
            strSql.Append(" where LoginName=@LoginName");
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName", SqlDbType.VarChar)
            };
            parameters[0].Value = loginName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        #endregion  BasicMethod
    }
}
