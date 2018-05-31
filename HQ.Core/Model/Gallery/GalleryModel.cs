using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
namespace HQ.Core.Model.Gallery
{
    /// <summary>
    /// 图片库实体
    /// </summary>
    [Serializable]
    public partial class GalleryModel
    {
        public GalleryModel()
        { }
        #region Model
        private int _callery_id;
        private int? _callery_customer_id;
        private string _callery_size;
        private string _callery_name;
        private string _callery_thumbnailpic;
        private string _callery_smallpic;
        private string _callery_bigpic;
        private DateTime? _callery_time = DateTime.Now;
        private DateTime? _callery_updatetime = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName="id")]
        public int Callery_ID
        {
            set { _callery_id = value; }
            get { return _callery_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "customerId")]
        public int? Callery_Customer_ID
        {
            set { _callery_customer_id = value; }
            get { return _callery_customer_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public string Callery_Size
        {
            set { _callery_size = value; }
            get { return _callery_size; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Callery_Name
        {
            set { _callery_name = value; }
            get { return _callery_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "thumbPic")]
        public string Callery_ThumbnailPic
        {
            set { _callery_thumbnailpic = value; }
            get { return _callery_thumbnailpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "smallPic")]
        public string Callery_SmallPic
        {
            set { _callery_smallpic = value; }
            get { return _callery_smallpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "bigPic")]
        public string Callery_BigPic
        {
            set { _callery_bigpic = value; }
            get { return _callery_bigpic; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "createTime")]
        public DateTime? Callery_Time
        {
            set { _callery_time = value; }
            get { return _callery_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "updateTime")]
        public DateTime? Callery_UpdateTime
        {
            set { _callery_updatetime = value; }
            get { return _callery_updatetime; }
        }
        /// <summary>
        /// 所属图库
        /// </summary>
        [JsonProperty(PropertyName = "groupId")]
        public int Photo_FatherID { get; set; }
        #endregion Model
    }

    public class ResultGallery {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int id { set; get; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int customerId { set; get; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// 图片大小
        /// </summary>
        public string size { set; get; }

        /// <summary>
        /// 图片缩略图相对地址
        /// </summary>
        public string thumbPicUri { set; get; }

        /// <summary>
        /// 图片缩略图绝对地址
        /// </summary>
        public string thumbPicUrl { set; get; }

        /// <summary>
        /// 图片小图相对地址
        /// </summary>
        public string smallPicUri { set; get; }

        /// <summary>
        /// 图片小图绝对地址
        /// </summary>
        public string smallPicUrl { set; get; }

        /// <summary>
        /// 大图相对地址
        /// </summary>
        public string bigPicUri { set; get; }

        /// <summary>
        /// 大图绝对地址
        /// </summary>
        public string bigPicUrl { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { set; get; }

        /// <summary>
        /// 所属分组ID
        /// </summary>
        public int groupId { set; get; }
    }
}
