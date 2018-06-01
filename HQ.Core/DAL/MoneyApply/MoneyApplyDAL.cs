using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 提现申请数据访问层
    /// </summary>
    public partial class MoneyApplyDAL
	{
		public MoneyApplyDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.MoneyApplyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_MoneyApply(");
			strSql.Append("UserId,UserName,RealName,ApplyType,ApplyAccount,ApplyAmount,ApplyStatus,ApplyMemo,ApplyTime,BankName,BankInfo,ApplyFee,ApplyFeeRate,AgentId)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@UserName,@RealName,@ApplyType,@ApplyAccount,@ApplyAmount,@ApplyStatus,@ApplyMemo,@ApplyTime,@BankName,@BankInfo,@ApplyFee,@ApplyFeeRate,@AgentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@RealName", SqlDbType.VarChar,30),
					new SqlParameter("@ApplyType", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyAccount", SqlDbType.VarChar,50),
					new SqlParameter("@ApplyAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ApplyStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyMemo", SqlDbType.VarChar,200),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@BankName", SqlDbType.VarChar,30),
					new SqlParameter("@BankInfo", SqlDbType.VarChar,50),
					new SqlParameter("@ApplyFee", SqlDbType.Decimal,5),
					new SqlParameter("@ApplyFeeRate", SqlDbType.Decimal,5),
					new SqlParameter("@AgentId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.ApplyType;
			parameters[4].Value = model.ApplyAccount;
			parameters[5].Value = model.ApplyAmount;
			parameters[6].Value = model.ApplyStatus;
			parameters[7].Value = model.ApplyMemo;
			parameters[8].Value = model.ApplyTime;
			parameters[9].Value = model.BankName;
			parameters[10].Value = model.BankInfo;
			parameters[11].Value = model.ApplyFee;
			parameters[12].Value = model.ApplyFeeRate;
			parameters[13].Value = model.AgentId;

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
		public bool Update(HQ.Model.MoneyApplyModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_MoneyApply set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("RealName=@RealName,");
			strSql.Append("ApplyType=@ApplyType,");
			strSql.Append("ApplyAccount=@ApplyAccount,");
			strSql.Append("ApplyAmount=@ApplyAmount,");
			strSql.Append("ApplyStatus=@ApplyStatus,");
			strSql.Append("ApplyMemo=@ApplyMemo,");
			strSql.Append("ApplyTime=@ApplyTime,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankInfo=@BankInfo,");
			strSql.Append("ApplyFee=@ApplyFee,");
			strSql.Append("ApplyFeeRate=@ApplyFeeRate,");
			strSql.Append("AgentId=@AgentId");
			strSql.Append(" where ApplyId=@ApplyId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@RealName", SqlDbType.VarChar,30),
					new SqlParameter("@ApplyType", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyAccount", SqlDbType.VarChar,50),
					new SqlParameter("@ApplyAmount", SqlDbType.Decimal,9),
					new SqlParameter("@ApplyStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyMemo", SqlDbType.VarChar,200),
					new SqlParameter("@ApplyTime", SqlDbType.DateTime),
					new SqlParameter("@BankName", SqlDbType.VarChar,30),
					new SqlParameter("@BankInfo", SqlDbType.VarChar,50),
					new SqlParameter("@ApplyFee", SqlDbType.Decimal,5),
					new SqlParameter("@ApplyFeeRate", SqlDbType.Decimal,5),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@ApplyId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.RealName;
			parameters[3].Value = model.ApplyType;
			parameters[4].Value = model.ApplyAccount;
			parameters[5].Value = model.ApplyAmount;
			parameters[6].Value = model.ApplyStatus;
			parameters[7].Value = model.ApplyMemo;
			parameters[8].Value = model.ApplyTime;
			parameters[9].Value = model.BankName;
			parameters[10].Value = model.BankInfo;
			parameters[11].Value = model.ApplyFee;
			parameters[12].Value = model.ApplyFeeRate;
			parameters[13].Value = model.AgentId;
			parameters[14].Value = model.ApplyId;

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
		public bool Delete(int ApplyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_MoneyApply ");
			strSql.Append(" where ApplyId=@ApplyId");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyId", SqlDbType.Int,4)
			};
			parameters[0].Value = ApplyId;

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
		public HQ.Model.MoneyApplyModel GetModel(int ApplyId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_MoneyApply ");
			strSql.Append(" where ApplyId=@ApplyId");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyId", SqlDbType.Int,4)
			};
			parameters[0].Value = ApplyId;

			HQ.Model.MoneyApplyModel model=new HQ.Model.MoneyApplyModel();
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
		public HQ.Model.MoneyApplyModel DataRowToModel(DataRow row)
		{
			HQ.Model.MoneyApplyModel model=new HQ.Model.MoneyApplyModel();
			if (row != null)
			{
				if(row["ApplyId"]!=null && row["ApplyId"].ToString()!="")
				{
					model.ApplyId=int.Parse(row["ApplyId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["RealName"]!=null)
				{
					model.RealName=row["RealName"].ToString();
				}
				if(row["ApplyType"]!=null && row["ApplyType"].ToString()!="")
				{
					model.ApplyType=int.Parse(row["ApplyType"].ToString());
				}
				if(row["ApplyAccount"]!=null)
				{
					model.ApplyAccount=row["ApplyAccount"].ToString();
				}
				if(row["ApplyAmount"]!=null && row["ApplyAmount"].ToString()!="")
				{
					model.ApplyAmount=decimal.Parse(row["ApplyAmount"].ToString());
				}
				if(row["ApplyStatus"]!=null && row["ApplyStatus"].ToString()!="")
				{
					model.ApplyStatus=int.Parse(row["ApplyStatus"].ToString());
				}
				if(row["ApplyMemo"]!=null)
				{
					model.ApplyMemo=row["ApplyMemo"].ToString();
				}
				if(row["ApplyTime"]!=null && row["ApplyTime"].ToString()!="")
				{
					model.ApplyTime=DateTime.Parse(row["ApplyTime"].ToString());
				}
				if(row["BankName"]!=null)
				{
					model.BankName=row["BankName"].ToString();
				}
				if(row["BankInfo"]!=null)
				{
					model.BankInfo=row["BankInfo"].ToString();
				}
				if(row["ApplyFee"]!=null && row["ApplyFee"].ToString()!="")
				{
					model.ApplyFee=decimal.Parse(row["ApplyFee"].ToString());
				}
				if(row["ApplyFeeRate"]!=null && row["ApplyFeeRate"].ToString()!="")
				{
					model.ApplyFeeRate=decimal.Parse(row["ApplyFeeRate"].ToString());
				}
				if(row["AgentId"]!=null && row["AgentId"].ToString()!="")
				{
					model.AgentId=int.Parse(row["AgentId"].ToString());
				}
			}
			return model;
		}

		#endregion  BasicMethod
		
	}
}

