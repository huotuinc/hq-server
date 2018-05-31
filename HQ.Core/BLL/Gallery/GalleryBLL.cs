

using HQ.Common;
using HQ.Core.DAL.Gallery;
using HQ.Core.Model.Gallery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace HQ.Core.BLL.Gallery
{
    /// <summary>
    /// 图片库逻辑层
    /// </summary>
    public class GalleryBLL
    {
        private static GalleryBLL instance = new GalleryBLL();
        private GalleryDAL dal = new GalleryDAL();

        private GalleryBLL()
        {
        }

        /// <summary>
        /// 单例出口
        /// </summary>
        public static GalleryBLL Instance
        {
            get
            {
                return instance;
            }
        }

        public int Add(GalleryModel model)
        {
            return dal.Add(model);
        }

        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        public bool Update(GalleryModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GalleryModel GetModel(int Callery_ID)
        {
            return dal.GetModel(Callery_ID);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PhotoID, int CustomerID, int FatherID)
        {
            return dal.Delete(PhotoID, CustomerID, FatherID);
        }
        /// <summary>
        /// 根据商户ID来获取分页图片资源列表（用于API接口提供数据）
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public HotPageData<DataTable> GetImgList(int customid, string resourcesRoot, int page, int pageSize)
        {
            return dal.GetImgList(customid, resourcesRoot, page, pageSize);
        }
        /// <summary>
        /// 根据商户ID来获取分页图片资源列表（用于API接口提供数据）
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public DataSet GetList(string sqlwhere)
        {
            return dal.GetList(sqlwhere);
        }

        public HotPageData<DataTable> GetPhotoList(int customid, int fileid, int page, int pageSize)
        {
            return dal.GetPhotoList(customid, fileid, page, pageSize);
        }

        /// <summary>
        /// 获得图片列表
        /// </summary>
        /// <param name="customerId">商户号</param>
        /// <param name="groupId">分组ID(新版图片库只考虑一级)</param>
        /// <param name="name">名称</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public HotPageData<ResultGallery[]> GetPhotoList(int customerId, int groupId, string name, int page, int pageSize)
        {
            return dal.GetPhotoList(customerId, groupId, name, page, pageSize);
        }

        /// <summary>
        /// 把分组下面的图片全部移动到未分组下面(groupId=0)
        /// </summary>
        /// <param name="groupId">要修改的分组ID</param>
        /// <param name="customerId">商户号</param>
        /// <returns></returns>
        public bool UpdateCalleryGroupId(int groupId)
        {
            return dal.UpdateCalleryGroupId(groupId);
        }

        /// <summary>
        /// 根据图片集合删除图片列表（目前图片还未考虑物流删除,待后面有时间加上物理删除）
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteCalleryByIds(string ids)
        {
            return dal.DeleteCalleryByIds(ids);
        }

        /// <summary>
        /// 批量修改图片所属分组
        /// </summary>
        /// <param name="groupId">所属分组ID</param>
        /// <param name="ids">图片Id集合</param>
        /// <returns></returns>
        public bool UpdateGroupIDByIds(int groupId, string ids)
        {
            return dal.UpdateGroupIDByIds(groupId, ids);
        }
    }
}
