using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;

namespace HQ.DAL
{
    /// <summary>
    /// 多多客主题数据访问层
    /// </summary>
    public partial class DdkThemeDAL
	{
		public DdkThemeDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(DdkThemeModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HQ_Ddk_Theme(");
			strSql.Append("ThemeId,ImageUrl,Name,GoodsNum,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@ThemeId,@ImageUrl,@Name,@GoodsNum,@UpdateTime)");
			SqlParameter[] parameters = {
					new SqlParameter("@ThemeId", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@GoodsNum", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ThemeId;
			parameters[1].Value = model.ImageUrl;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.GoodsNum;
			parameters[4].Value = model.UpdateTime;

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
		public bool Update(DdkThemeModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HQ_Ddk_Theme set ");
			strSql.Append("ThemeId=@ThemeId,");
			strSql.Append("ImageUrl=@ImageUrl,");
			strSql.Append("Name=@Name,");
			strSql.Append("GoodsNum=@GoodsNum,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ThemeId", SqlDbType.Int,4),
					new SqlParameter("@ImageUrl", SqlDbType.VarChar,300),
					new SqlParameter("@Name", SqlDbType.VarChar,150),
					new SqlParameter("@GoodsNum", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.ThemeId;
			parameters[1].Value = model.ImageUrl;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.GoodsNum;
			parameters[4].Value = model.UpdateTime;

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
		public bool Delete(int ThemeId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Ddk_Theme ");
            strSql.Append(" where ThemeId=@ThemeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ThemeId", SqlDbType.Int,4)           };
            parameters[0].Value = ThemeId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public DdkThemeModel GetModel(int ThemeId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Ddk_Theme ");
            strSql.Append(" where ThemeId=@ThemeId ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ThemeId", SqlDbType.Int,4)           };
            parameters[0].Value = ThemeId;

            DdkThemeModel model = new DdkThemeModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public DdkThemeModel DataRowToModel(DataRow row)
		{
			DdkThemeModel model=new DdkThemeModel();
			if (row != null)
			{
				if(row["ThemeId"]!=null && row["ThemeId"].ToString()!="")
				{
					model.ThemeId=int.Parse(row["ThemeId"].ToString());
				}
				if(row["ImageUrl"]!=null)
				{
					model.ImageUrl=row["ImageUrl"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["GoodsNum"]!=null && row["GoodsNum"].ToString()!="")
				{
					model.GoodsNum=int.Parse(row["GoodsNum"].ToString());
				}
				if(row["UpdateTime"]!=null && row["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(row["UpdateTime"].ToString());
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
            string sql = "select * FROM HQ_Ddk_Theme where 1=1 ";
            if (strWhere.Trim() != "")
            {
                sql += strWhere;
            }
            sql += " ORDER BY ThemeId DESC";
            return DbHelperSQL.GetSplitDataTable(sql, pageSize, pageIndex, out recordCount);
        }

        #endregion  BasicMethod

    }
}

