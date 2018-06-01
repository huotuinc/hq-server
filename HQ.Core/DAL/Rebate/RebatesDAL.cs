using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Core.Model.Rebate;

namespace HQ.DAL
{
    /// <summary>
    /// 返利(佣金)记录数据访问层
    /// </summary>
    public partial class RebatesDAL
	{
		public RebatesDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.RebatesModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Rebates(");
			strSql.Append("UserId,RebateType,FlowMoney,FinalMoney,CreateTime,LastModify,RebateDesc,ContribUserId,SettleStatus,ContribDepth,OrderId,AgentId,PlatType)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@RebateType,@FlowMoney,@FinalMoney,@CreateTime,@LastModify,@RebateDesc,@ContribUserId,@SettleStatus,@ContribDepth,@OrderId,@AgentId,@PlatType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RebateType", SqlDbType.SmallInt,2),
					new SqlParameter("@FlowMoney", SqlDbType.Decimal,5),
					new SqlParameter("@FinalMoney", SqlDbType.Decimal,5),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastModify", SqlDbType.DateTime),
					new SqlParameter("@RebateDesc", SqlDbType.VarChar,400),
					new SqlParameter("@ContribUserId", SqlDbType.Int,4),
					new SqlParameter("@SettleStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@ContribDepth", SqlDbType.SmallInt,2),
					new SqlParameter("@OrderId", SqlDbType.VarChar,30),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RebateType;
			parameters[2].Value = model.FlowMoney;
			parameters[3].Value = model.FinalMoney;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.LastModify;
			parameters[6].Value = model.RebateDesc;
			parameters[7].Value = model.ContribUserId;
			parameters[8].Value = model.SettleStatus;
			parameters[9].Value = model.ContribDepth;
			parameters[10].Value = model.OrderId;
			parameters[11].Value = model.AgentId;
			parameters[12].Value = model.PlatType;

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
		public bool Update(HQ.Model.RebatesModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Rebates set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("RebateType=@RebateType,");
			strSql.Append("FlowMoney=@FlowMoney,");
			strSql.Append("FinalMoney=@FinalMoney,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("LastModify=@LastModify,");
			strSql.Append("RebateDesc=@RebateDesc,");
			strSql.Append("ContribUserId=@ContribUserId,");
			strSql.Append("SettleStatus=@SettleStatus,");
			strSql.Append("ContribDepth=@ContribDepth,");
			strSql.Append("OrderId=@OrderId,");
			strSql.Append("AgentId=@AgentId,");
			strSql.Append("PlatType=@PlatType");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@RebateType", SqlDbType.SmallInt,2),
					new SqlParameter("@FlowMoney", SqlDbType.Decimal,5),
					new SqlParameter("@FinalMoney", SqlDbType.Decimal,5),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@LastModify", SqlDbType.DateTime),
					new SqlParameter("@RebateDesc", SqlDbType.VarChar,400),
					new SqlParameter("@ContribUserId", SqlDbType.Int,4),
					new SqlParameter("@SettleStatus", SqlDbType.SmallInt,2),
					new SqlParameter("@ContribDepth", SqlDbType.SmallInt,2),
					new SqlParameter("@OrderId", SqlDbType.VarChar,30),
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.RebateType;
			parameters[2].Value = model.FlowMoney;
			parameters[3].Value = model.FinalMoney;
			parameters[4].Value = model.CreateTime;
			parameters[5].Value = model.LastModify;
			parameters[6].Value = model.RebateDesc;
			parameters[7].Value = model.ContribUserId;
			parameters[8].Value = model.SettleStatus;
			parameters[9].Value = model.ContribDepth;
			parameters[10].Value = model.OrderId;
			parameters[11].Value = model.AgentId;
			parameters[12].Value = model.PlatType;
			parameters[13].Value = model.Id;

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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_Rebates ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

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
		public HQ.Model.RebatesModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_Rebates ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			HQ.Model.RebatesModel model=new HQ.Model.RebatesModel();
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
		public HQ.Model.RebatesModel DataRowToModel(DataRow row)
		{
			HQ.Model.RebatesModel model=new HQ.Model.RebatesModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["RebateType"]!=null && row["RebateType"].ToString()!="")
				{
					model.RebateType=int.Parse(row["RebateType"].ToString());
				}
				if(row["FlowMoney"]!=null && row["FlowMoney"].ToString()!="")
				{
					model.FlowMoney=decimal.Parse(row["FlowMoney"].ToString());
				}
				if(row["FinalMoney"]!=null && row["FinalMoney"].ToString()!="")
				{
					model.FinalMoney=decimal.Parse(row["FinalMoney"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["LastModify"]!=null && row["LastModify"].ToString()!="")
				{
					model.LastModify=DateTime.Parse(row["LastModify"].ToString());
				}
				if(row["RebateDesc"]!=null)
				{
					model.RebateDesc=row["RebateDesc"].ToString();
				}
				if(row["ContribUserId"]!=null && row["ContribUserId"].ToString()!="")
				{
					model.ContribUserId=int.Parse(row["ContribUserId"].ToString());
				}
				if(row["SettleStatus"]!=null && row["SettleStatus"].ToString()!="")
				{
					model.SettleStatus=int.Parse(row["SettleStatus"].ToString());
				}
				if(row["ContribDepth"]!=null && row["ContribDepth"].ToString()!="")
				{
					model.ContribDepth=int.Parse(row["ContribDepth"].ToString());
				}
				if(row["OrderId"]!=null)
				{
					model.OrderId=row["OrderId"].ToString();
				}
				if(row["AgentId"]!=null && row["AgentId"].ToString()!="")
				{
					model.AgentId=int.Parse(row["AgentId"].ToString());
				}
				if(row["PlatType"]!=null && row["PlatType"].ToString()!="")
				{
					model.PlatType=int.Parse(row["PlatType"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public DataTable GetList(int pageSize, int pageIndex, out int recordCount, RebatesSearchCondition condition)
        {
            StringBuilder sbSqlwhere = new StringBuilder();
            
            return this.GetList(pageSize, pageIndex, sbSqlwhere.ToString(), out recordCount);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        private DataTable GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            string sql = "select * FROM HQ_Rebates where 1=1 ";
            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }
            sql += " ORDER BY Id DESC";
            return DbHelperSQL.GetSplitDataTable(sql, pageSize, pageIndex, out recordCount);
        }

        #endregion  BasicMethod

    }
}

