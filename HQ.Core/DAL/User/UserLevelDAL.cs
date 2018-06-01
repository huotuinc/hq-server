using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 用户等级数据访问层
    /// </summary>
    public partial class UserLevelDAL
	{
		public UserLevelDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.UserLevelModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_User_Level(");
			strSql.Append("LevelNo,LevelName,Remark,Createtime,UpgradeCondition)");
			strSql.Append(" values (");
			strSql.Append("@LevelNo,@LevelName,@Remark,@Createtime,@UpgradeCondition)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelNo", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@UpgradeCondition", SqlDbType.VarChar,-1)};
			parameters[0].Value = model.LevelNo;
			parameters[1].Value = model.LevelName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Createtime;
			parameters[4].Value = model.UpgradeCondition;

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
		public bool Update(HQ.Model.UserLevelModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_User_Level set ");
			strSql.Append("LevelNo=@LevelNo,");
			strSql.Append("LevelName=@LevelName,");
			strSql.Append("Remark=@Remark,");
			strSql.Append("Createtime=@Createtime,");
			strSql.Append("UpgradeCondition=@UpgradeCondition");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelNo", SqlDbType.Int,4),
					new SqlParameter("@LevelName", SqlDbType.VarChar,50),
					new SqlParameter("@Remark", SqlDbType.VarChar,500),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@UpgradeCondition", SqlDbType.VarChar,-1),
					new SqlParameter("@LevelId", SqlDbType.Int,4)};
			parameters[0].Value = model.LevelNo;
			parameters[1].Value = model.LevelName;
			parameters[2].Value = model.Remark;
			parameters[3].Value = model.Createtime;
			parameters[4].Value = model.UpgradeCondition;
			parameters[5].Value = model.LevelId;

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
		public bool Delete(int LevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_User_Level ");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = LevelId;

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
		public HQ.Model.UserLevelModel GetModel(int LevelId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LevelId,LevelNo,LevelName,Remark,Createtime,UpgradeCondition from HQ_User_Level ");
			strSql.Append(" where LevelId=@LevelId");
			SqlParameter[] parameters = {
					new SqlParameter("@LevelId", SqlDbType.Int,4)
			};
			parameters[0].Value = LevelId;

			HQ.Model.UserLevelModel model=new HQ.Model.UserLevelModel();
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
		public HQ.Model.UserLevelModel DataRowToModel(DataRow row)
		{
			HQ.Model.UserLevelModel model=new HQ.Model.UserLevelModel();
			if (row != null)
			{
				if(row["LevelId"]!=null && row["LevelId"].ToString()!="")
				{
					model.LevelId=int.Parse(row["LevelId"].ToString());
				}
				if(row["LevelNo"]!=null && row["LevelNo"].ToString()!="")
				{
					model.LevelNo=int.Parse(row["LevelNo"].ToString());
				}
				if(row["LevelName"]!=null)
				{
					model.LevelName=row["LevelName"].ToString();
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
				if(row["Createtime"]!=null && row["Createtime"].ToString()!="")
				{
					model.Createtime=DateTime.Parse(row["Createtime"].ToString());
				}
				if(row["UpgradeCondition"]!=null)
				{
					model.UpgradeCondition=row["UpgradeCondition"].ToString();
				}
			}
			return model;
		}
        
		#endregion  BasicMethod
		
	}
}

