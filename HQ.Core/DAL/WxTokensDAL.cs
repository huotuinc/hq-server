using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 微信token维护数据访问层
    /// </summary>
    public partial class WxTokensDAL
	{
		public WxTokensDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.WxTokensModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_WxTokens(");
			strSql.Append("Token,BuildTime)");
			strSql.Append(" values (");
			strSql.Append("@Token,@BuildTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Token", SqlDbType.VarChar,250),
					new SqlParameter("@BuildTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Token;
			parameters[1].Value = model.BuildTime;

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
		public bool Update(HQ.Model.WxTokensModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_WxTokens set ");
			strSql.Append("Token=@Token,");
			strSql.Append("BuildTime=@BuildTime");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Token", SqlDbType.VarChar,250),
					new SqlParameter("@BuildTime", SqlDbType.DateTime),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Token;
			parameters[1].Value = model.BuildTime;
			parameters[2].Value = model.Id;

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
			strSql.Append("delete from HQ_WxTokens ");
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
		public HQ.Model.WxTokensModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Token,BuildTime from HQ_WxTokens ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			HQ.Model.WxTokensModel model=new HQ.Model.WxTokensModel();
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
		public HQ.Model.WxTokensModel DataRowToModel(DataRow row)
		{
			HQ.Model.WxTokensModel model=new HQ.Model.WxTokensModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Token"]!=null)
				{
					model.Token=row["Token"].ToString();
				}
				if(row["BuildTime"]!=null && row["BuildTime"].ToString()!="")
				{
					model.BuildTime=DateTime.Parse(row["BuildTime"].ToString());
				}
			}
			return model;
		}

		#endregion  BasicMethod
		
	}
}

