using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using HQ.Core.Model;
using HQ.Core.Enum;
using HQ.Common.Uploader;
using HQ.Core.BLL;
using HQ.Common;
using HQ.Core.Model.ViewModel;
using HQ.Core.BLL.PageBase;
using HQ.Core.Model.Gallery;
using HQ.Core.BLL.Gallery;

namespace LM.AdminWeb._3rdParty.Widget.Picture
{
    /// <summary>
    /// 图片库相关数据服务API
    /// </summary>
    public partial class PictureHandler : AdminPageBase {
        protected void Page_Load(object sender, EventArgs e) {
            ApiResult resultStatus = null;
            switch (this.action) { 
                case "modifyGroupName"://修改分组名称
                    resultStatus = this.modifyGroupName();
                    break;
                case "deleteGroup"://删除分组
                    resultStatus = this.deleteGroup();
                    break;
                case "deletePhotoList"://删除图片
                    resultStatus = this.deletePhotoList();
                    break;
                case "modifyPhotoName"://修改图片名称
                    resultStatus = this.modifyPhotoName();
                    break;
                case "modifyPhotoGroupId"://修改图片分组
                    resultStatus = this.modifyPhotoGroupId();
                    break;
                case "uploaderImages"://批量上传图片
                    resultStatus = this.uploadImage();
                    break;
                case "getBase64":
                    resultStatus = this.GetBase64Image();
                    break;
            }
            Response.ContentType = "application/json";
            Response.Write(GetJson(resultStatus));
            Response.End();
        }

        public ApiResult GetBase64Image() {
            HttpPostedFile file = Request.Files[0];
            string base64 = encodingbase64_image(file.InputStream);
            return new ApiResult(HQEnums.ResultOptionType.OK, base64);
        }

