using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 好券圈(分享中心)文章分类数据访问层
    /// </summary>
    public partial class ShareZoneCatDAL
	{
		public ShareZoneCatDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.ShareZoneCatModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_ShareZone_Cat(");
			strSql.Append("CatName,SortNum,Status)");
			strSql.Append(" values (");
			strSql.Append("@CatName,@SortNum,@Status)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CatName", SqlDbType.VarChar,50),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.CatName;
			parameters[1].Value = model.SortNum;
			parameters[2].Value = model.Status;

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
		public bool Update(HQ.Model.ShareZoneCatModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_ShareZone_Cat set ");
			strSql.Append("CatName=@CatName,");
			strSql.Append("SortNum=@SortNum,");
			strSql.Append("Status=@Status");
			strSql.Append(" where CatId=@CatId");
			SqlParameter[] parameters = {
					new SqlParameter("@CatName", SqlDbType.VarChar,50),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@Status", SqlDbType.SmallInt,2),
					new SqlParameter("@CatId", SqlDbType.Int,4)};
			parameters[0].Value = model.CatName;
			parameters[1].Value = model.SortNum;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.CatId;

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
		public bool Delete(int CatId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_ShareZone_Cat ");
			strSql.Append(" where CatId=@CatId");
			SqlParameter[] parameters = {
					new SqlParameter("@CatId", SqlDbType.Int,4)
			};
			parameters[0].Value = CatId;

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
		public HQ.Model.ShareZoneCatModel GetModel(int CatId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CatId,CatName,SortNum,Status from HQ_ShareZone_Cat ");
			strSql.Append(" where CatId=@CatId");
			SqlParameter[] parameters = {
					new SqlParameter("@CatId", SqlDbType.Int,4)
			};
			parameters[0].Value = CatId;

			HQ.Model.ShareZoneCatModel model=new HQ.Model.ShareZoneCatModel();
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
		public HQ.Model.ShareZoneCatModel DataRowToModel(DataRow row)
		{
			HQ.Model.ShareZoneCatModel model=new HQ.Model.ShareZoneCatModel();
			if (row != null)
			{
				if(row["CatId"]!=null && row["CatId"].ToString()!="")
				{
					model.CatId=int.Parse(row["CatId"].ToString());
				}
				if(row["CatName"]!=null)
				{
					model.CatName=row["CatName"].ToString();
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=int.Parse(row["SortNum"].ToString());
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

