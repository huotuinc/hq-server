using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;
using System.Collections.Generic;

namespace HQ.DAL
{
    /// <summary>
    /// 用户收藏数据访问层
    /// </summary>
    public partial class UserFavoriteDAL
	{
		public UserFavoriteDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.UserFavoriteModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_Favorite(");
			strSql.Append("UserId,GoodsId,CreateTime,PlatType)");
			strSql.Append(" values (");
			strSql.Append("@UserId,@GoodsId,@CreateTime,@PlatType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.BigInt,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.GoodsId;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.PlatType;

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
		public bool Update(HQ.Model.UserFavoriteModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_Favorite set ");
			strSql.Append("UserId=@UserId,");
			strSql.Append("GoodsId=@GoodsId,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("PlatType=@PlatType");
			strSql.Append(" where FavId=@FavId");
			SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@GoodsId", SqlDbType.BigInt,8),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@FavId", SqlDbType.Int,4)};
			parameters[0].Value = model.UserId;
			parameters[1].Value = model.GoodsId;
			parameters[2].Value = model.CreateTime;
			parameters[3].Value = model.PlatType;
			parameters[4].Value = model.FavId;

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
		public bool Delete(int FavId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_User_Favorite ");
			strSql.Append(" where FavId=@FavId");
			SqlParameter[] parameters = {
					new SqlParameter("@FavId", SqlDbType.Int,4)
			};
			parameters[0].Value = FavId;

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
		public HQ.Model.UserFavoriteModel GetModel(int FavId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FavId,UserId,GoodsId,CreateTime,PlatType from HQ_User_Favorite ");
			strSql.Append(" where FavId=@FavId");
			SqlParameter[] parameters = {
					new SqlParameter("@FavId", SqlDbType.Int,4)
			};
			parameters[0].Value = FavId;

			HQ.Model.UserFavoriteModel model=new HQ.Model.UserFavoriteModel();
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
		public HQ.Model.UserFavoriteModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserFavoriteModel model=new HQ.Model.UserFavoriteModel();
			if (row != null)
			{
				if(row["FavId"]!=null && row["FavId"].ToString()!="")
				{
					model.FavId=int.Parse(row["FavId"].ToString());
				}
				if(row["UserId"]!=null && row["UserId"].ToString()!="")
				{
					model.UserId=int.Parse(row["UserId"].ToString());
				}
				if(row["GoodsId"]!=null && row["GoodsId"].ToString()!="")
				{
					model.GoodsId=long.Parse(row["GoodsId"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["PlatType"]!=null && row["PlatType"].ToString()!="")
				{
					model.PlatType=Int16.Parse(row["PlatType"].ToString());
				}
			}
			return model;
		}

        #endregion  BasicMethod


        public HQ.Model.UserFavoriteModel GetModel(int UserId, long GoodsId, Int16 platType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_User_Favorite  where UserId=@UserId and GoodsId=@GoodsId and PlatType=@PlatType");
            var parameters = new[]{
                    new SqlParameter("@UserId",UserId),
                    new SqlParameter("@GoodsId",GoodsId),
                    new SqlParameter("@PlatType",platType)
            };
            UserFavoriteModel model = null;
            using (IDataReader dr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                model = DbHelperSQL.GetEntity<UserFavoriteModel>(dr);
            }
            return model;
        }


        public List<UserFavoriteModel> list(int userId, int platType)
        {
            List<UserFavoriteModel> list = new List<UserFavoriteModel>();
            string strsql = @"select * from HQ_User_Favorite  where UserId=@UserId and PlatType=@PlatType";
             var parameters = new[]{
                    new SqlParameter("@UserId",userId),
                    new SqlParameter("@PlatType",platType)
            };
            using (IDataReader dr = DbHelperSQL.ExecuteReader(strsql))
            {
                list = DbHelperSQL.GetEntityList<UserFavoriteModel>(dr);
            }
            return list;
        }
    }
}

