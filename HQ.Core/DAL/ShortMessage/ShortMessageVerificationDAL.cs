using HQ.Common.DB;
using HQ.Core.Model.ShortMessage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace LM.Core.DAL
{
    /// <summary>
    /// 短信验证码数据访问层
    /// </summary>
    public class ShortMessageVerificationDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 判断是否通过验证
        /// </summary>
        /// <param name="verification"></param>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool IsPassVerify(string verification, string mobile)
        {
            string sql = string.Format("select count(1) from HQ_Sms_Verification where Verification='{0}' and IsInvalid=0 and Mobile='{1}' and DATEDIFF(SECOND,CreateTime,GETDATE()) < 900",
                verification, mobile);
            return DbHelperSQL.Exists(sql);
        }

        /// <summary>
        /// 添加或者更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddOrUpdate(ShortMessageVerificationModel model)
        {
            string sql = string.Format(@"if not exists(select * from HQ_Sms_Verification where Mobile='{0}')
                                        begin insert into HQ_Sms_Verification (Verification,CreateTime,IsInvalid,Mobile) 
                                        values('{1}',getdate(),{2},'{0}') end
                                        else begin update HQ_Sms_Verification set Verification='{1}',CreateTime=getdate(),
                                        IsInvalid={2} where Mobile='{0}' end",
                                        model.Mobile,
                                        model.Verification,
                                        model.IsInvalid);
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 更新为已失效
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public bool SetInvalid(string mobile)
        {
            string sql = string.Format("update HQ_Sms_Verification set IsInvalid=1 where Mobile='{0}'", mobile);
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShortMessageVerificationModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Sms_Verification(");
            strSql.Append("Verification,CreateTime,IsInvalid,Mobile)");
            strSql.Append(" values (");
            strSql.Append("@Verification,@CreateTime,@IsInvalid,@Mobile)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Verification", SqlDbType.VarChar,7),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsInvalid", SqlDbType.SmallInt,2),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,11)};
            parameters[0].Value = model.Verification;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.IsInvalid;
            parameters[3].Value = model.Mobile;

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
        public bool Update(ShortMessageVerificationModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Sms_Verification set ");
            strSql.Append("Verification=@Verification,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("IsInvalid=@IsInvalid,");
            strSql.Append("Mobile=@Mobile");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Verification", SqlDbType.VarChar,7),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@IsInvalid", SqlDbType.SmallInt,2),
                    new SqlParameter("@Mobile", SqlDbType.VarChar,11),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Verification;
            parameters[1].Value = model.CreateTime;
            parameters[2].Value = model.IsInvalid;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Id;

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
            strSql.Append("delete from HQ_Sms_Verification ");
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
        public ShortMessageVerificationModel GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Sms_Verification ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            ShortMessageVerificationModel model = new ShortMessageVerificationModel();
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
        public ShortMessageVerificationModel DataRowToModel(DataRow row)
        {
            ShortMessageVerificationModel model = new ShortMessageVerificationModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Verification"] != null)
                {
                    model.Verification = row["Verification"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["IsInvalid"] != null && row["IsInvalid"].ToString() != "")
                {
                    model.IsInvalid = int.Parse(row["IsInvalid"].ToString());
                }
                if (row["Mobile"] != null)
                {
                    model.Mobile = row["Mobile"].ToString();
                }
            }
            return model;
        }

        #endregion  BasicMethod
    }
}
