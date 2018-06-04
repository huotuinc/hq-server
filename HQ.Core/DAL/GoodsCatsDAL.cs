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
    /// 商品分类数据访问层
    /// </summary>
    public partial class GoodsCatsDAL
    {
        public GoodsCatsDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoodsCatsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Goods_Cats(");
            strSql.Append("Id,PlatType,Name,ParentId,LevelNo,Icon,SortNum,Status)");
            strSql.Append(" values (");
            strSql.Append("@Id,@PlatType,@Name,@ParentId,@LevelNo,@Icon,@SortNum,@Status)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2),
                    new SqlParameter("@Name", SqlDbType.VarChar,30),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@LevelNo", SqlDbType.Int,4),
                    new SqlParameter("@Icon", SqlDbType.VarChar,300),
                    new SqlParameter("@SortNum", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.PlatType;
            parameters[2].Value = model.Name;
            parameters[3].Value = model.ParentId;
            parameters[4].Value = model.LevelNo;
            parameters[5].Value = model.Icon;
            parameters[6].Value = model.SortNum;
            parameters[7].Value = model.Status;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(GoodsCatsModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Goods_Cats set ");
            strSql.Append("Name=@Name,");
            strSql.Append("ParentId=@ParentId,");
            strSql.Append("LevelNo=@LevelNo,");
            strSql.Append("Icon=@Icon,");
            strSql.Append("SortNum=@SortNum,");
            strSql.Append("Status=@Status");
            strSql.Append(" where Id=@Id and PlatType=@PlatType ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Name", SqlDbType.VarChar,30),
                    new SqlParameter("@ParentId", SqlDbType.Int,4),
                    new SqlParameter("@LevelNo", SqlDbType.Int,4),
                    new SqlParameter("@Icon", SqlDbType.VarChar,300),
                    new SqlParameter("@SortNum", SqlDbType.Int,4),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.ParentId;
            parameters[2].Value = model.LevelNo;
            parameters[3].Value = model.Icon;
            parameters[4].Value = model.SortNum;
            parameters[5].Value = model.Status;
            parameters[6].Value = model.Id;
            parameters[7].Value = model.PlatType;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id, int PlatType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Goods_Cats ");
            strSql.Append(" where Id=@Id and PlatType=@PlatType ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2)         };
            parameters[0].Value = Id;
            parameters[1].Value = PlatType;

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
        public GoodsCatsModel GetModel(int Id, int PlatType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Goods_Cats ");
            strSql.Append(" where Id=@Id and PlatType=@PlatType ");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2)         };
            parameters[0].Value = Id;
            parameters[1].Value = PlatType;

            GoodsCatsModel model = new GoodsCatsModel();
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
        public GoodsCatsModel DataRowToModel(DataRow row)
        {
            GoodsCatsModel model = new GoodsCatsModel();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["PlatType"] != null && row["PlatType"].ToString() != "")
                {
                    model.PlatType = int.Parse(row["PlatType"].ToString());
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["ParentId"] != null && row["ParentId"].ToString() != "")
                {
                    model.ParentId = int.Parse(row["ParentId"].ToString());
                }
                if (row["LevelNo"] != null && row["LevelNo"].ToString() != "")
                {
                    model.LevelNo = int.Parse(row["LevelNo"].ToString());
                }
                if (row["Icon"] != null)
                {
                    model.Icon = row["Icon"].ToString();
                }
                if (row["SortNum"] != null && row["SortNum"].ToString() != "")
                {
                    model.SortNum = int.Parse(row["SortNum"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获取某个平台的所有分类
        /// </summary>
        /// <param name="platType"></param>
        /// <returns></returns>
        public List<GoodsCatsModel> GetList(int platType)
        {
            string sql = string.Format("SELECT * FROM HQ_Goods_Cats WHERE PlatType={0} ORDER BY SortNum,Id", platType);
            var dt = DbHelperSQL.Query(sql).Tables[0];
            List<GoodsCatsModel> goodsCats = new List<GoodsCatsModel>();
            foreach (DataRow dr in dt.Rows)
            {
                goodsCats.Add(this.DataRowToModel(dr));
            }
            return goodsCats;
        }

        public DataTable GetListScheme()
        {
            return DbHelperSQL.Query("select * from HQ_Goods_Cats where 1<>1").Tables[0];
        }

        /// <summary>
        /// 得到某个序号后面一个
        /// </summary>
        /// <param name="sortNum"></param>
        /// <returns></returns>
        public GoodsCatsModel GetNext(int sortNum, int platType)
        {
            DataTable dt = DbHelperSQL.Query(string.Format("select top 1 * from HQ_Goods_Cats where SortNum>{0} and PlatType={1} order by SortNum asc", sortNum, platType)).Tables[0];
            if (dt.Rows.Count == 0) return null;
            return this.DataRowToModel(dt.Rows[0]);
        }

        /// <summary>
        /// 得到某个序号前面一个
        /// </summary>
        /// <param name="sortNum"></param>
        /// <returns></returns>
        public GoodsCatsModel GetPrev(int sortNum, int platType)
        {
            DataTable dt = DbHelperSQL.Query(string.Format("select top 1 * from HQ_Goods_Cats where SortNum<{0} and PlatType={1} order by SortNum desc", sortNum, platType)).Tables[0];
            if (dt.Rows.Count == 0) return null;
            return this.DataRowToModel(dt.Rows[0]);
        }
        #endregion  BasicMethod

    }
}

