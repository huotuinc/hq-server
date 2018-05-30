using HQ.Common.DB;
using HQ.Core.Model.ShortMessage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.DAL.ShortMessage
{
    /// <summary>
    /// 短信模板数据访问层
    /// </summary>
    public class ShortMessageTemplateDAL
    {
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShortMessageTemplateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Sms_Template(");
            strSql.Append("SceneType,Template,CreateTime,Status)");
            strSql.Append(" values (");
            strSql.Append("@SceneType,@Template,@CreateTime,@Status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@SceneType", SqlDbType.SmallInt,2),
                    new SqlParameter("@Template", SqlDbType.VarChar,-1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.SceneType;
            parameters[1].Value = model.Template;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.Status;

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
        public bool Update(ShortMessageTemplateModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Sms_Template set ");
            strSql.Append("SceneType=@SceneType,");
            strSql.Append("Template=@Template,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@SceneType", SqlDbType.SmallInt,2),
                    new SqlParameter("@Template", SqlDbType.VarChar,-1),
                    new SqlParameter("@CreateTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.SceneType;
            parameters[1].Value = model.Template;
            parameters[2].Value = model.CreateTime;
            parameters[3].Value = model.Status;
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
            strSql.Append("delete from HQ_Sms_Template ");
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
        public ShortMessageTemplateModel GetModel(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Sms_Template ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            ShortMessageTemplateModel model = new ShortMessageTemplateModel();
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
        public ShortMessageTemplateModel DataRowToModel(DataRow row)
        {
            ShortMessageTemplateModel model = new ShortMessageTemplateModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["SceneType"] != null && row["SceneType"].ToString() != "")
                {
                    model.SceneType = int.Parse(row["SceneType"].ToString());
                }
                if (row["Template"] != null)
                {
                    model.Template = row["Template"].ToString();
                }
                if (row["CreateTime"] != null && row["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(row["CreateTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }

        #endregion  BasicMethod

        public DataTable GetAllList()
        {
            string sql = "SELECT * FROM HQ_Sms_Template Order By Id DESC";
            return DbHelperSQL.Query(sql).Tables[0];
        }

        public bool Exsit(int sceneType)
        {
            return Convert.ToInt16(DbHelperSQL.GetSingle(string.Format("SELECT COUNT(*) FROM HQ_Sms_Template WHERE SceneType={0}", sceneType))) > 0;
        }

        /// <summary>
        /// 根据场景和商户号获得模板信息
        /// </summary>
        /// <param name="sceneType"></param>
        /// <returns></returns>
        public ShortMessageTemplateModel GetModelBySceneType(int sceneType)
        {
            string sql = string.Format("SELECT TOP 1 * FROM HQ_Sms_Template WHERE SceneType={0}  ORDER BY iD DESC", sceneType);

            ShortMessageTemplateModel model = new ShortMessageTemplateModel();
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
