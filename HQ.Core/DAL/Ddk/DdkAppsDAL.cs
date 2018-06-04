using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;

namespace HQ.DAL
{
	/// <summary>
	/// 多多客应用数据访问层
	/// </summary>
	public partial class DdkAppsDAL
	{
		public DdkAppsDAL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(DdkAppsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Ddk_Apps(");
			strSql.Append("AgentId,ClientId,ClientSecret,IsMain,Status,BindAgentId)");
			strSql.Append(" values (");
			strSql.Append("@AgentId,@ClientId,@ClientSecret,@IsMain,@Status,@BindAgentId)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@ClientId", SqlDbType.VarChar,50),
					new SqlParameter("@ClientSecret", SqlDbType.VarChar,50),
					new SqlParameter("@IsMain", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@BindAgentId", SqlDbType.Int,4)};
			parameters[0].Value = model.AgentId;
			parameters[1].Value = model.ClientId;
			parameters[2].Value = model.ClientSecret;
			parameters[3].Value = model.IsMain;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.BindAgentId;

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
		public bool Update(DdkAppsModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Ddk_Apps set ");
			strSql.Append("AgentId=@AgentId,");
			strSql.Append("ClientId=@ClientId,");
			strSql.Append("ClientSecret=@ClientSecret,");
			strSql.Append("IsMain=@IsMain,");
			strSql.Append("Status=@Status,");
			strSql.Append("BindAgentId=@BindAgentId");
			strSql.Append(" where AppId=@AppId");
			SqlParameter[] parameters = {
					new SqlParameter("@AgentId", SqlDbType.Int,4),
					new SqlParameter("@ClientId", SqlDbType.VarChar,50),
					new SqlParameter("@ClientSecret", SqlDbType.VarChar,50),
					new SqlParameter("@IsMain", SqlDbType.TinyInt,1),
					new SqlParameter("@Status", SqlDbType.TinyInt,1),
					new SqlParameter("@BindAgentId", SqlDbType.Int,4),
					new SqlParameter("@AppId", SqlDbType.Int,4)};
			parameters[0].Value = model.AgentId;
			parameters[1].Value = model.ClientId;
			parameters[2].Value = model.ClientSecret;
			parameters[3].Value = model.IsMain;
			parameters[4].Value = model.Status;
			parameters[5].Value = model.BindAgentId;
			parameters[6].Value = model.AppId;

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
		public bool Delete(int AppId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HQ_Ddk_Apps ");
			strSql.Append(" where AppId=@AppId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppId", SqlDbType.Int,4)
			};
			parameters[0].Value = AppId;

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
		public DdkAppsModel GetModel(int AppId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 * from HQ_Ddk_Apps ");
			strSql.Append(" where AppId=@AppId");
			SqlParameter[] parameters = {
					new SqlParameter("@AppId", SqlDbType.Int,4)
			};
			parameters[0].Value = AppId;

			DdkAppsModel model=new DdkAppsModel();
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
		public DdkAppsModel DataRowToModel(DataRow row)
		{
			DdkAppsModel model=new DdkAppsModel();
			if (row != null)
			{
				if(row["AppId"]!=null && row["AppId"].ToString()!="")
				{
					model.AppId=int.Parse(row["AppId"].ToString());
				}
				if(row["AgentId"]!=null && row["AgentId"].ToString()!="")
				{
					model.AgentId=int.Parse(row["AgentId"].ToString());
				}
				if(row["ClientId"]!=null)
				{
					model.ClientId=row["ClientId"].ToString();
				}
				if(row["ClientSecret"]!=null)
				{
					model.ClientSecret=row["ClientSecret"].ToString();
				}
				if(row["IsMain"]!=null && row["IsMain"].ToString()!="")
				{
					model.IsMain=int.Parse(row["IsMain"].ToString());
				}
				if(row["Status"]!=null && row["Status"].ToString()!="")
				{
					model.Status=int.Parse(row["Status"].ToString());
				}
				if(row["BindAgentId"]!=null && row["BindAgentId"].ToString()!="")
				{
					model.BindAgentId=int.Parse(row["BindAgentId"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public DataTable GetList(int pageSize, int pageIndex, out int recordCount)
        {
            return this.GetList(pageSize, pageIndex, "", out recordCount);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="iPageSize"></param>
        /// <param name="iPageIndex"></param>
        /// <param name="strWhere"></param>
        /// <param name="iRecordCount"></param>
        /// <returns></returns>
        private DataTable GetList(int pageSize, int pageIndex, string strWhere, out int recordCount)
        {
            string sql = "select * FROM HQ_Ddk_Apps where 1=1 ";
            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }
            sql += " ORDER BY AppId DESC";
            return DbHelperSQL.GetSplitDataTable(sql, pageSize, pageIndex, out recordCount);
        }
        #endregion  BasicMethod
    }
}

