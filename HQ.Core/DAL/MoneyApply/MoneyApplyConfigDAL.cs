using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 提现申请配置数据访问层
    /// </summary>
    public partial class MoneyApplyConfigDAL
	{
		public MoneyApplyConfigDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.MoneyApplyConfigModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_MoneyApply_Cfg(");
			strSql.Append("ApplyType,ApplyFeeRate,ApplyMinFee,BaseAmount,MonthCount,SettlementDay)");
			strSql.Append(" values (");
			strSql.Append("@ApplyType,@ApplyFeeRate,@ApplyMinFee,@BaseAmount,@MonthCount,@SettlementDay)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyType", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyFeeRate", SqlDbType.Decimal,5),
					new SqlParameter("@ApplyMinFee", SqlDbType.Decimal,5),
					new SqlParameter("@BaseAmount", SqlDbType.Decimal,5),
					new SqlParameter("@MonthCount", SqlDbType.SmallInt,2),
					new SqlParameter("@SettlementDay", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.ApplyType;
			parameters[1].Value = model.ApplyFeeRate;
			parameters[2].Value = model.ApplyMinFee;
			parameters[3].Value = model.BaseAmount;
			parameters[4].Value = model.MonthCount;
			parameters[5].Value = model.SettlementDay;

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
		public bool Update(HQ.Model.MoneyApplyConfigModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_MoneyApply_Cfg set ");
			strSql.Append("ApplyType=@ApplyType,");
			strSql.Append("ApplyFeeRate=@ApplyFeeRate,");
			strSql.Append("ApplyMinFee=@ApplyMinFee,");
			strSql.Append("BaseAmount=@BaseAmount,");
			strSql.Append("MonthCount=@MonthCount,");
			strSql.Append("SettlementDay=@SettlementDay");
			strSql.Append(" where CfgId=@CfgId");
			SqlParameter[] parameters = {
					new SqlParameter("@ApplyType", SqlDbType.SmallInt,2),
					new SqlParameter("@ApplyFeeRate", SqlDbType.Decimal,5),
					new SqlParameter("@ApplyMinFee", SqlDbType.Decimal,5),
					new SqlParameter("@BaseAmount", SqlDbType.Decimal,5),
					new SqlParameter("@MonthCount", SqlDbType.SmallInt,2),
					new SqlParameter("@SettlementDay", SqlDbType.SmallInt,2),
					new SqlParameter("@CfgId", SqlDbType.Int,4)};
			parameters[0].Value = model.ApplyType;
			parameters[1].Value = model.ApplyFeeRate;
			parameters[2].Value = model.ApplyMinFee;
			parameters[3].Value = model.BaseAmount;
			parameters[4].Value = model.MonthCount;
			parameters[5].Value = model.SettlementDay;
			parameters[6].Value = model.CfgId;

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
		public bool Delete(int CfgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_MoneyApply_Cfg ");
			strSql.Append(" where CfgId=@CfgId");
			SqlParameter[] parameters = {
					new SqlParameter("@CfgId", SqlDbType.Int,4)
			};
			parameters[0].Value = CfgId;

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
		public HQ.Model.MoneyApplyConfigModel GetModel(int CfgId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CfgId,ApplyType,ApplyFeeRate,ApplyMinFee,BaseAmount,MonthCount,SettlementDay from HQ_MoneyApply_Cfg ");
			strSql.Append(" where CfgId=@CfgId");
			SqlParameter[] parameters = {
					new SqlParameter("@CfgId", SqlDbType.Int,4)
			};
			parameters[0].Value = CfgId;

			HQ.Model.MoneyApplyConfigModel model=new HQ.Model.MoneyApplyConfigModel();
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
		public HQ.Model.MoneyApplyConfigModel DataRowToModel(DataRow row)
		{
			HQ.Model.MoneyApplyConfigModel model=new HQ.Model.MoneyApplyConfigModel();
			if (row != null)
			{
				if(row["CfgId"]!=null && row["CfgId"].ToString()!="")
				{
					model.CfgId=int.Parse(row["CfgId"].ToString());
				}
				if(row["ApplyType"]!=null && row["ApplyType"].ToString()!="")
				{
					model.ApplyType=int.Parse(row["ApplyType"].ToString());
				}
				if(row["ApplyFeeRate"]!=null && row["ApplyFeeRate"].ToString()!="")
				{
					model.ApplyFeeRate=decimal.Parse(row["ApplyFeeRate"].ToString());
				}
				if(row["ApplyMinFee"]!=null && row["ApplyMinFee"].ToString()!="")
				{
					model.ApplyMinFee=decimal.Parse(row["ApplyMinFee"].ToString());
				}
				if(row["BaseAmount"]!=null && row["BaseAmount"].ToString()!="")
				{
					model.BaseAmount=decimal.Parse(row["BaseAmount"].ToString());
				}
				if(row["MonthCount"]!=null && row["MonthCount"].ToString()!="")
				{
					model.MonthCount=int.Parse(row["MonthCount"].ToString());
				}
				if(row["SettlementDay"]!=null && row["SettlementDay"].ToString()!="")
				{
					model.SettlementDay=int.Parse(row["SettlementDay"].ToString());
				}
			}
			return model;
		}
		#endregion  BasicMethod
		
	}
}

