using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 基础配置数据访问层
    /// </summary>
    public partial class BaseConfigDAL
    {
        public BaseConfigDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(HQ.Model.BaseConfigModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_BaseConfig(");
            strSql.Append("WxAppId,WxAppSecret,RebateMode,RebateSetting,SmsSetting,MainDomain)");
            strSql.Append(" values (");
            strSql.Append("@WxAppId,@WxAppSecret,@RebateMode,@RebateSetting,@SmsSetting,@MainDomain)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@WxAppId", SqlDbType.VarChar,40),
                    new SqlParameter("@WxAppSecret", SqlDbType.VarChar,50),
                    new SqlParameter("@RebateMode", SqlDbType.SmallInt,2),
                    new SqlParameter("@RebateSetting", SqlDbType.VarChar,-1),
                    new SqlParameter("@SmsSetting", SqlDbType.VarChar,-1),
                    new SqlParameter("@MainDomain", SqlDbType.VarChar,50)};
            parameters[0].Value = model.WxAppId;
            parameters[1].Value = model.WxAppSecret;
            parameters[2].Value = model.RebateMode;
            parameters[3].Value = model.RebateSetting;
            parameters[4].Value = model.SmsSetting;
            parameters[5].Value = model.MainDomain;

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
        public bool Update(HQ.Model.BaseConfigModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_BaseConfig set ");
            strSql.Append("WxAppId=@WxAppId,");
            strSql.Append("WxAppSecret=@WxAppSecret,");
            strSql.Append("RebateMode=@RebateMode,");
            strSql.Append("RebateSetting=@RebateSetting,");
            strSql.Append("SmsSetting=@SmsSetting,");
            strSql.Append("MainDomain=@MainDomain");
            strSql.Append(" where ConfigId=@ConfigId");
            SqlParameter[] parameters = {
                    new SqlParameter("@WxAppId", SqlDbType.VarChar,40),
                    new SqlParameter("@WxAppSecret", SqlDbType.VarChar,50),
                    new SqlParameter("@RebateMode", SqlDbType.SmallInt,2),
                    new SqlParameter("@RebateSetting", SqlDbType.VarChar,-1),
                    new SqlParameter("@SmsSetting", SqlDbType.VarChar,-1),
                    new SqlParameter("@MainDomain", SqlDbType.VarChar,50),
                    new SqlParameter("@ConfigId", SqlDbType.Int,4)};
            parameters[0].Value = model.WxAppId;
            parameters[1].Value = model.WxAppSecret;
            parameters[2].Value = model.RebateMode;
            parameters[3].Value = model.RebateSetting;
            parameters[4].Value = model.SmsSetting;
            parameters[5].Value = model.MainDomain;
            parameters[6].Value = model.ConfigId;

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
        public bool Delete(int ConfigId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_BaseConfig ");
            strSql.Append(" where ConfigId=@ConfigId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConfigId", SqlDbType.Int,4)
            };
            parameters[0].Value = ConfigId;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string ConfigIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_BaseConfig ");
            strSql.Append(" where ConfigId in (" + ConfigIdlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public HQ.Model.BaseConfigModel GetModel(int ConfigId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ConfigId,WxAppId,WxAppSecret,RebateMode,RebateSetting,SmsSetting,MainDomain from HQ_BaseConfig ");
            strSql.Append(" where ConfigId=@ConfigId");
            SqlParameter[] parameters = {
                    new SqlParameter("@ConfigId", SqlDbType.Int,4)
            };
            parameters[0].Value = ConfigId;

            HQ.Model.BaseConfigModel model = new HQ.Model.BaseConfigModel();
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
        public HQ.Model.BaseConfigModel DataRowToModel(DataRow row)
        {
            HQ.Model.BaseConfigModel model = new HQ.Model.BaseConfigModel();
            if (row != null)
            {
                if (row["ConfigId"] != null && row["ConfigId"].ToString() != "")
                {
                    model.ConfigId = int.Parse(row["ConfigId"].ToString());
                }
                if (row["WxAppId"] != null)
                {
                    model.WxAppId = row["WxAppId"].ToString();
                }
                if (row["WxAppSecret"] != null)
                {
                    model.WxAppSecret = row["WxAppSecret"].ToString();
                }
                if (row["RebateMode"] != null && row["RebateMode"].ToString() != "")
                {
                    model.RebateMode = int.Parse(row["RebateMode"].ToString());
                }
                if (row["RebateSetting"] != null)
                {
                    model.RebateSetting = row["RebateSetting"].ToString();
                }
                if (row["SmsSetting"] != null)
                {
                    model.SmsSetting = row["SmsSetting"].ToString();
                }
                if (row["MainDomain"] != null)
                {
                    model.MainDomain = row["MainDomain"].ToString();
                }
            }
            return model;
        }
        
        #endregion  BasicMethod

    }
}

