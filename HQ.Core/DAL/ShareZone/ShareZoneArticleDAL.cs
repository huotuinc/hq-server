using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 好券圈(分享中心)文章数据访问层
    /// </summary>
    public partial class ShareZoneArticleDAL
	{
		public ShareZoneArticleDAL()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(HQ.Model.ShareZoneArticleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_ShareZone_Article(");
			strSql.Append("ShareId,ShareContent,ShareImgList,CreateTime,ShareCount,GoodsId,PromotionAmount,CatId,ShowTime,HideTime,VideoList,PlatType)");
			strSql.Append(" values (");
			strSql.Append("@ShareId,@ShareContent,@ShareImgList,@CreateTime,@ShareCount,@GoodsId,@PromotionAmount,@CatId,@ShowTime,@HideTime,@VideoList,@PlatType)");
			SqlParameter[] parameters = {
					new SqlParameter("@ShareId", SqlDbType.Int,4),
					new SqlParameter("@ShareContent", SqlDbType.VarChar,1000),
					new SqlParameter("@ShareImgList", SqlDbType.VarChar,3000),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.VarChar,50),
					new SqlParameter("@PromotionAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CatId", SqlDbType.Int,4),
					new SqlParameter("@ShowTime", SqlDbType.DateTime),
					new SqlParameter("@HideTime", SqlDbType.DateTime),
					new SqlParameter("@VideoList", SqlDbType.VarChar,3000),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.ShareId;
			parameters[1].Value = model.ShareContent;
			parameters[2].Value = model.ShareImgList;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.ShareCount;
			parameters[5].Value = model.GoodsId;
			parameters[6].Value = model.PromotionAmount;
			parameters[7].Value = model.CatId;
			parameters[8].Value = model.ShowTime;
			parameters[9].Value = model.HideTime;
			parameters[10].Value = model.VideoList;
			parameters[11].Value = model.PlatType;

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
		public bool Update(HQ.Model.ShareZoneArticleModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_ShareZone_Article set ");
			strSql.Append("ShareId=@ShareId,");
			strSql.Append("ShareContent=@ShareContent,");
			strSql.Append("ShareImgList=@ShareImgList,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("ShareCount=@ShareCount,");
			strSql.Append("GoodsId=@GoodsId,");
			strSql.Append("PromotionAmount=@PromotionAmount,");
			strSql.Append("CatId=@CatId,");
			strSql.Append("ShowTime=@ShowTime,");
			strSql.Append("HideTime=@HideTime,");
			strSql.Append("VideoList=@VideoList,");
			strSql.Append("PlatType=@PlatType");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ShareId", SqlDbType.Int,4),
					new SqlParameter("@ShareContent", SqlDbType.VarChar,1000),
					new SqlParameter("@ShareImgList", SqlDbType.VarChar,3000),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ShareCount", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.VarChar,50),
					new SqlParameter("@PromotionAmount", SqlDbType.Decimal,9),
					new SqlParameter("@CatId", SqlDbType.Int,4),
					new SqlParameter("@ShowTime", SqlDbType.DateTime),
					new SqlParameter("@HideTime", SqlDbType.DateTime),
					new SqlParameter("@VideoList", SqlDbType.VarChar,3000),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.ShareId;
			parameters[1].Value = model.ShareContent;
			parameters[2].Value = model.ShareImgList;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.ShareCount;
			parameters[5].Value = model.GoodsId;
			parameters[6].Value = model.PromotionAmount;
			parameters[7].Value = model.CatId;
			parameters[8].Value = model.ShowTime;
			parameters[9].Value = model.HideTime;
			parameters[10].Value = model.VideoList;
			parameters[11].Value = model.PlatType;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_ShareZone_Article ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public HQ.Model.ShareZoneArticleModel GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ShareId,ShareContent,ShareImgList,CreateTime,ShareCount,GoodsId,PromotionAmount,CatId,ShowTime,HideTime,VideoList,PlatType from HQ_ShareZone_Article ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			HQ.Model.ShareZoneArticleModel model=new HQ.Model.ShareZoneArticleModel();
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
		public HQ.Model.ShareZoneArticleModel DataRowToModel(DataRow row)
		{
			HQ.Model.ShareZoneArticleModel model=new HQ.Model.ShareZoneArticleModel();
			if (row != null)
			{
				if(row["ShareId"]!=null && row["ShareId"].ToString()!="")
				{
					model.ShareId=int.Parse(row["ShareId"].ToString());
				}
				if(row["ShareContent"]!=null)
				{
					model.ShareContent=row["ShareContent"].ToString();
				}
				if(row["ShareImgList"]!=null)
				{
					model.ShareImgList=row["ShareImgList"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["ShareCount"]!=null && row["ShareCount"].ToString()!="")
				{
					model.ShareCount=int.Parse(row["ShareCount"].ToString());
				}
				if(row["GoodsId"]!=null)
				{
					model.GoodsId=row["GoodsId"].ToString();
				}
				if(row["PromotionAmount"]!=null && row["PromotionAmount"].ToString()!="")
				{
					model.PromotionAmount=decimal.Parse(row["PromotionAmount"].ToString());
				}
				if(row["CatId"]!=null && row["CatId"].ToString()!="")
				{
					model.CatId=int.Parse(row["CatId"].ToString());
				}
				if(row["ShowTime"]!=null && row["ShowTime"].ToString()!="")
				{
					model.ShowTime=DateTime.Parse(row["ShowTime"].ToString());
				}
				if(row["HideTime"]!=null && row["HideTime"].ToString()!="")
				{
					model.HideTime=DateTime.Parse(row["HideTime"].ToString());
				}
				if(row["VideoList"]!=null)
				{
					model.VideoList=row["VideoList"].ToString();
				}
				if(row["PlatType"]!=null && row["PlatType"].ToString()!="")
				{
					model.PlatType=int.Parse(row["PlatType"].ToString());
				}
			}
			return model;
		}

		#endregion  BasicMethod
		
	}
}

