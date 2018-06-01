using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 商品分类数据访问层
    /// </summary>
    public partial class GoodsCatsDAL
	{
		public GoodsCatsDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(HQ.Model.GoodsCatsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Goods_Cats(");
			strSql.Append("Id,PlatType,Name,ParentId,Level,Icon,SortNum)");
			strSql.Append(" values (");
			strSql.Append("@Id,@PlatType,@Name,@ParentId,@Level,@Icon,@SortNum)");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Icon", SqlDbType.VarChar,300),
					new SqlParameter("@SortNum", SqlDbType.Int,4)};
			parameters[0].Value = model.Id;
			parameters[1].Value = model.PlatType;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.ParentId;
			parameters[4].Value = model.Level;
			parameters[5].Value = model.Icon;
			parameters[6].Value = model.SortNum;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(HQ.Model.GoodsCatsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Goods_Cats set ");
			strSql.Append("PlatType=@PlatType,");
			strSql.Append("Name=@Name,");
			strSql.Append("ParentId=@ParentId,");
			strSql.Append("Level=@Level,");
			strSql.Append("Icon=@Icon,");
			strSql.Append("SortNum=@SortNum");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@ParentId", SqlDbType.Int,4),
					new SqlParameter("@Level", SqlDbType.Int,4),
					new SqlParameter("@Icon", SqlDbType.VarChar,300),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PlatType;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.ParentId;
			parameters[3].Value = model.Level;
			parameters[4].Value = model.Icon;
			parameters[5].Value = model.SortNum;
			parameters[6].Value = model.Id;

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
			strSql.Append("delete from HQ_Goods_Cats ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
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
		public HQ.Model.GoodsCatsModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PlatType,Name,ParentId,Level,Icon,SortNum from HQ_Goods_Cats ");
			strSql.Append(" where Id=@Id ");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)			};
			parameters[0].Value = Id;

			HQ.Model.GoodsCatsModel model=new HQ.Model.GoodsCatsModel();
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
		public HQ.Model.GoodsCatsModel DataRowToModel(DataRow row)
		{
			HQ.Model.GoodsCatsModel model=new HQ.Model.GoodsCatsModel();
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
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["ParentId"]!=null && row["ParentId"].ToString()!="")
				{
					model.ParentId=int.Parse(row["ParentId"].ToString());
				}
				if(row["Level"]!=null && row["Level"].ToString()!="")
				{
					model.Level=int.Parse(row["Level"].ToString());
				}
				if(row["Icon"]!=null)
				{
					model.Icon=row["Icon"].ToString();
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=int.Parse(row["SortNum"].ToString());
				}
			}
			return model;
		}
        
		#endregion  BasicMethod
		
	}
}

