using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace HQ.Common.Uploader
{
    /// <summary>
    /// 文件上传帮助类
    /// fulh 2012-01-10
    /// 
    /// 图片压缩待优化   不失真的情况下压缩文件到最小
    /// </summary>
    public class FileUploadHelper
    {
        #region 保存文件
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="oFile"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static UploadResultInfo SaveFile(HttpPostedFile oFile, UploadConfigInfo model)
        {
            UploadResultInfo info = new UploadResultInfo();
            /*----------------------------------------------------------------
            Key             键值
            URL             文件保存路径 {$CityCode}：citycode，{$CompanyID}：企业ID
            IsImg           是否是图片   【true/false】
            FileNamePrefix  文件名的前缀 如：company******.jpg
            FileExt         允许上传的文件后缀 "|"分隔 如：.png|.jpg|.gif|.bmp
            MaxSize         允许上传文件大小 单位：KB 0：不受限制  
            ToThumbnail     是否生成缩略图  【true/false】
            Width           缩略图的宽度
            Height          缩略图的高度
            ThumbnailMode   缩略图方式 【HW,W,H,Cut,Ration,Fill】
            MaxModeSize     按照最大尺度（高度或者宽度）生成缩略图  0：表示不按照最大尺度生成缩略图
            MaxMode         最大尺度方式（高度或者宽度） 【H/W】
            ToWater         是否打水印  【true/false】
            WaterPosition   水印位置 【LeftTop,RightTop,Middle,LeftBottom,RightBottom】
             ----------------------------------------------------------------*/
            #region 文件限制判断
            if (!CheckFileExt(oFile.FileName, model.FileExt))
            {
                info.Msg = "文件类型错误，应为后缀为[" + model.FileExt + "]的文件。";
                info.UploadStatus = false;
                return info;
            }
            if (model.MaxSize != 0 && model.MaxSize < oFile.ContentLength / 1024)
            {
                int size = model.MaxSize / 1024;
                if (size > 1)
                {
                    info.Msg = "文件大小限制为" + (size / 1024) + "MB";
                }
                else
                {
                    info.Msg = "文件大小限制为" + model.MaxSize + "KB";
                }
                info.UploadStatus = false;
                return info;
            }
            #endregion

            string fileName = GetFileNameByTime(model.FileNamePrefix, Path.GetExtension(oFile.FileName));

            string fileFullName = model.URL + fileName;

            //Response.Write("OK：图片上传成功。-" + fileName);
            //return;

            #region 上传文件
            if (!model.IsImg)//普通文件
            {
                if (UploadFile(oFile, fileFullName))
                {
                    info.FileName = fileName;
                }
                else
                {
                    info.UploadStatus = false;
                    info.Msg = "文件上传失败，请重试。";
                }
            }
            else//图片
            {
                info.FileType = UploadFileType.Img;
                #region 图片
                if (model.ToThumbnail && model.ToWater)//缩略图    +   水印 
                {
                    SaveOtherThumbnail(oFile, model.OtherThumbnail, model.URL, fileName);
                    if (model.MaxModeSize != 0)//按照最大尺度进行缩略图
                    {
                        if (UploadPicFileClipByMaxSize(oFile, fileFullName, model.MaxModeSize, model.MaxMode, model.WaterPosition, model.Width, model.Height, model.ThumbnailMode))
                        {
                            info.Msg = "图片上传成功。";
                            info.FileName = fileName;
                        }
                        else
                        {
                            info.UploadStatus = false;
                            info.Msg = "图片上传失败，请重试。";
                        }
                    }
                    else
                    {
                        if (UploadPicFileToWaterAndThumbnail(oFile, fileFullName, model.WaterPosition, model.Width, model.Height, model.ThumbnailMode))
                        {
                            info.Msg = "图片上传成功。";
                            info.FileName = fileName;
                        }
                        else
                        {
                            info.UploadStatus = false;
                            info.Msg = "图片上传失败，请重试。";
                        }
                    }
                }
                else if (model.ToThumbnail)//缩略图
                {
                    SaveOtherThumbnail(oFile, model.OtherThumbnail, model.URL, fileName);
                    if (model.MaxModeSize != 0)//按照最大尺度进行缩略图
                    {
                        if (UploadPicFileClipByMaxSize(oFile, fileFullName, model.MaxModeSize, model.MaxMode, model.Width, model.Height, model.ThumbnailMode))
                        {
                            info.Msg = "图片上传成功。";
                            info.FileName = fileName;
                        }
                        else
                        {
                            info.UploadStatus = false;
                            info.Msg = "图片上传失败，请重试。";
                        }
                    }
                    else
                    {
                        if (UploadPicFileToThumbnail(oFile, fileFullName, model.Width, model.Height, model.ThumbnailMode))
                        {
                            info.Msg = "图片上传成功。";
                            info.FileName = fileName;
                        }
                        else
                        {
                            info.UploadStatus = false;
                            info.Msg = "图片上传失败，请重试。";
                        }
                    }
                }
                else if (model.ToWater)//水印
                {
                    if (UploadPicFileToWater(oFile, fileFullName, model.WaterPosition))
                    {
                        info.Msg = "图片上传成功。";
                        info.FileName = fileName;
                    }
                    else
                    {
                        info.UploadStatus = false;
                        info.Msg = "图片上传失败，请重试。";
                    }
                }
                else
                {
                    //Image temImg = Image.FromStream(oFile.InputStream);            
                    //if (temImg.Height == model.Height && temImg.Width == model.Width)
                    //{
                    //    SaveOtherThumbnail(oFile, model.OtherThumbnail, model.URL, fileName);
                    //    if (UploadPicFile(oFile, fileFullName))
                    //    {
                    //        info.Msg = "图片上传成功。";
                    //        info.FileName = fileName;
                    //    }
                    //    else
                    //    {
                    //        info.UploadStatus = false;
                    //        info.Msg = "图片上传失败，请重试。";
                    //    }
                    //}
                    //else
                    //{
                    //    info.UploadStatus = false;
                    //    info.Msg = string.Format("图片大小应为{0}*{1}。", model.Width, model.Height);
                    //}

                    int width = 0, height = 0;
                    using (Image temImg = Image.FromStream(oFile.InputStream))
                    {
                        width = temImg.Width;
                        height = temImg.Height;
                    }

                    SaveOtherThumbnail(oFile, model.OtherThumbnail, model.URL, fileName);
                    if (UploadPicFile(oFile, fileFullName))
                    {
                        info.Msg = "图片上传成功。";
                        info.FileName = fileName;
                        info.ImgWidth = width;
                        info.ImgHeight = height;
                    }
                    else
                    {
                        info.UploadStatus = false;
                        info.Msg = "图片上传失败，请重试。";
                    }

                }
                #endregion
            }
            #endregion
            if (!string.IsNullOrEmpty(info.FileName))
            {
                info.FullFileName = model.URL + info.FileName;
            }

            return info;
        }
        #endregion

        #region 保存其他缩略图   【待优化】
        /// <summary>
        /// 保存其他缩略图
        /// </summary>
        /// <param name="oFile"></param>
        /// <param name="OtherThumbnail"></param>
        /// <param name="URL"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static bool SaveOtherThumbnail(HttpPostedFile oFile, string OtherThumbnail, string URL, string fileName)
        {
            if (string.IsNullOrEmpty(OtherThumbnail))
            {
                return true;
            }
            if (OtherThumbnail.IndexOf("|") > 0)
            {
                string[] imgs = OtherThumbnail.Split('|');

                for (int i = 0; i < imgs.Length; i++)
                {
                    string[] img = imgs[i].Split(',');
                    string fileFullName = URL + img[0] + fileName;
                    if (!UploadPicFileToThumbnail(oFile, fileFullName, Convert.ToInt32(img[1]), Convert.ToInt32(img[2]), (ThumbnailMode)Enum.Parse(typeof(ThumbnailMode), img[3], true)))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                string[] img = OtherThumbnail.Split(',');
                string fileFullName = URL + img[0] + fileName;
                return UploadPicFileToThumbnail(oFile, fileFullName, Convert.ToInt32(img[1]), Convert.ToInt32(img[2]), (ThumbnailMode)Enum.Parse(typeof(ThumbnailMode), img[3], true));
            }
        }
        #endregion

        #region 文件上传操作
        #region HttpPostedFile
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="postedFile">上传文件控件的PostedFile属性值</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <returns></returns>
        public static bool UploadFile(HttpPostedFile postedFile, string sUploadPathAndFileName)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadFile(bytes, sUploadPathAndFileName);
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <returns></returns>
        public static bool UploadPicFile(HttpPostedFile postedFile, string sUploadPathAndFileName)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFile(bytes, sUploadPathAndFileName);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 上传图片打水印
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <returns></returns>
        public static bool UploadPicFileToWater(HttpPostedFile postedFile, string sUploadPathAndFileName, WaterPositionOptions position)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileToWater(bytes, sUploadPathAndFileName, position);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片生成缩略图
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileToThumbnail(HttpPostedFile postedFile, string sUploadPathAndFileName, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileToThumbnail(bytes, sUploadPathAndFileName, nWidth, nHeight, mode);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        ///  上传图片并生成缩略图(缩略图名称前加小写的英文字母“s”)
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileAndThumbnail(HttpPostedFile postedFile, string sUploadPathAndFileName, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileAndThumbnail(bytes, sUploadPathAndFileName, nWidth, nHeight, mode);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 图片等比压缩
        /// </summary>
        /// <param name="effectPath">被压缩的图片相对地址</param>
        /// <param name="path">要压缩的图片存储地址</param>
        /// <param name="compress">压缩比例模式</param>
        /// <returns></returns>
        public static bool UploadSmallImage(string effectPath, string path, ThumbCompress compress)
        {
            try
            {
                return UploadImageBySize(effectPath, path, (int)compress, ThumbnailMode.W);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(string.Format("UploadSmallImage error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
            }
            return false;
        }

        /// <summary>
        /// 上传图片打水印并生成缩略图(缩略图名称前加小写的英文字母“s”)
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileToWaterAndThumbnail(HttpPostedFile postedFile, string sUploadPathAndFileName, WaterPositionOptions position, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileToWaterAndThumbnail(bytes, sUploadPathAndFileName, position, nWidth, nHeight, mode);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片打水印并生成缩略图(缩略图名称前加小写的英文字母“s”)并且按照最大宽度缩略
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nMaxSize">最大尺寸(根据MaxMode方式选择宽或高缩略)</param>
        /// <param name="MaxMode">缩略图生成方式（ThumbnailMode.W或者ThumbnailMode.H）</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileClipByMaxSize(HttpPostedFile postedFile, string sUploadPathAndFileName, int nMaxSize, ThumbnailMode MaxMode, WaterPositionOptions position, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileClipByMaxSize(bytes, sUploadPathAndFileName, nMaxSize, MaxMode, position, nWidth, nHeight, mode);
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片并生成缩略图(缩略图名称前加小写的英文字母“s”)并且按照最大宽度缩略
        /// </summary>
        /// <param name="postedFile">文件流</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nMaxSize">最大尺寸(根据MaxMode方式选择宽或高缩略)</param>
        /// <param name="MaxMode">缩略图生成方式（ThumbnailMode.W或者ThumbnailMode.H）</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileClipByMaxSize(HttpPostedFile postedFile, string sUploadPathAndFileName, int nMaxSize, ThumbnailMode MaxMode, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                byte[] bytes = GetUploadBytes(postedFile);
                return UploadPicFileClipByMaxSize(bytes, sUploadPathAndFileName, nMaxSize, MaxMode, nWidth, nHeight, mode);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 字节数组
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <returns></returns>
        public static bool UploadFile(byte[] bytes, string sUploadPathAndFileName)
        {
            return WriteFile(bytes, sUploadPathAndFileName);
        }

        public static bool Uploadfile(string base64, string path)
        {
            Image returnImage = Base64StringToImage(base64);
            returnImage.Save(HttpContext.Current.Server.MapPath(path));
            return true;
        }

        private static System.Drawing.Image Base64StringToImage(string txt)
        {
            byte[] arr = Convert.FromBase64String(txt);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            return bmp;
        }

        public static bool UploadFile(string base64, string path)
        {
            Image returnImage = Base64StringToImage(base64);
            returnImage.Save(HttpContext.Current.Server.MapPath(path), ImageFormat.Png);
            return true;
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <returns></returns>
        public static bool UploadPicFile(byte[] bytes, string sUploadPathAndFileName)
        {
            return WriteFile(bytes, sUploadPathAndFileName);
        }

        /// <summary>
        /// 上传图片打水印
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <returns></returns>
        public static bool UploadPicFileToWater(byte[] bytes, string sUploadPathAndFileName, WaterPositionOptions position)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveWaterPic(sUploadPathAndFileName, position);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片生成缩略图
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileToThumbnail(byte[] bytes, string sUploadPathAndFileName, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveThumbnailPic(sUploadPathAndFileName, sUploadPathAndFileName, nWidth, nHeight, mode);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片并生成缩略图(缩略图名称前加小写的英文字母“s”)
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileAndThumbnail(byte[] bytes, string sUploadPathAndFileName, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveThumbnailPic(sUploadPathAndFileName, sUploadPathAndFileName.Replace("/big/", "/small/"), 320, nHeight, mode);
                    SaveThumbnailPic(sUploadPathAndFileName, sUploadPathAndFileName.Replace("/big/", "/thumb/"), nWidth, nHeight, mode);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据原来存在的图片来实现压缩图片
        /// </summary>
        /// <param name="effectPath">图片原有路径(服务端有效的图片根地址)</param>
        /// <param name="path">图片地址</param>
        /// <param name="width">要压缩的图片宽度,高度将会根据等比缩放来计算</param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool UploadImageBySize(string effectPath, string path, int width, ThumbnailMode mode)
        {
            try
            {
                SaveThumbnailPic(effectPath, path, width, mode);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 上传图片打水印并生成缩略图(缩略图名称前加小写的英文字母“s”)
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileToWaterAndThumbnail(byte[] bytes, string sUploadPathAndFileName, WaterPositionOptions position, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveThumbnailPic(sUploadPathAndFileName, Path.GetDirectoryName(sUploadPathAndFileName) + "/s" + Path.GetFileName(sUploadPathAndFileName), nWidth, nHeight, mode);
                    SaveWaterPic(sUploadPathAndFileName, position);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片打水印并生成缩略图(缩略图名称前加小写的英文字母“s”)并且按照最大宽度缩略
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nMaxSize">最大尺寸(根据MaxMode方式选择宽或高缩略)</param>
        /// <param name="MaxMode">缩略图生成方式（ThumbnailMode.W或者ThumbnailMode.H）</param>
        /// <param name="position">水印图片坐标位置</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileClipByMaxSize(byte[] bytes, string sUploadPathAndFileName, int nMaxSize, ThumbnailMode MaxMode, WaterPositionOptions position, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveThumbnailPic(sUploadPathAndFileName, Path.GetDirectoryName(sUploadPathAndFileName) + "/s" + Path.GetFileName(sUploadPathAndFileName), nWidth, nHeight, mode);
                    SaveThumbnailPic(sUploadPathAndFileName, sUploadPathAndFileName, nMaxSize, nMaxSize, MaxMode);
                    SaveWaterPic(sUploadPathAndFileName, position);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 上传图片并生成缩略图(缩略图名称前加小写的英文字母“s”)并且按照最大宽度缩略
        /// </summary>
        /// <param name="bytes">文件字节数组</param>
        /// <param name="sUploadPathAndFileName">保存相对路径及文件名</param>
        /// <param name="nMaxSize">最大尺寸(根据MaxMode方式选择宽或高缩略)</param>
        /// <param name="MaxMode">缩略图生成方式（ThumbnailMode.W或者ThumbnailMode.H）</param>
        /// <param name="nWidth">缩略图宽</param>
        /// <param name="nHeight">缩略图高</param>
        /// <param name="mode">缩略图方式</param>
        /// <returns></returns>
        public static bool UploadPicFileClipByMaxSize(byte[] bytes, string sUploadPathAndFileName, int nMaxSize, ThumbnailMode MaxMode, int nWidth, int nHeight, ThumbnailMode mode)
        {
            try
            {
                if (UploadFile(bytes, sUploadPathAndFileName))
                {
                    SaveThumbnailPic(sUploadPathAndFileName, Path.GetDirectoryName(sUploadPathAndFileName) + "/s" + Path.GetFileName(sUploadPathAndFileName), nWidth, nHeight, mode);
                    SaveThumbnailPic(sUploadPathAndFileName, sUploadPathAndFileName, nMaxSize, nMaxSize, MaxMode);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 保存水印  缩略图
        public static void SaveWaterPic(string sUploadPathAndFileName, WaterPositionOptions position)
        {
            Image waterImage = GetWaterMarkImage();
            if (waterImage == null)
            {
                return;
            }
            sUploadPathAndFileName = HttpContext.Current.Server.MapPath(sUploadPathAndFileName);

            Image image = Image.FromFile(sUploadPathAndFileName);
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawImage(image, new Point(0, 0));
            
            WaterPosition waterPosition = GetWaterPosition(image.Width, image.Height, waterImage.Width, waterImage.Height, position);
            //打水印
            g.DrawImage(waterImage, new Rectangle((int)waterPosition.X, (int)waterPosition.Y, waterImage.Width, waterImage.Height), 0, 0, waterImage.Width, waterImage.Height, System.Drawing.GraphicsUnit.Pixel);
            image.Dispose();
            waterImage.Dispose();
            bitmap.Save(sUploadPathAndFileName);
            bitmap.Dispose();
            g.Dispose();
        }
        private static void SaveThumbnailPic(string sUploadPathAndFileName, string sSavePathAndFileName, int nWidth, int nHeight, ThumbnailMode mode)
        {
            sUploadPathAndFileName = HttpContext.Current.Server.MapPath(sUploadPathAndFileName);
            sSavePathAndFileName = HttpContext.Current.Server.MapPath(sSavePathAndFileName);
            CreateDirectory(sSavePathAndFileName);
            Image image = Image.FromFile(sUploadPathAndFileName);
            int x = 0, y = 0, iW = image.Width, iH = image.Height;
            int towidth = nWidth;
            int toheight = nHeight;
            Rectangle drawZone = new Rectangle(0, 0, towidth, toheight);
            Rectangle ImgZone = new Rectangle(0, 0, iW, iH);
            switch (mode)
            {
                case ThumbnailMode.HW://缩小到指定大小
                    break;
                case ThumbnailMode.W:
                    if (nWidth > image.Width)
                    {
                        nWidth = image.Width;
                        nHeight = image.Height;
                        drawZone = new Rectangle(0, 0, image.Width, image.Height);
                    }
                    else
                    {
                        nHeight = toheight = image.Height * nWidth / image.Width;
                        drawZone = new Rectangle(0, 0, towidth, toheight);
                    }
                    break;
                case ThumbnailMode.H:
                    if (nHeight > image.Height)
                    {
                        nWidth = image.Width;
                        nHeight = image.Height;
                        drawZone = new Rectangle(0, 0, image.Width, image.Height);
                    }
                    else
                    {
                        nWidth = towidth = image.Width * nHeight / image.Height;
                        drawZone = new Rectangle(0, 0, towidth, toheight);
                    }
                    break;
                case ThumbnailMode.Cut:
                    if ((double)iW / (double)iH > (double)nWidth / (double)nHeight)
                    {
                        iW = iH * nWidth / nHeight;
                        x = (image.Width - iW) / 2;
                    }
                    else
                    {
                        iH = iW * nHeight / nWidth;
                        y = (image.Height - iH) / 2;
                    }
                    ImgZone = new Rectangle(x, y, iW, iH);
                    break;
                case ThumbnailMode.Ration://拉伸   同HW
                    break;
                case ThumbnailMode.Fill:
                    if ((double)iW / (double)iH > (double)nWidth / (double)nHeight)
                    {
                        toheight = iH * nWidth / iW;
                        y = (nHeight - toheight) / 2;
                    }
                    else
                    {
                        towidth = iW * nHeight / iH;
                        x = (nWidth - towidth) / 2;
                    }
                    drawZone = new Rectangle(x, y, towidth, toheight);
                    break;
                default:
                    break;
            }

            Bitmap bitmap = new Bitmap(nWidth, nHeight);
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            ////设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.CompositingQuality = CompositingQuality.AssumeLinear;

            g.Clear(Color.White);
            g.DrawImage(image, drawZone, ImgZone, GraphicsUnit.Pixel);
            ImageFormat format = image.RawFormat;
            image.Dispose();
            bitmap.Save(sSavePathAndFileName);//,ImageFormat.Png
            bitmap.Dispose();
            g.Dispose();
        }

        public static bool CompressionImage(string imageBase64, string savePathAndFileName, int width, int flat)
        {
            savePathAndFileName = HttpContext.Current.Server.MapPath(savePathAndFileName);
            CreateDirectory(savePathAndFileName);
            Image image = GetImage(imageBase64);
            int iW = image.Width, iH = image.Height;
            int height = width * image.Height / image.Width;
            int towidth = width;
            int toheight = height;
            ImageFormat tFormat = image.RawFormat;

            Bitmap ob = new Bitmap(towidth, toheight);
            Graphics g = Graphics.FromImage(ob);
            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, new Rectangle(0, 0, iW, iH), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flat;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(savePathAndFileName, jpegICIinfo, ep);//dFile是压缩后的新路径  
                }
                else
                {
                    ob.Save(savePathAndFileName, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                image.Dispose();
                ob.Dispose();
            }
            //Rectangle drawZone = new Rectangle(0, 0, towidth, toheight);
            //Rectangle ImgZone = new Rectangle(0, 0, iW, iH);
            //Bitmap bitmap = new Bitmap(width, height);
            //Graphics g = Graphics.FromImage(bitmap);
            ////设置高质量插值法
            //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            ////设置高质量,低速度呈现平滑程度
            ////g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.CompositingQuality = CompositingQuality.Default;

            ////g.Clear(Color.White);
            //g.DrawImage(image, drawZone, ImgZone, GraphicsUnit.Pixel);
            //ImageFormat format = image.RawFormat;
            ////image.Save(savePathAndFileName, ImageFormat.Png);
            ////image.Dispose();

            //bitmap.Save(savePathAndFileName, ImageFormat.Jpeg);//,ImageFormat.Png
            //bitmap.Dispose();
            //g.Dispose();
            //return true;
        }

        /// <summary>
        /// 图片压缩
        /// </summary>
        /// <param name="imageBase64"></param>
        /// <param name="savePathAndFileName"></param>
        /// <param name="width"></param>
        public static bool CompressionImage(string imageBase64, string savePathAndFileName, int width)
        {
            savePathAndFileName = HttpContext.Current.Server.MapPath(savePathAndFileName);
            CreateDirectory(savePathAndFileName);
            Image image = GetImage(imageBase64);
            int iW = image.Width, iH = image.Height;
            if (width <= 0) width = iW;
            int height = width * image.Height / image.Width;
            int towidth = width;
            int toheight = height;
            Rectangle drawZone = new Rectangle(0, 0, towidth, toheight);
            Rectangle ImgZone = new Rectangle(0, 0, iW, iH);
            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.Default;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;


            //g.Clear(Color.White);
            g.DrawImage(image, drawZone, ImgZone, GraphicsUnit.Pixel);
            ImageFormat format = image.RawFormat;
            //image.Save(savePathAndFileName, ImageFormat.Png);
            //image.Dispose();

            bitmap.Save(savePathAndFileName, ImageFormat.Jpeg);//,ImageFormat.Png
            bitmap.Dispose();
            g.Dispose();
            return true;
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="uploadPathAndFileName">原来的图片相对地址</param>
        /// <param name="savePathAndFileName">要保存的图片相对地址</param>
        /// <param name="width">要压缩的图片宽度,高度将会根据等比缩放计算出高度</param>
        /// <param name="mode"></param>
        private static void SaveThumbnailPic(string uploadPathAndFileName, string savePathAndFileName, int width, ThumbnailMode mode)
        {
            uploadPathAndFileName = HttpContext.Current.Server.MapPath(uploadPathAndFileName);
            savePathAndFileName = HttpContext.Current.Server.MapPath(savePathAndFileName);
            CreateDirectory(savePathAndFileName);
            Image image = Image.FromFile(uploadPathAndFileName);
            int x = 0, y = 0, iW = image.Width, iH = image.Height;
            int height = width * image.Height / image.Width;
            int towidth = width;
            int toheight = height;
            Rectangle drawZone = new Rectangle(0, 0, towidth, toheight);
            Rectangle ImgZone = new Rectangle(0, 0, iW, iH);
            switch (mode)
            {
                case ThumbnailMode.HW://缩小到指定大小
                    break;
                case ThumbnailMode.W:
                    if (width > image.Width)
                    {
                        width = image.Width;
                        height = image.Height;
                        drawZone = new Rectangle(0, 0, image.Width, image.Height);
                    }
                    else
                    {
                        height = toheight = image.Height * width / image.Width;
                        drawZone = new Rectangle(0, 0, towidth, toheight);
                    }
                    break;
                case ThumbnailMode.H:
                    if (height > image.Height)
                    {
                        width = image.Width;
                        height = image.Height;
                        drawZone = new Rectangle(0, 0, image.Width, image.Height);
                    }
                    else
                    {
                        width = towidth = image.Width * height / image.Height;
                        drawZone = new Rectangle(0, 0, towidth, toheight);
                    }
                    break;
                case ThumbnailMode.Cut:
                    if ((double)iW / (double)iH > (double)width / (double)height)
                    {
                        iW = iH * width / height;
                        x = (image.Width - iW) / 2;
                    }
                    else
                    {
                        iH = iW * height / width;
                        y = (image.Height - iH) / 2;
                    }
                    ImgZone = new Rectangle(x, y, iW, iH);
                    break;
                case ThumbnailMode.Ration://拉伸   同HW
                    break;
                case ThumbnailMode.Fill:
                    if ((double)iW / (double)iH > (double)width / (double)height)
                    {
                        toheight = iH * width / iW;
                        y = (height - toheight) / 2;
                    }
                    else
                    {
                        towidth = iW * height / iH;
                        x = (width - towidth) / 2;
                    }
                    drawZone = new Rectangle(x, y, towidth, toheight);
                    break;
                default:
                    break;
            }

            Bitmap bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            //设置高质量,低速度呈现平滑程度
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = CompositingQuality.Default;

            //g.Clear(Color.White);
            g.DrawImage(image, drawZone, ImgZone, GraphicsUnit.Pixel);
            ImageFormat format = image.RawFormat;
            //image.Save(savePathAndFileName, ImageFormat.Png);
            //image.Dispose();

            bitmap.Save(savePathAndFileName, ImageFormat.Jpeg);//,ImageFormat.Png
            bitmap.Dispose();
            g.Dispose();
        }

        //private byte[] CompressionImage(Stream fileStream, long quality)
        //{
        //    using (System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream))
        //    {
        //        using (Bitmap bitmap = new Bitmap(img))
        //        {
        //           // ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
        //            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
        //            EncoderParameters myEncoderParameters = new EncoderParameters(1);
        //            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
        //            myEncoderParameters.Param[0] = myEncoderParameter;
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                bitmap.Save(ms,, myEncoderParameters);
        //                myEncoderParameters.Dispose();
        //                myEncoderParameter.Dispose();
        //                return ms.ToArray();
        //            }
        //        }
        //    }
        //}

        #endregion

        #region 删除文件
        /// <summary>
        /// 删除文件（任何文件）
        /// </summary>
        /// <param name="sUploadPathAndFileName">相对路径及文件名</param>
        /// <returns></returns>
        public static bool DeleteFile(string sUploadPathAndFileName)
        {
            try
            {
                File.Delete(sUploadPathAndFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 获取目录
        /// <summary>
        /// 获取远程目录中文件信息及子文件夹信息
        /// </summary>
        /// <param name="sRemotePath"></param>
        /// <returns></returns>
        public static DataTable GetRemoteDirectory(string sRemotePath)
        {
            return new DataTable();
            //UploadService us = GetUploadService();
            //return us.GetFilesByDirectory(sRemotePath);
        }
        #endregion
        #endregion

        #region 私有方法
        public static void CreateDirectory(string sPath)
        {
            if (!Directory.Exists(Path.GetDirectoryName(sPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(sPath));
            }
        }
        private static bool WriteFile(byte[] bufferData, string sPathAndFileName)
        {
            try
            {
                sPathAndFileName = HttpContext.Current.Server.MapPath(sPathAndFileName);
                CreateDirectory(sPathAndFileName);
                File.WriteAllBytes(sPathAndFileName, bufferData);
            }
            catch (Exception exception)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 得到水印图片
        /// </summary>
        /// <returns></returns>
        private static Image GetWaterMarkImage()
        {
            string waterMarkPic = ConfigurationManager.AppSettings["WaterMarkPic"] ?? "/resource/watermark.png";
            if (waterMarkPic == "") return null;
            return Image.FromFile(HttpContext.Current.Server.MapPath(waterMarkPic));
        }

        private static WaterPosition GetWaterPosition(float width, float height, float waterMarkWidth, float waterMarkHeight, WaterPositionOptions position)
        {
            WaterPosition position2 = new WaterPosition();
            switch (position)
            {
                case WaterPositionOptions.LeftTop:
                    position2.X = 0f;
                    position2.Y = 0f;
                    break;
                case WaterPositionOptions.RightTop:
                    position2.X = width - waterMarkWidth;
                    position2.Y = 0f;
                    break;
                case WaterPositionOptions.Middle:
                    position2.X = ((float)(width - waterMarkWidth)) / 2f;
                    position2.Y = ((float)(height - waterMarkHeight)) / 2f;
                    break;

                case WaterPositionOptions.LeftBottom:
                    position2.X = 0f;
                    position2.Y = height - waterMarkHeight;
                    break;

                case WaterPositionOptions.RightBottom:
                    position2.X = width - waterMarkWidth;
                    position2.Y = height - waterMarkHeight;
                    break;
            }
            return position2;
        }

        /// <summary>
        /// 图片压缩
        /// </summary>
        /// <param name="origPath"></param>
        /// <param name="airPath"></param>
        public static bool CompressionImage(string imageBase64, string airPath)
        {
            byte[] img = CompressionImage(imageBase64, 50L);
            CreateImageFromBytes(airPath, img);
            return true;
            //origPath = HttpContext.Current.Server.MapPath(origPath);
            //using (FileStream file = new FileStream(origPath, FileMode.Open)) {
            //    airPath = HttpContext.Current.Server.MapPath(airPath);
            //    CreateDirectory(airPath);
            //    Image image = Image.FromFile(origPath);
            //    byte[] img = CompressionImage(file, 50L);
            //    CreateImageFromBytes(airPath, img);
            //}
        }

        /// <summary>
        /// Convert Byte[] to Image
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Convert Byte[] to a picture and Store it in file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static string CreateImageFromBytes(string fileName, byte[] buffer)
        {
            string file = HttpContext.Current.Server.MapPath(fileName);
            Image image = BytesToImage(buffer);
            FileInfo info = new FileInfo(file);
            CreateDirectory(file);
            File.WriteAllBytes(file, buffer);
            return file;
        }

        /// <summary>
        /// 压缩图片 /// </summary>
        /// <param name="fileStream">图片流</param>
        /// <param name="quality">压缩质量0-100之间 数值越大质量越高</param>
        /// <returns></returns>
        private static byte[] CompressionImage(string imageBase64, long quality)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(imageBase64);
                using (MemoryStream ms = new MemoryStream(arr))
                {
                    Bitmap bmp = new Bitmap(ms);
                    Image img = Image.FromStream(ms);///实例化,得到img
                    //using (System.Drawing.Image img = System.Drawing.Image.FromStream(fileStream)) {
                    using (Bitmap bitmap = new Bitmap(img))
                    {
                        ImageCodecInfo CodecInfo = GetEncoder(img.RawFormat);
                        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quality);
                        myEncoderParameters.Param[0] = myEncoderParameter;
                        using (MemoryStream ms2 = new MemoryStream())
                        {
                            bitmap.Save(ms2, CodecInfo, myEncoderParameters);
                            myEncoderParameters.Dispose();
                            myEncoderParameter.Dispose();
                            return ms2.ToArray();
                        }
                    }
                }
                //}
            }
            catch
            {
            }
            return null;
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid) { return codec; }
            }
            return null;
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 获取上传数据流
        /// </summary>
        /// <returns></returns>
        public static byte[] GetUploadBytes(HttpPostedFile postedFile)
        {
            int iLen = postedFile.ContentLength;
            byte[] bytes = new byte[iLen];
            System.IO.Stream fs = postedFile.InputStream;
            fs.Position = 0;
            fs.Read(bytes, 0, iLen);
            return bytes;
        }


        /// <summary>
        /// 根据当前时间来生成文件名字符串
        /// </summary>
        /// <param name="sPrevWord">前缀</param>
        /// <param name="sExt">后缀名</param>
        /// <returns></returns>
        public static string GetFileNameByTime(string sPrevWord, string sExt)
        {
            StringBuilder sb = new StringBuilder();
            DateTime tNow = DateTime.Now;
            sb.Append(sPrevWord);
            sb.Append(tNow.ToString("yyyyMMddHHmmssffff"));
            sb.Append(sExt);
            return sb.ToString();
        }
        /// <summary>
        /// 验证文件扩展名是否合法
        /// </summary>
        /// <param name="sFileName">文件名</param>
        /// <param name="sAllowExt">如：【*.jpg;*.jpeg;*.gif;*.png;】或者【.jpg|.jpeg|.gif|.png】</param>
        /// <returns></returns>
        public static bool CheckFileExt(string sFileName, string sAllowExt)
        {
            string sExt = Path.GetExtension(sFileName.ToLower());
            string[] arr = sAllowExt.ToLower().Trim("*;".ToCharArray()).Replace(";*", "|").Split('|');
            return arr.Contains(sExt);
        }

        public static string GetImgSize(string imageData)
        {
            string imgsize = "";
            if (!String.IsNullOrEmpty(imageData))
            {
                byte[] arr = Convert.FromBase64String(imageData);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                try
                {
                    Image image = Image.FromStream(ms);///实例化,得到img
                    int imgWidth = image.Width;
                    int imgHeight = image.Height;
                    imgsize = imgWidth + "x" + imgHeight;
                    //Log.WriteLog("图片宽：" + picWidth + ",图片高：" + picheight);
                    ms.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return imgsize;

        }

        public static string GetImgSize(string imageData, out int width)
        {
            width = 0;
            string imgsize = "";
            if (!String.IsNullOrEmpty(imageData))
            {
                byte[] arr = Convert.FromBase64String(imageData);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                try
                {
                    Image image = Image.FromStream(ms);///实例化,得到img
                    int imgWidth = image.Width;
                    int imgHeight = image.Height;
                    imgsize = imgWidth + "x" + imgHeight;
                    width = image.Width;
                    //Log.WriteLog("图片宽：" + picWidth + ",图片高：" + picheight);
                    ms.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return imgsize;

        }
        public static Image GetImage(string imageData)
        {
            Image image = null;
            if (!String.IsNullOrEmpty(imageData))
            {
                byte[] arr = Convert.FromBase64String(imageData);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);
                try
                {
                    image = Image.FromStream(ms);///实例化,得到img
                    ms.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return image;
        }


        #endregion
    }
}