        public string encodingbase64_image(Stream stream) {
            using (BinaryReader binreader = new BinaryReader(stream)) {
                byte[] bytes = binreader.ReadBytes(Convert.ToInt32(stream.Length));
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// 修改分组名称
        /// </summary>
        /// <returns></returns>
        public ApiResult modifyGroupName() {
            try {
                PhotoGroupModel model = PhotoGroupBLL.Instance.GetModel(this.groupId);
                if (model != null) {
                    model.PhotoName = this.groupName;
                    if (PhotoGroupBLL.Instance.Update(model))
                        return new ApiResult(HQEnums.ResultOptionType.OK);
                    else
                        return new ApiResult(HQEnums.ResultOptionType.失败,"修改名称失败,请稍后再试...");
                } else {
                    return new ApiResult(HQEnums.ResultOptionType.没有信息,"没有该分组信息");
                }
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("modifyGroupName error-->Statck:{0},Message:{1}",ex.StackTrace,ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        /// <summary>
        /// 删除分组并且把分组下面的图片移动到未分组状态(groupId=0) 
        /// </summary>
        /// <returns></returns>
        public ApiResult deleteGroup() {
            try {
                PhotoGroupModel model = PhotoGroupBLL.Instance.GetModel(this.groupId);
                if (model != null) {
                    if (PhotoGroupBLL.Instance.DeleteList(this.groupId.ToString())) {
                        GalleryBLL.Instance.UpdateCalleryGroupId(this.groupId);
                        return new ApiResult(HQEnums.ResultOptionType.OK);
                    }else{
                        return new ApiResult(HQEnums.ResultOptionType.失败, "删除分组失败");
                    }
                } else {
                    return new ApiResult(HQEnums.ResultOptionType.没有信息, "没有该分组信息");
                }
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("deleteGroup error-->Statck:{0},Message:{1}",ex.StackTrace,ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        /// <summary>
        /// 删除图片
        /// 特别提示：目前还需要加入权限问题，避免恶意删除别家商户的图片(现还未考虑)
        /// </summary>
        /// <returns></returns>
        public ApiResult deletePhotoList() {
            try {
                if(GalleryBLL.Instance.DeleteCalleryByIds(this.photoIds))
                    return new ApiResult(HQEnums.ResultOptionType.OK);
                else
                    return new ApiResult(HQEnums.ResultOptionType.失败, "删除图片失败");
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("deleteCalleryList error-->Statck:{0},Message:{1}",ex.StackTrace,ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        /// <summary>
        /// 修改图片名称
        /// </summary>
        /// <returns></returns>
        public ApiResult modifyPhotoName() {
            try {
                GalleryModel model = GalleryBLL.Instance.GetModel(this.photoId);
                if (model != null) {
                    model.Callery_Name = this.photoName;
                    if(GalleryBLL.Instance.Update(model))
                        return new ApiResult(HQEnums.ResultOptionType.OK);
                    else
                        return new ApiResult(HQEnums.ResultOptionType.失败, "修改图片名称失败");
                } else {
                    return new ApiResult(HQEnums.ResultOptionType.没有信息, "没有找到该图片");
                }
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("modifyPhotoName error-->Statck:{0},Message:{1}",ex.StackTrace,ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        /// <summary>
        /// 修改图片分组
        /// </summary>
        /// <returns></returns>
        public ApiResult modifyPhotoGroupId() {
            try {
                bool Flag = GalleryBLL.Instance.UpdateGroupIDByIds(this.groupId, this.photoIds);
                if (Flag)
                    return new ApiResult(HQEnums.ResultOptionType.OK);
                else
                    return new ApiResult(HQEnums.ResultOptionType.失败, "修改图片分组失败");
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("modifyPhotoName error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        /// <summary>
        /// 批量上传图片
        /// </summary>
        /// <returns></returns>
        public ApiResult uploadImage() {
            try {
                if (this.imageModel != null && this.imageModel.Count > 0) {
                    for (int i = 0; i < this.imageModel.Count; i++) {
                        string base64Image = this.imageModel[i].base64;
                        base64Image = base64Image.Substring(base64Image.IndexOf(',') + 1);
                        string imageName = this.imageModel[i].name;
                        string extenName = imageName.Substring(imageName.IndexOf('.'));
                        byte[] bytes = Convert.FromBase64String(base64Image);
                        int width=0;
                        string size = FileUploadHelper.GetImgSize(base64Image,out width);
                        string imageFileName=System.DateTime.Now.ToString("yyyyMMdd")+"/"+ System.DateTime.Now.ToString("yyyyMMddHHmmss")+i + ".jpg";
                        string FileName = string.Format("/resource/images/photo/{0}/", this.customerId) +imageFileName;
                        string smallName=string.Format("/resource/images/photo/{0}/small/", this.customerId) + imageFileName;
                        string thumbName = string.Format("/resource/images/photo/{0}/thumb/", this.customerId) + imageFileName;

                        bool Flag = FileUploadHelper.CompressionImage(base64Image, FileName,width);
                        if (Flag) {
                            FileUploadHelper.UploadSmallImage(FileName, smallName, ThumbCompress.中图);
                            FileUploadHelper.UploadSmallImage(FileName, thumbName, ThumbCompress.缩略图);
                            //FileUploadHelper.CompressionImage(base64Image, smallName, (int)ThumbCompress.小图, 80);
                            //FileUploadHelper.CompressionImage(base64Image, thumbName, (int)ThumbCompress.缩略图, 80);
                            int count = GalleryBLL.Instance.Add(new GalleryModel() {
                                Callery_BigPic = FileName,
                                Callery_Customer_ID 
                                = this.customerId,
                                Callery_Name = imageName,
                                Callery_Size = size,
                                Callery_SmallPic = smallName,
                                Callery_ThumbnailPic = thumbName,
                                Callery_Time = DateTime.Now,
                                Callery_UpdateTime = DateTime.Now,
                                Photo_FatherID = this.groupId
                            });
                        } else {
                            return new ApiResult(HQEnums.ResultOptionType.上传图片失败, "上传图片失败");
                        }
                    }
                    return new ApiResult(HQEnums.ResultOptionType.OK, "上传图片成功");
                } else {
                    return new ApiResult(HQEnums.ResultOptionType.缺少请求参数, "请选择图片上传");
                }
            } catch (Exception ex) {
                LogHelper.WriteError(string.Format("uploadImage error-->Statck:{0},Message:{1}",ex.StackTrace,ex.Message));
                return new ApiResult(HQEnums.ResultOptionType.服务器错误, "服务器错误");
            }
        }

        #region 属性
        /// <summary>
        /// 分组ID
        /// </summary>
        public int groupId {
            get {
                if (this.IsHttpPOST)
                    return this.GetFormValue("groupId", 0);
                else
                    return this.GetQueryString("groupId", 0);
            }
        }

        /// <summary>
        /// 分组名称
        /// </summary>
        public string groupName {
            get {
                return this.GetQueryString("groupName","");
            }
        }

        public string action {
            get {
                if (this.IsHttpPOST)
                    return this.GetFormValue("action", "");
                else
                    return this.GetQueryString("action", "");
            }
        }

        /// <summary>
        /// 获得要删除的图片Id集合，格式如下: 1,2,3
        /// </summary>
        public string photoIds {
            get {
                return this.GetQueryString("photoIds","");
            }
        }

        /// <summary>
        /// 图片ID
        /// </summary>
        public int photoId {
            get {
                return this.GetQueryString("photoId",0);
            }
        }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string photoName {
            get {
                return this.GetQueryString("photoName","");
            }
        }
        #endregion

        #region POST属性
        public List<ImageUploadModel> imageModel {
            get { 
                string images=this.GetFormValue("images","");
                if (!string.IsNullOrEmpty(images))
                    return JsonConvert.DeserializeObject<List<ImageUploadModel>>(images);
                else
                    return null;
            }
        }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int customerId {
            get {
                return this.GetFormValue("customerId",0);
            }
        }
        #endregion
    }

    public class ImageUploadModel {
        /// <summary>
        /// 图片Base64位编码
        /// </summary>
        public string base64 { set; get; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string name { set; get; }
    }
}