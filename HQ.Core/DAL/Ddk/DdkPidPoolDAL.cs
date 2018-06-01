using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;

namespace HQ.DAL
{
    /// <summary>
    /// 多多客PID池数据访问层
    /// </summary>
    public partial class DdkPidPoolDAL
	{
		public DdkPidPoolDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DdkPidPoolModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Ddk_PidPool(");
			strSql.Append("PId,AppId,UseStatus)");
			strSql.Append(" values (");
			strSql.Append("@PId,@AppId,@UseStatus)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.VarChar,20),
					new SqlParameter("@AppId", SqlDbType.Int,4),
					new SqlParameter("@UseStatus", SqlDbType.Bit,1)};
			parameters[0].Value = model.PId;
			parameters[1].Value = model.AppId;
			parameters[2].Value = model.UseStatus;

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
		public bool Update(DdkPidPoolModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Ddk_PidPool set ");
			strSql.Append("PId=@PId,");
			strSql.Append("AppId=@AppId,");
			strSql.Append("UseStatus=@UseStatus");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.VarChar,20),
					new SqlParameter("@AppId", SqlDbType.Int,4),
					new SqlParameter("@UseStatus", SqlDbType.Bit,1),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.PId;
			parameters[1].Value = model.AppId;
			parameters[2].Value = model.UseStatus;
			parameters[3].Value = model.Id;

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
			strSql.Append("delete from HQ_Ddk_PidPool ");
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
		public DdkPidPoolModel GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,PId,AppId,UseStatus from HQ_Ddk_PidPool ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			DdkPidPoolModel model=new DdkPidPoolModel();
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
		public DdkPidPoolModel DataRowToModel(DataRow row)
		{
			DdkPidPoolModel model=new DdkPidPoolModel();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["PId"]!=null)
				{
					model.PId=row["PId"].ToString();
				}
				if(row["AppId"]!=null && row["AppId"].ToString()!="")
				{
					model.AppId=int.Parse(row["AppId"].ToString());
				}
				if(row["UseStatus"]!=null && row["UseStatus"].ToString()!="")
				{
					if((row["UseStatus"].ToString()=="1")||(row["UseStatus"].ToString().ToLower()=="true"))
					{
						model.UseStatus=true;
					}
					else
					{
						model.UseStatus=false;
					}
				}
			}
			return model;
		}

		#endregion  BasicMethod
		
	}
}

