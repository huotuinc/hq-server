using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 热门搜索关键字数据访问层
    /// </summary>
    public partial class HotKeywordDAL
	{
		public HotKeywordDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.HotKeywordModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_HotKeyword(");
			strSql.Append("PlatType,Keyword,SortNum,CreateTime,Status)");
			strSql.Append(" values (");
			strSql.Append("@PlatType,@Keyword,@SortNum,@CreateTime,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@Keyword", SqlDbType.VarChar,50),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.PlatType;
			parameters[1].Value = model.Keyword;
			parameters[2].Value = model.SortNum;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.Status;

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
		public bool Update(HQ.Model.HotKeywordModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_HotKeyword set ");
			strSql.Append("PlatType=@PlatType,");
			strSql.Append("Keyword=@Keyword,");
			strSql.Append("SortNum=@SortNum,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("Status=@Status");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@Keyword", SqlDbType.VarChar,50),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PlatType;
			parameters[1].Value = model.Keyword;
			parameters[2].Value = model.SortNum;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Id;

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
			strSql.Append("delete from HQ_HotKeyword ");
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
		public HQ.Model.HotKeywordModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PlatType,Keyword,SortNum,CreateTime,Status from HQ_HotKeyword ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			HQ.Model.HotKeywordModel model=new HQ.Model.HotKeywordModel();
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
		public HQ.Model.HotKeywordModel DataRowToModel(DataRow row)
		{
			HQ.Model.HotKeywordModel model=new HQ.Model.HotKeywordModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["PlatType"]!=null && row["PlatType"].ToString()!="")
				{
					model.PlatType=int.Parse(row["PlatType"].ToString());
				}
				if(row["Keyword"]!=null)
				{
					model.Keyword=row["Keyword"].ToString();
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=int.Parse(row["SortNum"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
			}
			return model;
		}

		#endregion  BasicMethod
		
	}
}

