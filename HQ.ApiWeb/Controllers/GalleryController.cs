using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Net;
using HQ.Core.Model.ViewModel;
using HQ.Common;
using HQ.Core.BLL.Gallery;
using HQ.Core.Enum;
using HQ.Core.Model.Gallery;
using HQ.Common.Uploader;

namespace LM.Web.Controllers
{
    /// <summary>
    /// 图库资源相关API
    /// </summary>
    public class GalleryController : Controller
    {
        /// <summary>
        /// 获取图片资源库 GET: /gallery/get
        /// </summary>
        /// <param name="ownerId">业务ID</param>
        /// <param name="callback">此参数支持Jsonp方式 Jsonp callback参数</param>
        /// <param name="page">页面</param>
        /// <param name="pagesize">页面大小</param>
        /// <returns>返回json格式</returns>
        //[ApiAuthorizeAttribute]
        public ActionResult get(int ownerId, string callback, int page = 1, int pagesize = 20)
        {
            string resultJson = "";
            string json = "";
            try
            {
                if (ownerId == 7944)
                {//特殊处理
                    ownerId = 5020;
                }
                HotPageData<DataTable> obj = GalleryBLL.Instance.GetImgList(ownerId, "", page, pagesize);
                if (obj != null)
                    json = JsonConvert.SerializeObject(obj);
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("get error  --->StackTrace:{0},error:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 新增文件夹
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="callback"></param>
        /// <param name="extenName">文件夹名称</param>
        /// <param name="fileid">父级id</param>
        /// <returns></returns>
        public ActionResult addfile(int customerId, string callback, string extenName, int fileid = 0)
        {
            string resultJson = "";
            string json = "";
            try
            {
                int count = PhotoGroupBLL.Instance.Add(new PhotoGroupModel()
                {
                    PhotoName = extenName,
                    Photo_Cover = null,
                    Photo_Customer_ID = customerId,
                    Photo_Time = DateTime.Now,
                    FatherID = fileid
                });
                if (count > 0)
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK, extenName));
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("get error  --->StackTrace:{0},error:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        #region 新版图片库插件相关接口

        /// <summary>
        /// 根据商户获得图片库分组列表
        /// </summary>
        /// <param name="customerId">商户ID</param>
        /// <param name="callback">回调</param>
        /// <returns></returns>
        public ActionResult GetGroupList(int customerId, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                List<ResultMallPhotoGroup> list = PhotoGroupBLL.Instance.GetPhotoGroupList(customerId);
                if (list != null)
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK, list));
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("get GetGroupList  --->StackTrace:{0},error:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 根据分组ID和名称来查询图片列表
        /// </summary>
        /// <param name="customerId">商户ID</param>
        /// <param name="groupId">分组ID</param>
        /// <param name="callback">回调</param>
        /// <param name="name">图片名称</param>
        /// <param name="page">页码</param>
        /// <param name="pageSize">页码大小</param>
        /// <returns></returns>
        public ActionResult GetPhotoList(int customerId, int groupId, string callback, string name, int page, int pageSize)
        {
            string resultJson = "";
            string json = "";
            try
            {
                HotPageData<ResultGallery[]> list = GalleryBLL.Instance.GetPhotoList(customerId, groupId, name, page, pageSize);
                if (list != null)
                    json = JsonConvert.SerializeObject(list);
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("get GetGroupList  --->StackTrace:{0},error:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 提取网络图片并上传（目前有安全风险）
        /// </summary>
        /// <param name="customerId">商户号</param>
        /// <param name="url">网络图片地址</param>
        /// <param name="groupId">分组ID</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult uploaderPhotoByUrl(int customerId, string url, int groupId, string callback)
        {
            string resultJson = "";
            string json = "";
            WebRequest request = null;
            WebResponse response = null;
            Stream reader = null;
            FileStream writer = null;
            Image image = null;
            try
            {
                request = WebRequest.Create(url);
                response = request.GetResponse();
                reader = response.GetResponseStream();
                string contentType = response.ContentType;
                if (contentType.Equals("image/jpeg") || contentType.Equals("image/gif") || contentType.Equals("image/webp") || contentType.Equals("image/png") || contentType.Equals("image/jpg"))
                {
                    string extName = contentType.Split('/')[1];
                    string name = "";
                    if (extName.Equals("webp"))
                    {
                        name = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(10000, 99999) + ".jpg";
                    }
                    else
                    {
                        name = System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(10000, 99999) + "." + extName;
                    }
                    string imageFileName = System.DateTime.Now.ToString("yyyyMMdd") + "/" + name;
                    string path = string.Format("/resource/images/photo/{0}/", customerId) + imageFileName;
                    string servicePath = Server.MapPath(path);
                    FileUploadHelper.CreateDirectory(servicePath);
                    writer = new FileStream(servicePath, FileMode.OpenOrCreate, FileAccess.Write);
                    byte[] buff = new byte[512];
                    int c = 0; //实际读取的字节数
                    while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                    {
                        writer.Write(buff, 0, c);
                    }
                    writer.Close();
                    writer.Dispose();
                    string base64Image = Convert.ToBase64String(buff);
                    image = Image.FromFile(servicePath);
                    string size = image.Width + "x" + image.Height;
                    image.Dispose();

                    string smallName = string.Format("/resource/images/photo/{0}/small/", customerId) + imageFileName;
                    string thumbName = string.Format("/resource/images/photo/{0}/thumb/", customerId) + imageFileName;
                    FileUploadHelper.UploadSmallImage(path, smallName, ThumbCompress.小图);
                    FileUploadHelper.UploadSmallImage(path, thumbName, ThumbCompress.缩略图);
                    int count = GalleryBLL.Instance.Add(new GalleryModel()
                    {
                        Callery_BigPic = path,
                        Callery_Customer_ID = customerId,
                        Callery_Name = name,
                        Callery_Size = size,
                        Callery_SmallPic = smallName,
                        Callery_ThumbnailPic = thumbName,
                        Callery_Time = DateTime.Now,
                        Callery_UpdateTime = DateTime.Now,
                        Photo_FatherID = groupId
                    });
                    if (count > 0)
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK, path));
                    else
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.上传图片失败));
                }
                else
                {
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.缺少请求参数, "图片格式错误,请提取jpeg,gif,png,webp,jpg格式的图片"));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("GetPhotoByUrl error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
                if (response != null)
                    response.Close();
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 修改分组名称（目前有安全风险）
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="groupName">分组名称</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult modifyGroupName(int groupId, string groupName, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                PhotoGroupModel model = PhotoGroupBLL.Instance.GetModel(groupId);
                if (model != null)
                {
                    model.PhotoName = groupName;
                    if (PhotoGroupBLL.Instance.Update(model))
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK));
                    else
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败, "修改名称失败,请稍后再试..."));
                }
                else
                {
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息, "没有该分组信息"));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("modifyGroupName error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 删除分组（目前有安全风险）
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult deleteGroup(int groupId, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                PhotoGroupModel model = PhotoGroupBLL.Instance.GetModel(groupId);
                if (model != null)
                {
                    if (PhotoGroupBLL.Instance.DeleteList(groupId.ToString()))
                    {
                        GalleryBLL.Instance.UpdateCalleryGroupId(groupId);
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK));
                    }
                    else
                    {
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败, "删除分组失败"));
                    }
                }
                else
                {
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息, "没有该分组信息"));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("deleteGroup error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 删除图片（目前有安全风险）
        /// </summary>
        /// <param name="photoIds">图片ID集合</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult deletePhotoList(string photoIds, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                if (GalleryBLL.Instance.DeleteCalleryByIds(photoIds))
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK));
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败, "删除图片失败"));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("deleteCalleryList error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 修改图片名称（目前有安全风险）
        /// </summary>
        /// <param name="photoId">图片ID</param>
        /// <param name="photoName">图片名称</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult modifyPhotoName(int photoId, string photoName, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                GalleryModel model = GalleryBLL.Instance.GetModel(photoId);
                if (model != null)
                {
                    model.Callery_Name = photoName;
                    if (GalleryBLL.Instance.Update(model))
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK));
                    else
                        json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败, "修改图片名称失败"));
                }
                else
                {
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.没有信息, "没有找到该图片"));
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("modifyPhotoName error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 修改图片分组（目前有安全风险）
        /// </summary>
        /// <param name="groupId">分组ID</param>
        /// <param name="photoIds">图片id集合</param>
        /// <param name="callback"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult modifyPhotoGroupId(int groupId, string photoIds, string callback)
        {
            string resultJson = "";
            string json = "";
            try
            {
                bool Flag = GalleryBLL.Instance.UpdateGroupIDByIds(groupId, photoIds);
                if (Flag)
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.OK));
                else
                    json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.失败, "修改图片分组失败"));
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("modifyPhotoName error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                json = JsonConvert.SerializeObject(new ApiResult(HQEnums.ResultOptionType.服务器错误));
            }
            if (!string.IsNullOrEmpty(callback))
                resultJson = callback + "(" + json + ")";
            else
                resultJson = json;
            return Content(resultJson, "application/json");
        }

        /// <summary>
        /// 批量上传图片(图片库插件将会使用)（目前有安全风险）
        /// </summary>
        /// <param name="images"></param>
        /// <param name="customerId"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult uploadImage(string images, int customerId, int groupId)
        {
            return null;
            //try
            //{
            //    List<ImageUploadModel> imageModel = null;
            //    if (!string.IsNullOrEmpty(images))
            //    {
            //        imageModel = JsonConvert.DeserializeObject<List<ImageUploadModel>>(images);
            //    }
            //    if (imageModel != null && imageModel.Count > 0)
            //    {
            //        for (int i = 0; i < imageModel.Count; i++)
            //        {
            //            PdMallSystemConfigModel configModel = PdMallSystemConfigProvider.Instance.GetCurrentConfig();
            //            string _xheditorPath = ConfigHelper.uploadPhoto;
            //            string base64Image = imageModel[i].base64;
            //            base64Image = base64Image.Substring(base64Image.IndexOf(',') + 1);
            //            string imageName = imageModel[i].name;
            //            string extenName = imageName.Substring(imageName.IndexOf('.'));
            //            byte[] bytes = Convert.FromBase64String(base64Image.Substring(base64Image.IndexOf(',') + 1));

            //            int width = 0;
            //            string size = FileUploadHelper.GetImgSize(base64Image, out width);
            //            string imageFileName = System.DateTime.Now.ToString("yyyyMMdd") + "/" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + i + extenName;
            //            string FileName = string.Format("/resource/images/photo/{0}/", customerId) + imageFileName;
            //            string smallName = string.Format("/resource/images/photo/{0}/small/", customerId) + imageFileName;
            //            string thumbName = string.Format("/resource/images/photo/{0}/thumb/", customerId) + imageFileName;

            //            bool Flag = FileUploadHelper.CompressionImage(base64Image, FileName, width);
            //            //bool Flag = FileUploadHelper.UploadFile(bytes, FileName);
            //            //bool Flag = FileUploadHelper.UploadFile(base64Image, FileName);
            //            if (Flag)
            //            {
            //                //FileUploadHelper.CompressionImage(base64Image, smallName, (int)ThumbCompress.小图, 80);
            //                //FileUploadHelper.CompressionImage(base64Image, thumbName, (int)ThumbCompress.缩略图, 80);
            //                FileUploadHelper.UploadSmallImage(FileName, smallName, ThumbCompress.中图);
            //                FileUploadHelper.UploadSmallImage(FileName, thumbName, ThumbCompress.缩略图);
            //                int count = CalleryBLL.Instance.Add(new CalleryModel()
            //                {
            //                    Callery_BigPic = FileName,
            //                    Callery_Customer_ID = customerId,
            //                    Callery_Name = imageName,
            //                    Callery_Size = size,
            //                    Callery_SmallPic = smallName,
            //                    Callery_ThumbnailPic = thumbName,
            //                    Callery_Time = DateTime.Now,
            //                    Callery_UpdateTime = DateTime.Now,
            //                    Photo_FatherID = groupId
            //                });
            //            }
            //            else
            //            {
            //                return Json(new ResultStatus(HQEnums.ResultOptionType.上传图片失败, "上传图片失败"), JsonRequestBehavior.AllowGet);
            //            }
            //        }
            //        return Json(new ResultStatus(HQEnums.ResultOptionType.OK, "上传图片成功"), JsonRequestBehavior.AllowGet);
            //    }
            //    else
            //    {
            //        return Json(new ResultStatus(HQEnums.ResultOptionType.参数错误, "请选择图片上传"), JsonRequestBehavior.AllowGet);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteError(string.Format("uploadImage error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
            //    return Json(new ResultStatus(HQEnums.ResultOptionType.服务器错误, "服务器错误"), JsonRequestBehavior.AllowGet);
            //}
        }
        #endregion
    }
}
