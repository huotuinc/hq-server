using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using HQ.Core.DAL.Gallery;
using HQ.Core.Model.Gallery;

namespace HQ.Core.BLL.Gallery
{
    /// <summary>
    /// 图片分组
    /// </summary>
    public partial class PhotoGroupBLL
    {
        private static PhotoGroupBLL instance = new PhotoGroupBLL();
        private readonly PhotoGroupDAL dal = new PhotoGroupDAL();
        public PhotoGroupBLL()
        { }
        /// <summary>
        /// 单例出口
        /// </summary>
        public static PhotoGroupBLL Instance
        {
            get
            {
                return instance;
            }
        }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(PhotoGroupModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(PhotoGroupModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PhotoIDlist)
        {
            return dal.DeleteList(PhotoIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public PhotoGroupModel GetModel(int PhotoID)
        {

            return dal.GetModel(PhotoID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public PhotoGroupModel GetModelByCache(int PhotoID)
        {
            return dal.GetModel(PhotoID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PhotoGroupModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<PhotoGroupModel> DataTableToList(DataTable dt)
        {
            List<PhotoGroupModel> modelList = new List<PhotoGroupModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                PhotoGroupModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        public DataTable GetPhotoList(int customid, int fileid, int page, int pageSize, out int recordcount)
        {
            return dal.GetPhotoList(customid, fileid, page, pageSize, out recordcount);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        /// <summary>
        /// 根据商户号获得图片分组列表
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<ResultMallPhotoGroup> GetPhotoGroupList(int customerId) {
            return dal.GetPhotoGroupList(customerId);
        }

        #endregion  ExtensionMethod
    }
}

