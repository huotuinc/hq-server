using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 用户变更日志数据访问层
    /// </summary>
    public partial class UserLogsDAL
	{
		public UserLogsDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.UserLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_Logs(");
			strSql.Append("UserId,LogType,Reamark,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@LogType,@Reamark,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@LogType", SqlDbType.SmallInt,2),
					new SqlParameter("@Reamark", SqlDbType.VarChar,250),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.LogType;
			parameters[2].Value = model.Reamark;
			parameters[3].Value = model.CreateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(HQ.Model.UserLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_Logs set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("LogType=@LogType,");
			strSql.Append("Reamark=@Reamark,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@LogType", SqlDbType.SmallInt,2),
					new SqlParameter("@Reamark", SqlDbType.VarChar,250),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LogId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.LogType;
			parameters[2].Value = model.Reamark;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.LogId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_User_Logs ");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public HQ.Model.UserLogsModel GetModel(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LogId,UserId,LogType,Reamark,CreateTime from HQ_User_Logs ");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

			HQ.Model.UserLogsModel model=new HQ.Model.UserLogsModel();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public HQ.Model.UserLogsModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserLogsModel model=new HQ.Model.UserLogsModel();
			if (row != null)
			{
				if(row["LogId"]!=null && row["LogId"].ToString()!="")
				{
					model.LogId=int.Parse(row["LogId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["LogType"]!=null && row["LogType"].ToString()!="")
				{
					model.LogType=int.Parse(row["LogType"].ToString());
				}
				if(row["Reamark"]!=null)
				{
					model.Reamark=row["Reamark"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
		}
		#endregion  BasicMethod
		
	}
}

