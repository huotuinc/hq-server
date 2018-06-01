using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 用户第三方授权绑定数据访问层
    /// </summary>
    public partial class UserOAuthBondsDAL
	{
		public UserOAuthBondsDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(HQ.Model.UserOAuthBondsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_OauthBonds(");
			strSql.Append("UserId,OauthType,Identification,RefreshToken,OauthTime,OauthUInfo,WxUnionId)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@OauthType,@Identification,@RefreshToken,@OauthTime,@OauthUInfo,@WxUnionId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@OauthType", SqlDbType.TinyInt,1),
					new SqlParameter("@Identification", SqlDbType.VarChar,50),
					new SqlParameter("@RefreshToken", SqlDbType.VarChar,50),
					new SqlParameter("@OauthTime", SqlDbType.DateTime),
					new SqlParameter("@OauthUInfo", SqlDbType.VarChar,700),
					new SqlParameter("@WxUnionId", SqlDbType.VarChar,50)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.OauthType;
			parameters[2].Value = model.Identification;
			parameters[3].Value = model.RefreshToken;
			parameters[4].Value = model.OauthTime;
			parameters[5].Value = model.OauthUInfo;
			parameters[6].Value = model.WxUnionId;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HQ.Model.UserOAuthBondsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_OauthBonds set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("OauthType=@OauthType,");
			strSql.Append("Identification=@Identification,");
			strSql.Append("RefreshToken=@RefreshToken,");
			strSql.Append("OauthTime=@OauthTime,");
			strSql.Append("OauthUInfo=@OauthUInfo,");
			strSql.Append("WxUnionId=@WxUnionId");
			strSql.Append(" where BindId=@BindId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@OauthType", SqlDbType.TinyInt,1),
					new SqlParameter("@Identification", SqlDbType.VarChar,50),
					new SqlParameter("@RefreshToken", SqlDbType.VarChar,50),
					new SqlParameter("@OauthTime", SqlDbType.DateTime),
					new SqlParameter("@OauthUInfo", SqlDbType.VarChar,700),
					new SqlParameter("@WxUnionId", SqlDbType.VarChar,50),
					new SqlParameter("@BindId", SqlDbType.Decimal,9)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.OauthType;
			parameters[2].Value = model.Identification;
			parameters[3].Value = model.RefreshToken;
			parameters[4].Value = model.OauthTime;
			parameters[5].Value = model.OauthUInfo;
			parameters[6].Value = model.WxUnionId;
			parameters[7].Value = model.BindId;

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
		public bool Delete(decimal BindId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_User_OauthBonds ");
			strSql.Append(" where BindId=@BindId");
			SqlParameter[] parameters = {
					new SqlParameter("@BindId", SqlDbType.Decimal)
			};
			parameters[0].Value = BindId;

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
		public HQ.Model.UserOAuthBondsModel GetModel(decimal BindId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 BindId,UserId,OauthType,Identification,RefreshToken,OauthTime,OauthUInfo,WxUnionId from HQ_User_OauthBonds ");
			strSql.Append(" where BindId=@BindId");
			SqlParameter[] parameters = {
					new SqlParameter("@BindId", SqlDbType.Decimal)
			};
			parameters[0].Value = BindId;

			HQ.Model.UserOAuthBondsModel model=new HQ.Model.UserOAuthBondsModel();
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
		public HQ.Model.UserOAuthBondsModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserOAuthBondsModel model=new HQ.Model.UserOAuthBondsModel();
			if (row != null)
			{
				if(row["BindId"]!=null && row["BindId"].ToString()!="")
				{
					model.BindId=decimal.Parse(row["BindId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["OauthType"]!=null && row["OauthType"].ToString()!="")
				{
					model.OauthType=int.Parse(row["OauthType"].ToString());
				}
				if(row["Identification"]!=null)
				{
					model.Identification=row["Identification"].ToString();
				}
				if(row["RefreshToken"]!=null)
				{
					model.RefreshToken=row["RefreshToken"].ToString();
				}
				if(row["OauthTime"]!=null && row["OauthTime"].ToString()!="")
				{
					model.OauthTime=DateTime.Parse(row["OauthTime"].ToString());
				}
				if(row["OauthUInfo"]!=null)
				{
					model.OauthUInfo=row["OauthUInfo"].ToString();
				}
				if(row["WxUnionId"]!=null)
				{
					model.WxUnionId=row["WxUnionId"].ToString();
				}
			}
			return model;
		}

	
		#endregion  BasicMethod
		
	}
}

