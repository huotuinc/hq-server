using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 返利(佣金)变更日志数据访问层
    /// </summary>
    public partial class RebateLogsDAL
	{
		public RebateLogsDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.RebateLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Rebate_Logs(");
			strSql.Append("UserId,RebateId,ChgMoney,LogType,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@RebateId,@ChgMoney,@LogType,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RebateId", SqlDbType.Int,4),
					new SqlParameter("@ChgMoney", SqlDbType.Decimal,5),
					new SqlParameter("@LogType", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RebateId;
			parameters[2].Value = model.ChgMoney;
			parameters[3].Value = model.LogType;
			parameters[4].Value = model.CreateTime;

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
		public bool Update(HQ.Model.RebateLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Rebate_Logs set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("RebateId=@RebateId,");
			strSql.Append("ChgMoney=@ChgMoney,");
			strSql.Append("LogType=@LogType,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RebateId", SqlDbType.Int,4),
					new SqlParameter("@ChgMoney", SqlDbType.Decimal,5),
					new SqlParameter("@LogType", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LogId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RebateId;
			parameters[2].Value = model.ChgMoney;
			parameters[3].Value = model.LogType;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.LogId;

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
			strSql.Append("delete from HQ_Rebate_Logs ");
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
		public HQ.Model.RebateLogsModel GetModel(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_Rebate_Logs ");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

			HQ.Model.RebateLogsModel model=new HQ.Model.RebateLogsModel();
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
		public HQ.Model.RebateLogsModel DataRowToModel(DataRow row)
		{
			HQ.Model.RebateLogsModel model=new HQ.Model.RebateLogsModel();
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
				if(row["RebateId"]!=null && row["RebateId"].ToString()!="")
				{
					model.RebateId=int.Parse(row["RebateId"].ToString());
				}
				if(row["ChgMoney"]!=null && row["ChgMoney"].ToString()!="")
				{
					model.ChgMoney=decimal.Parse(row["ChgMoney"].ToString());
				}
				if(row["LogType"]!=null && row["LogType"].ToString()!="")
				{
					model.LogType=int.Parse(row["LogType"].ToString());
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

