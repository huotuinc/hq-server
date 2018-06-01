using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;

namespace HQ.DAL
{
	/// <summary>
	/// 广告位数据访问层
	/// </summary>
	public partial class AdvertiseDAL
	{
		public AdvertiseDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(AdvertiseModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Advertise(");
			strSql.Append("AdType,LinkPic,LinkData,LinkType,Status,CreateTime,BeginTime,EndTime,SortNum,Title,Remark,PlatType)");
			strSql.Append(" values (");
			strSql.Append("@AdType,@LinkPic,@LinkData,@LinkType,@Status,@CreateTime,@BeginTime,@EndTime,@SortNum,@Title,@Remark,@PlatType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AdType", SqlDbType.SmallInt,2),
					new SqlParameter("@LinkPic", SqlDbType.VarChar,300),
					new SqlParameter("@LinkData", SqlDbType.VarChar,400),
					new SqlParameter("@LinkType", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,150),
					new SqlParameter("@Remark", SqlDbType.VarChar,150),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
			parameters[0].Value = model.AdType;
			parameters[1].Value = model.LinkPic;
			parameters[2].Value = model.LinkData;
			parameters[3].Value = model.LinkType;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.BeginTime;
			parameters[7].Value = model.EndTime;
			parameters[8].Value = model.SortNum;
			parameters[9].Value = model.Title;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.PlatType;

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
		public bool Update(AdvertiseModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Advertise set ");
			strSql.Append("AdType=@AdType,");
			strSql.Append("LinkPic=@LinkPic,");
			strSql.Append("LinkData=@LinkData,");
			strSql.Append("LinkType=@LinkType,");
			strSql.Append("Status=@Status,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("BeginTime=@BeginTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("SortNum=@SortNum,");
			strSql.Append("Title=@Title,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("PlatType=@PlatType");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdType", SqlDbType.SmallInt,2),
					new SqlParameter("@LinkPic", SqlDbType.VarChar,300),
					new SqlParameter("@LinkData", SqlDbType.VarChar,400),
					new SqlParameter("@LinkType", SqlDbType.SmallInt,2),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@SortNum", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,150),
					new SqlParameter("@Remark", SqlDbType.VarChar,150),
					new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
					new SqlParameter("@AdId", SqlDbType.Int,4)};
			parameters[0].Value = model.AdType;
			parameters[1].Value = model.LinkPic;
			parameters[2].Value = model.LinkData;
			parameters[3].Value = model.LinkType;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.BeginTime;
			parameters[7].Value = model.EndTime;
			parameters[8].Value = model.SortNum;
			parameters[9].Value = model.Title;
			parameters[10].Value = model.Remark;
			parameters[11].Value = model.PlatType;
			parameters[12].Value = model.AdId;

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
		public bool Delete(int AdId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_Advertise ");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdId;

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
		public AdvertiseModel GetModel(int AdId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_Advertise ");
			strSql.Append(" where AdId=@AdId");
			SqlParameter[] parameters = {
					new SqlParameter("@AdId", SqlDbType.Int,4)
			};
			parameters[0].Value = AdId;

			AdvertiseModel model=new AdvertiseModel();
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
		public AdvertiseModel DataRowToModel(DataRow row)
		{
			AdvertiseModel model=new AdvertiseModel();
			if (row != null)
			{
				if(row["AdId"]!=null && row["AdId"].ToString()!="")
				{
					model.AdId=int.Parse(row["AdId"].ToString());
				}
				if(row["AdType"]!=null && row["AdType"].ToString()!="")
				{
					model.AdType=int.Parse(row["AdType"].ToString());
				}
				if(row["LinkPic"]!=null)
				{
					model.LinkPic=row["LinkPic"].ToString();
				}
				if(row["LinkData"]!=null)
				{
					model.LinkData=row["LinkData"].ToString();
				}
				if(row["LinkType"]!=null && row["LinkType"].ToString()!="")
				{
					model.LinkType=int.Parse(row["LinkType"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
				if(row["BeginTime"]!=null && row["BeginTime"].ToString()!="")
				{
					model.BeginTime=DateTime.Parse(row["BeginTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["SortNum"]!=null && row["SortNum"].ToString()!="")
				{
					model.SortNum=int.Parse(row["SortNum"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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

