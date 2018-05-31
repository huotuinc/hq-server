using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using HQ.Core.Model.Gallery;
using HQ.Common;
using HQ.Common.DB;

namespace HQ.Core.DAL.Gallery
{
    /// <summary>
    /// 图片库数据访问层
    /// </summary>
    public class GalleryDAL : BaseDAL
    {
        public GalleryDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Callery_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HQ_Gallery");
            strSql.Append(" where Callery_ID=@Callery_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = Callery_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GalleryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Gallery(");
            strSql.Append("Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,Callery_Time,Callery_UpdateTime,Photo_FatherID)");
            strSql.Append(" values (");
            strSql.Append("@Callery_Customer_ID,@Callery_Size,@Callery_Name,@Callery_ThumbnailPic,@Callery_SmallPic,@Callery_BigPic,@Callery_Time,@Callery_UpdateTime,@Photo_FatherID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Callery_Size", SqlDbType.NVarChar,20),
					new SqlParameter("@Callery_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Callery_ThumbnailPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_SmallPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_BigPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_Time", SqlDbType.DateTime),
					new SqlParameter("@Callery_UpdateTime", SqlDbType.DateTime),
                    new SqlParameter("@Photo_FatherID",SqlDbType.Int,4)};
            parameters[0].Value = model.Callery_Customer_ID;
            parameters[1].Value = model.Callery_Size;
            parameters[2].Value = model.Callery_Name;
            parameters[3].Value = model.Callery_ThumbnailPic;
            parameters[4].Value = model.Callery_SmallPic;
            parameters[5].Value = model.Callery_BigPic;
            parameters[6].Value = model.Callery_Time;
            parameters[7].Value = model.Callery_UpdateTime;
            parameters[8].Value = model.Photo_FatherID;

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
        public bool Update(GalleryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Gallery set ");
            strSql.Append("Callery_Customer_ID=@Callery_Customer_ID,");
            strSql.Append("Callery_Size=@Callery_Size,");
            strSql.Append("Callery_Name=@Callery_Name,");
            strSql.Append("Callery_ThumbnailPic=@Callery_ThumbnailPic,");
            strSql.Append("Callery_SmallPic=@Callery_SmallPic,");
            strSql.Append("Callery_BigPic=@Callery_BigPic,");
            strSql.Append("Callery_Time=@Callery_Time,");
            strSql.Append("Callery_UpdateTime=@Callery_UpdateTime,");
            strSql.Append("Photo_FatherID=@Photo_FatherID ");
            strSql.Append(" where Callery_ID=@Callery_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_Customer_ID", SqlDbType.Int,4),
					new SqlParameter("@Callery_Size", SqlDbType.NVarChar,20),
					new SqlParameter("@Callery_Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Callery_ThumbnailPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_SmallPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_BigPic", SqlDbType.NVarChar,500),
					new SqlParameter("@Callery_Time", SqlDbType.DateTime),
					new SqlParameter("@Callery_UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Callery_ID", SqlDbType.Int,4),
                    new SqlParameter("@Photo_FatherID",SqlDbType.Int,4)};
            parameters[0].Value = model.Callery_Customer_ID;
            parameters[1].Value = model.Callery_Size;
            parameters[2].Value = model.Callery_Name;
            parameters[3].Value = model.Callery_ThumbnailPic;
            parameters[4].Value = model.Callery_SmallPic;
            parameters[5].Value = model.Callery_BigPic;
            parameters[6].Value = model.Callery_Time;
            parameters[7].Value = model.Callery_UpdateTime;
            parameters[8].Value = model.Callery_ID;
            parameters[9].Value = model.Photo_FatherID;

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
        public bool Delete(int Callery_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Gallery ");
            strSql.Append(" where Callery_ID=@Callery_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = Callery_ID;

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
        public bool Delete(int PhotoID, int CustomerID, int FatherID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Gallery ");
            strSql.Append(" where Callery_ID=@Callery_ID and Callery_Customer_ID=@Callery_Customer_ID and Photo_FatherID=@Photo_FatherID ");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_ID", SqlDbType.Int,4),
                    new SqlParameter("@Callery_Customer_ID", SqlDbType.Int,4),
                    new SqlParameter("@Photo_FatherID", SqlDbType.Int,4)
			};
            parameters[0].Value = PhotoID;
            parameters[1].Value = CustomerID;
            parameters[2].Value = FatherID;

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
        public bool DeleteList(string Callery_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Gallery ");
            strSql.Append(" where Callery_ID in (" + Callery_IDlist + ")  ");
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
        public GalleryModel GetModel(int Callery_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Callery_ID,Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,Callery_Time,Callery_UpdateTime,Photo_FatherID from HQ_Gallery ");
            strSql.Append(" where Callery_ID=@Callery_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Callery_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = Callery_ID;

            GalleryModel model = new GalleryModel();
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
        /// 批量修改图片所属分组
        /// </summary>
        /// <param name="groupId">所属分组ID</param>
        /// <param name="ids">图片Id集合</param>
        /// <returns></returns>
        public bool UpdateGroupIDByIds(int groupId, string ids)
        {
            string sql = string.Format(@"update HQ_Gallery set Photo_FatherID={0} where Callery_ID in({1})", groupId, ids);
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GalleryModel DataRowToModel(DataRow row)
        {
            GalleryModel model = new GalleryModel();
            if (row != null)
            {
                if (row["Callery_ID"] != null && row["Callery_ID"].ToString() != "")
                {
                    model.Callery_ID = int.Parse(row["Callery_ID"].ToString());
                }
                if (row["Callery_Customer_ID"] != null && row["Callery_Customer_ID"].ToString() != "")
                {
                    model.Callery_Customer_ID = int.Parse(row["Callery_Customer_ID"].ToString());
                }
                if (row["Callery_Size"] != null)
                {
                    model.Callery_Size = row["Callery_Size"].ToString();
                }
                if (row["Callery_Name"] != null)
                {
                    model.Callery_Name = row["Callery_Name"].ToString();
                }
                if (row["Callery_ThumbnailPic"] != null)
                {
                    model.Callery_ThumbnailPic = row["Callery_ThumbnailPic"].ToString();
                }
                if (row["Callery_SmallPic"] != null)
                {
                    model.Callery_SmallPic = row["Callery_SmallPic"].ToString();
                }
                if (row["Callery_BigPic"] != null)
                {
                    model.Callery_BigPic = row["Callery_BigPic"].ToString();
                }
                if (row["Callery_Time"] != null && row["Callery_Time"].ToString() != "")
                {
                    model.Callery_Time = DateTime.Parse(row["Callery_Time"].ToString());
                }
                if (row["Callery_UpdateTime"] != null && row["Callery_UpdateTime"].ToString() != "")
                {
                    model.Callery_UpdateTime = DateTime.Parse(row["Callery_UpdateTime"].ToString());
                }
                if (row["Photo_FatherID"] != null && row["Photo_FatherID"].ToString() != "")
                {
                    model.Photo_FatherID = int.Parse(row["Photo_FatherID"].ToString());
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
            strSql.Append("select Callery_ID,Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,Callery_Time,Callery_UpdateTime,Photo_FatherID ");
            strSql.Append(" FROM HQ_Gallery ");
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
            strSql.Append(" Callery_ID,Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,Callery_Time,Callery_UpdateTime,Photo_FatherID ");
            strSql.Append(" FROM HQ_Gallery ");
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
            strSql.Append("select count(1) FROM HQ_Gallery ");
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
                strSql.Append("order by T.Callery_ID desc");
            }
            strSql.Append(")AS Row, T.*  from HQ_Gallery T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "HQ_Gallery";
            parameters[1].Value = "Callery_ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 根据商户ID获取分页商品数据
        /// </summary>
        /// <param name="customid"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public HotPageData<DataTable> GetImgList(int customid, string resourcesRoot, int page, int pageSize)
        {
            string sql = string.Format(@"select Callery_ID as id,Callery_Customer_ID as customid,Callery_Size as img_size,Callery_Name as name,'{1}'+Callery_ThumbnailPic as thumpic,
                                        '{1}'+Callery_BigPic as bigpic,Callery_Time as times from HQ_Gallery where Callery_Customer_ID={0}  order by Callery_ID desc", customid, resourcesRoot);
            return base.getPageData(sql, page, pageSize);
        }

        public HotPageData<DataTable> GetPhotoList(int customid, int fileid, int page, int pageSize)
        {
            string sql = string.Format(@"SELECT * FROM (SELECT PhotoID AS PFId,Photo_Cover AS PFUrl,PhotoName AS PFName,'' AS PFSize, FatherID AS PFatherId,0 AS PFCate,Photo_Time as times FROM dbo.HQ_PhotoGroup WHERE Photo_Customer_ID={0} and FatherID={1}
 UNION ALL  
SELECT Callery_ID AS PFId,Callery_ThumbnailPic AS PFUrl,Callery_Name AS PFName,Callery_Size AS PFSize,Photo_FatherID AS PFatherId,1 AS PFCate ,Callery_Time as times FROM dbo.HQ_Gallery WHERE Callery_Customer_ID={0} and Photo_FatherID={1} ) AS A ORDER BY PFCate ASC,times desc ", customid, fileid);
            return base.getPageData(sql, page, pageSize);
        }

        public HotPageData<ResultGallery[]> GetPhotoList(int customerId, int groupId, string name, int page, int pageSize)
        {
            //PdMallSystemConfigModel configModel = PdMallSystemConfigProvider.Instance.GetCurrentConfig();
            //todo
            string resourceSiteAddr = "";
            string where = "";
            if (!string.IsNullOrEmpty(name))
            {
                where += " and Callery_Name like '%" + name + "%'";
            }
            //            string sql = string.Format(@"select Callery_ID,Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,
            //                                            Callery_Time,Callery_UpdateTime,Photo_FatherID from HQ_Gallery where Callery_Customer_ID={0} and Photo_FatherID={1} {2} order by Callery_Time desc", customerId, groupId, where);
            string sql = string.Format(@"select Callery_ID,Callery_Customer_ID,Callery_Size,Callery_Name,Callery_ThumbnailPic,Callery_SmallPic,Callery_BigPic,
                                            Callery_Time,Callery_UpdateTime,Photo_FatherID from HQ_Gallery where Callery_Customer_ID={0} and Photo_FatherID={1} {2} order by Callery_ID desc", customerId, groupId, where);
            List<ResultGallery> list = new List<ResultGallery>();
            HotPageData<ResultGallery[]> dataPager = null;
            HotPageData<DataTable> pager = base.getPageData(sql, page, pageSize);
            if (pager != null)
            {
                DataTable dt = pager.Rows;
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        ResultGallery model = DataRowToModel(row, resourceSiteAddr);
                        list.Add(model);
                    }
                }
                dataPager = new HotPageData<ResultGallery[]>();
                dataPager.PageCount = pager.PageCount;
                dataPager.PageIndex = pager.PageIndex;
                dataPager.PageSize = pager.PageSize;
                dataPager.Total = pager.Total;
                dataPager.Rows = list.Count > 0 ? list.ToArray() : null;
            }
            return dataPager;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ResultGallery DataRowToModel(DataRow row, string resouces)
        {
            ResultGallery model = new ResultGallery();
            if (row != null)
            {
                if (row["Callery_ID"] != null && row["Callery_ID"].ToString() != "")
                {
                    model.id = int.Parse(row["Callery_ID"].ToString());
                }
                if (row["Callery_Customer_ID"] != null && row["Callery_Customer_ID"].ToString() != "")
                {
                    model.customerId = int.Parse(row["Callery_Customer_ID"].ToString());
                }
                if (row["Callery_Size"] != null)
                {
                    model.size = row["Callery_Size"].ToString();
                }
                if (row["Callery_Name"] != null)
                {
                    model.name = row["Callery_Name"].ToString();
                }
                if (row["Callery_ThumbnailPic"] != null)
                {
                    model.thumbPicUri = row["Callery_ThumbnailPic"].ToString();
                    model.thumbPicUrl = resouces + model.thumbPicUri;
                }
                if (row["Callery_SmallPic"] != null)
                {
                    model.smallPicUri = row["Callery_SmallPic"].ToString();
                    model.smallPicUrl = resouces + model.smallPicUri;
                }
                if (row["Callery_BigPic"] != null)
                {
                    model.bigPicUri = row["Callery_BigPic"].ToString();
                    model.bigPicUrl = resouces + model.bigPicUri;
                }
                if (row["Callery_Time"] != null && row["Callery_Time"].ToString() != "")
                {
                    model.createTime = DateTime.Parse(row["Callery_Time"].ToString());
                }
                if (row["Photo_FatherID"] != null && row["Photo_FatherID"].ToString() != "")
                {
                    model.groupId = int.Parse(row["Photo_FatherID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 把分组下面的图片全部移动到未分组下面(groupId=0)
        /// </summary>
        /// <param name="groupId">要修改的分组ID</param>
        /// <param name="customerId">商户号</param>
        /// <returns></returns>
        public bool UpdateCalleryGroupId(int groupId)
        {
            string sql = string.Format(@"update HQ_Gallery set Photo_FatherID=0 where Photo_FatherID={0}", groupId);
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }

        /// <summary>
        /// 根据图片集合删除图片列表（目前图片还未考虑物流删除,待后面有时间加上物理删除）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteCalleryByIds(string ids)
        {
            string sql = string.Format(@"delete HQ_Gallery where Callery_ID in({0})", ids);
            return DbHelperSQL.ExecuteSql(sql) > 0;
        }
        #endregion  ExtensionMethod
    }
}
