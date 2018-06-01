using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;

namespace HQ.DAL
{
    /// <summary>
    /// 代理商数据访问层
    /// </summary>
    public partial class AgentsDAL
	{
		public AgentsDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HQ.Model.AgentsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Agents(");
			strSql.Append("AgentType,NickName,LoginName,Password,Status,Createtime,LastLoginIp,LastLoginTime,Remark)");
			strSql.Append(" values (");
			strSql.Append("@AgentType,@NickName,@LoginName,@Password,@Status,@Createtime,@LastLoginIp,@LastLoginTime,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentType", SqlDbType.SmallInt,2),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@Password", SqlDbType.VarChar,40),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIp", SqlDbType.VarChar,30),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250)};
			parameters[0].Value = model.AgentType;
			parameters[1].Value = model.NickName;
			parameters[2].Value = model.LoginName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Createtime;
			parameters[6].Value = model.LastLoginIp;
			parameters[7].Value = model.LastLoginTime;
			parameters[8].Value = model.Remark;

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
		public bool Update(HQ.Model.AgentsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Agents set ");
			strSql.Append("AgentType=@AgentType,");
			strSql.Append("NickName=@NickName,");
			strSql.Append("LoginName=@LoginName,");
			strSql.Append("Password=@Password,");
			strSql.Append("Status=@Status,");
			strSql.Append("Createtime=@Createtime,");
			strSql.Append("LastLoginIp=@LastLoginIp,");
			strSql.Append("LastLoginTime=@LastLoginTime,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where AgentId=@AgentId");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentType", SqlDbType.SmallInt,2),
					new SqlParameter("@NickName", SqlDbType.VarChar,50),
					new SqlParameter("@LoginName", SqlDbType.VarChar,30),
					new SqlParameter("@Password", SqlDbType.VarChar,40),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@Createtime", SqlDbType.DateTime),
					new SqlParameter("@LastLoginIp", SqlDbType.VarChar,30),
					new SqlParameter("@LastLoginTime", SqlDbType.DateTime),
					new SqlParameter("@Remark", SqlDbType.VarChar,250),
					new SqlParameter("@AgentId", SqlDbType.Int,4)};
			parameters[0].Value = model.AgentType;
			parameters[1].Value = model.NickName;
			parameters[2].Value = model.LoginName;
			parameters[3].Value = model.Password;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.Createtime;
			parameters[6].Value = model.LastLoginIp;
			parameters[7].Value = model.LastLoginTime;
			parameters[8].Value = model.Remark;
			parameters[9].Value = model.AgentId;

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
		public bool Delete(int AgentId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_Agents ");
			strSql.Append(" where AgentId=@AgentId");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentId", SqlDbType.Int,4)
			};
			parameters[0].Value = AgentId;

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
		public HQ.Model.AgentsModel GetModel(int AgentId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_Agents ");
			strSql.Append(" where AgentId=@AgentId");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentId", SqlDbType.Int,4)
			};
			parameters[0].Value = AgentId;

			HQ.Model.AgentsModel model=new HQ.Model.AgentsModel();
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
		public HQ.Model.AgentsModel DataRowToModel(DataRow row)
		{
			HQ.Model.AgentsModel model=new HQ.Model.AgentsModel();
			if (row != null)
			{
				if(row["AgentId"]!=null && row["AgentId"].ToString()!="")
				{
					model.AgentId=int.Parse(row["AgentId"].ToString());
				}
				if(row["AgentType"]!=null && row["AgentType"].ToString()!="")
				{
					model.AgentType=int.Parse(row["AgentType"].ToString());
				}
				if(row["NickName"]!=null)
				{
					model.NickName=row["NickName"].ToString();
				}
				if(row["LoginName"]!=null)
				{
					model.LoginName=row["LoginName"].ToString();
				}
				if(row["Password"]!=null)
				{
					model.Password=row["Password"].ToString();
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["Createtime"]!=null && row["Createtime"].ToString()!="")
				{
					model.Createtime=DateTime.Parse(row["Createtime"].ToString());
				}
				if(row["LastLoginIp"]!=null)
				{
					model.LastLoginIp=row["LastLoginIp"].ToString();
				}
				if(row["LastLoginTime"]!=null && row["LastLoginTime"].ToString()!="")
				{
					model.LastLoginTime=DateTime.Parse(row["LastLoginTime"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
				}
			}
			return model;
		}
        
		#endregion  BasicMethod
		
	}
}

