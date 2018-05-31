using System;
using Newtonsoft.Json;
namespace HQ.Core.Model.Gallery
{
	/// <summary>
	/// 图片分组实体
	/// </summary>
	[Serializable]
	public partial class PhotoGroupModel
	{
        public PhotoGroupModel()
		{}
		#region Model
		private int _photoid;
		private string _photoname;
		private int? _fatherid;
		private int? _photo_customer_id;
		private string _photo_cover;
		private DateTime? _photo_time;
		/// <summary>
		/// 图库文件夹id
		/// </summary>
        [JsonProperty(PropertyName="id")]
		public int PhotoID
		{
			set{ _photoid=value;}
			get{return _photoid;}
		}
		/// <summary>
		/// 图库文件夹名称
		/// </summary>
        [JsonProperty(PropertyName = "name")]
		public string PhotoName
		{
			set{ _photoname=value;}
			get{return _photoname;}
		}
		/// <summary>
		/// 父级id
		/// </summary>
        [JsonProperty(PropertyName = "parentId")]
		public int? FatherID
		{
			set{ _fatherid=value;}
			get{return _fatherid;}
		}
		/// <summary>
		/// 商户id
		/// </summary>
        [JsonProperty(PropertyName = "customerId")]
		public int? Photo_Customer_ID
		{
			set{ _photo_customer_id=value;}
			get{return _photo_customer_id;}
		}
		/// <summary>
		/// 图库文件夹封面
		/// </summary>
        [JsonProperty(PropertyName = "thumb")]
		public string Photo_Cover
		{
			set{ _photo_cover=value;}
			get{return _photo_cover;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
        [JsonProperty(PropertyName = "createTime")]
		public DateTime? Photo_Time
		{
			set{ _photo_time=value;}
			get{return _photo_time;}
		}
        /// <summary>
        /// 文件夹深度
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string FilePath { get; set; }
		#endregion Model

	}

    public class ResultMallPhotoGroup {
        /// <summary>
        /// 分组ID
        /// </summary>
        public int id { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public int parentId { set; get; }

        /// <summary>
        /// 商户ID
        /// </summary>
        public int customerId { set; get; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string thumb { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { set; get; }

        /// <summary>
        /// 路径
        /// </summary>
        public string path { set; get; }

        /// <summary>
        /// 图片数量
        /// </summary>
        public int count { set; get; }
    }
}

