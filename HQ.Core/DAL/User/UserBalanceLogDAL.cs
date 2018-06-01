using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 用户余额变动流水数据访问层
    /// </summary>
    public partial class UserBalanceLogDAL
	{
		public UserBalanceLogDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.UserBalanceLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_Balance_Logs(");
			strSql.Append("UserId,ChgMoney,BeforeMoney,AfterMoney,LogType,Remark,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@ChgMoney,@BeforeMoney,@AfterMoney,@LogType,@Remark,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@ChgMoney", SqlDbType.Decimal,5),
					new SqlParameter("@BeforeMoney", SqlDbType.Decimal,5),
					new SqlParameter("@AfterMoney", SqlDbType.Decimal,5),
					new SqlParameter("@LogType", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,150),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.ChgMoney;
			parameters[2].Value = model.BeforeMoney;
			parameters[3].Value = model.AfterMoney;
			parameters[4].Value = model.LogType;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.CreateTime;

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
		public bool Update(HQ.Model.UserBalanceLogsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_Balance_Logs set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("ChgMoney=@ChgMoney,");
			strSql.Append("BeforeMoney=@BeforeMoney,");
			strSql.Append("AfterMoney=@AfterMoney,");
			strSql.Append("LogType=@LogType,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@ChgMoney", SqlDbType.Decimal,5),
					new SqlParameter("@BeforeMoney", SqlDbType.Decimal,5),
					new SqlParameter("@AfterMoney", SqlDbType.Decimal,5),
					new SqlParameter("@LogType", SqlDbType.Int,4),
					new SqlParameter("@Remark", SqlDbType.VarChar,150),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LogId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.ChgMoney;
			parameters[2].Value = model.BeforeMoney;
			parameters[3].Value = model.AfterMoney;
			parameters[4].Value = model.LogType;
			parameters[5].Value = model.Remark;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.LogId;

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
			strSql.Append("delete from HQ_User_Balance_Logs ");
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
		public HQ.Model.UserBalanceLogsModel GetModel(int LogId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LogId,UserId,ChgMoney,BeforeMoney,AfterMoney,LogType,Remark,CreateTime from HQ_User_Balance_Logs ");
			strSql.Append(" where LogId=@LogId");
			SqlParameter[] parameters = {
					new SqlParameter("@LogId", SqlDbType.Int,4)
			};
			parameters[0].Value = LogId;

			HQ.Model.UserBalanceLogsModel model=new HQ.Model.UserBalanceLogsModel();
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
		public HQ.Model.UserBalanceLogsModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserBalanceLogsModel model=new HQ.Model.UserBalanceLogsModel();
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
				if(row["ChgMoney"]!=null && row["ChgMoney"].ToString()!="")
				{
					model.ChgMoney=decimal.Parse(row["ChgMoney"].ToString());
				}
				if(row["BeforeMoney"]!=null && row["BeforeMoney"].ToString()!="")
				{
					model.BeforeMoney=decimal.Parse(row["BeforeMoney"].ToString());
				}
				if(row["AfterMoney"]!=null && row["AfterMoney"].ToString()!="")
				{
					model.AfterMoney=decimal.Parse(row["AfterMoney"].ToString());
				}
				if(row["LogType"]!=null && row["LogType"].ToString()!="")
				{
					model.LogType=int.Parse(row["LogType"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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

