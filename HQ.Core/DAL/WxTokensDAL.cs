using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;

namespace HQ.DAL
{
    /// <summary>
    /// 微信token维护数据访问层
    /// </summary>
    public partial class WxTokensDAL
    {
        public WxTokensDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WxTokensModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_WxTokens(");
            strSql.Append("Token,BuildTime,TypeKey)");
            strSql.Append(" values (");
            strSql.Append("@Token,@BuildTime,@TypeKey)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Token", SqlDbType.VarChar,250),
                    new SqlParameter("@BuildTime", SqlDbType.DateTime),
                    new SqlParameter("@TypeKey", SqlDbType.SmallInt)};
            parameters[0].Value = model.Token;
            parameters[1].Value = model.BuildTime;
            parameters[2].Value = model.TypeKey;

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
        public bool Update(WxTokensModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_WxTokens set ");
            strSql.Append("Token=@Token,");
            strSql.Append("BuildTime=@BuildTime,");
            strSql.Append("TypeKey=@TypeKey");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Token", SqlDbType.VarChar,250),
                    new SqlParameter("@BuildTime", SqlDbType.DateTime),
                    new SqlParameter("@TypeKey", SqlDbType.SmallInt),
                    new SqlParameter("@Id", SqlDbType.Int, 4)};
            parameters[0].Value = model.Token;
            parameters[1].Value = model.BuildTime;
            parameters[2].Value = model.TypeKey;
            parameters[3].Value = model.Id;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_WxTokens ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

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
        public WxTokensModel GetModel(int TypeKey)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_WxTokens ");
            strSql.Append(" where TypeKey=@TypeKey ");
            SqlParameter[] parameters = {
                    new SqlParameter("@TypeKey", SqlDbType.Int,4)           };
            parameters[0].Value = TypeKey;

            WxTokensModel model = new WxTokensModel();
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
        public WxTokensModel DataRowToModel(DataRow row)
        {
            WxTokensModel model = new WxTokensModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Token"] != null)
                {
                    model.Token = row["Token"].ToString();
                }
                if (row["BuildTime"] != null && row["BuildTime"].ToString() != "")
                {
                    model.BuildTime = DateTime.Parse(row["BuildTime"].ToString());
                }
                if (row["TypeKey"].ToString() != "")
                {
                    model.TypeKey = Convert.ToInt16(row["TypeKey"]);
                }
            }
            return model;
        }

        #endregion  BasicMethod

    }
}

