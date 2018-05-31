using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using HQ.Core.Model.Gallery;
using HQ.Common.DB;

namespace HQ.Core.DAL.Gallery
{
    /// <summary>
    /// 图片分组数据访问层
    /// </summary>
    public partial class PhotoGroupDAL : BaseDAL
    {
        public PhotoGroupDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PhotoGroupModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_PhotoGroup(");
            strSql.Append("PhotoName,FatherID,Photo_Customer_ID,Photo_Cover,Photo_Time,FilePath)");
            strSql.Append(" values (");
            strSql.Append("@PhotoName,@FatherID,@Photo_Customer_ID,@Photo_Cover,@Photo_Time,@FilePath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoName", SqlDbType.VarChar,100),
					new SqlParameter("@FatherID", SqlDbType.Int,4),
					new SqlParameter("@Photo_Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Photo_Cover", SqlDbType.VarChar,500),
					new SqlParameter("@Photo_Time", SqlDbType.DateTime),
                    new SqlParameter("@FilePath",SqlDbType.VarChar)};
            parameters[0].Value = model.PhotoName;
            parameters[1].Value = model.FatherID;
            parameters[2].Value = model.Photo_Customer_ID;
            parameters[3].Value = model.Photo_Cover;
            parameters[4].Value = model.Photo_Time;
            parameters[5].Value = model.FilePath;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(PhotoGroupModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_PhotoGroup set ");
            strSql.Append("PhotoName=@PhotoName,");
            strSql.Append("FatherID=@FatherID,");
            strSql.Append("Photo_Customer_ID=@Photo_Customer_ID,");
            strSql.Append("Photo_Cover=@Photo_Cover,");
            strSql.Append("Photo_Time=@Photo_Time,");
            strSql.Append("FilePath=@FilePath ");
            strSql.Append(" where PhotoID=@PhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoName", SqlDbType.VarChar,100),
					new SqlParameter("@FatherID", SqlDbType.Int,4),
					new SqlParameter("@Photo_Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Photo_Cover", SqlDbType.VarChar,500),
					new SqlParameter("@Photo_Time", SqlDbType.DateTime),
					new SqlParameter("@PhotoID", SqlDbType.Int,4),
                    new SqlParameter("@FilePath",SqlDbType.VarChar)};
            parameters[0].Value = model.PhotoName;
            parameters[1].Value = model.FatherID;
            parameters[2].Value = model.Photo_Customer_ID;
            parameters[3].Value = model.Photo_Cover;
            parameters[4].Value = model.Photo_Time;
            parameters[5].Value = model.PhotoID;
            parameters[6].Value = model.FilePath;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PhotoIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_PhotoGroup ");
            strSql.Append(" where PhotoID in (" + PhotoIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public PhotoGroupModel GetModel(int PhotoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PhotoID,PhotoName,FatherID,Photo_Customer_ID,Photo_Cover,Photo_Time,FilePath from HQ_PhotoGroup ");
            strSql.Append(" where PhotoID=@PhotoID");
            SqlParameter[] parameters = {
					new SqlParameter("@PhotoID", SqlDbType.Int,4)
			};
            parameters[0].Value = PhotoID;

            PhotoGroupModel model = new PhotoGroupModel();
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
        public PhotoGroupModel DataRowToModel(DataRow row)
        {
            PhotoGroupModel model = new PhotoGroupModel();
            if (row != null)
            {
                if (row["PhotoID"] != null && row["PhotoID"].ToString() != "")
                {
                    model.PhotoID = int.Parse(row["PhotoID"].ToString());
                }
                if (row["PhotoName"] != null)
                {
                    model.PhotoName = row["PhotoName"].ToString();
                }
                if (row["FatherID"] != null && row["FatherID"].ToString() != "")
                {
                    model.FatherID = int.Parse(row["FatherID"].ToString());
                }
                if (row["Photo_Customer_ID"] != null && row["Photo_Customer_ID"].ToString() != "")
                {
                    model.Photo_Customer_ID = int.Parse(row["Photo_Customer_ID"].ToString());
                }
                if (row["Photo_Cover"] != null)
                {
                    model.Photo_Cover = row["Photo_Cover"].ToString();
                }
                if (row["Photo_Time"] != null && row["Photo_Time"].ToString() != "")
                {
                    model.Photo_Time = DateTime.Parse(row["Photo_Time"].ToString());
                }
                if (row["FilePath"] != null && row["FilePath"].ToString() != "")
                {
                    model.FilePath = row["FilePath"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ResultMallPhotoGroup DataRowToResultModel(DataRow row) {
            ResultMallPhotoGroup model = new ResultMallPhotoGroup();
            if (row != null) {
                if (row["PhotoID"] != null && row["PhotoID"].ToString() != "") {
                    model.id = int.Parse(row["PhotoID"].ToString());
                }
                if (row["PhotoName"] != null) {
                    model.name = row["PhotoName"].ToString();
                }
                if (row["FatherID"] != null && row["FatherID"].ToString() != "") {
                    model.parentId = int.Parse(row["FatherID"].ToString());
                }
                if (row["Photo_Customer_ID"] != null && row["Photo_Customer_ID"].ToString() != "") {
                    model.customerId = int.Parse(row["Photo_Customer_ID"].ToString());
                }
                if (row["Photo_Cover"] != null) {
                    model.thumb = row["Photo_Cover"].ToString();
                }
                if (row["Photo_Time"] != null && row["Photo_Time"].ToString() != "") {
                    model.createTime = DateTime.Parse(row["Photo_Time"].ToString());
                }
                if (row["FilePath"] != null && row["FilePath"].ToString() != "") {
                    model.path = row["FilePath"].ToString();
                }
                if (row["counts"] != null && row["counts"].ToString() != "") {
                    model.count = Convert.ToInt32(row["counts"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PhotoID,PhotoName,FatherID,Photo_Customer_ID,Photo_Cover,Photo_Time,FilePath ");
            strSql.Append(" FROM HQ_PhotoGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PhotoID,PhotoName,FatherID,Photo_Customer_ID,Photo_Cover,Photo_Time,FilePath ");
            strSql.Append(" FROM HQ_PhotoGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM HQ_PhotoGroup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PhotoID desc");
            }
            strSql.Append(")AS Row, T.*  from HQ_PhotoGroup T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable GetPhotoList(int customid, int fileid, int page, int pageSize, out int recordcount)
        {
            string sql = string.Format(@"SELECT * FROM (SELECT PhotoID AS PFId,Photo_Cover AS PFUrl,PhotoName AS PFName,'' AS PFSize, FatherID AS PFatherId,0 AS PFCate FROM dbo.HQ_PhotoGroup WHERE Photo_Customer_ID={0} and FatherID={1} 
 UNION ALL  
SELECT Callery_ID AS PFId,Callery_BigPic AS PFUrl,Callery_Name AS PFName,Callery_Size AS PFSize,Photo_FatherID AS PFatherId,1 AS PFCate FROM dbo.HQ_Gallery WHERE Callery_Customer_ID={0} and Photo_FatherID={1}) AS A ", customid, fileid);
            return DbHelperSQL.GetSplitDataTableV2(sql.ToString(), pageSize, page, out recordcount, " PFCate ASC,PFId  ", OrderSort.OrderByDesc);
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "HQ_PhotoGroup";
            parameters[1].Value = "PhotoID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod
        public List<ResultMallPhotoGroup> GetPhotoGroupList(int customerId) {
            List<ResultMallPhotoGroup> list = null;
            string sql = string.Format(@"select PhotoID,PhotoName,FatherID,Photo_Customer_ID,Photo_Cover,Photo_Time,FilePath,
                                        (select COUNT(Callery_ID) from HQ_Gallery where Callery_Customer_ID={0} and Photo_FatherID=b.PhotoID) as counts    
                                        from HQ_PhotoGroup as b where Photo_Customer_ID={0} order by Photo_Time desc", customerId);
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt != null && dt.Rows.Count > 0) {
                list = new List<ResultMallPhotoGroup>();
                list.Add(new ResultMallPhotoGroup() {
                    name = "未分组",
                    count = this.GetPhotoGroupByNOGroup(customerId),
                    id = 0
                });
                foreach (DataRow row in dt.Rows) {
                    ResultMallPhotoGroup model = DataRowToResultModel(row);
                    list.Add(model);
                }
            } else {
                list = new List<ResultMallPhotoGroup>();
                list.Add(new ResultMallPhotoGroup() {
                    name = "未分组",
                    count = this.GetPhotoGroupByNOGroup(customerId),
                    id = 0
                });
            }
            return list;
        }

        public int GetPhotoGroupByNOGroup(int customerId) {
            string sql = string.Format(@"select COUNT(Callery_ID) from HQ_Gallery where Callery_Customer_ID={0} and Photo_FatherID=0", customerId);
            object obj = DbHelperSQL.GetSingle(sql);
            return Convert.ToInt32(obj);
        }
        #endregion  ExtensionMethod
    }
}

