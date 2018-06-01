using System;
namespace HQ.Model
{
	/// <summary>
	/// 好券圈(分享中心)文章实体
	/// </summary>
	[Serializable]
	public partial class ShareZoneArticleModel
	{
		public ShareZoneArticleModel()
		{}
		#region Model
		private int? _shareid;
		private string _sharecontent;
		private string _shareimglist;
		private DateTime? _createtime;
		private int? _sharecount;
		private string _goodsid;
		private decimal? _promotionamount;
		private int? _catid;
		private DateTime? _showtime;
		private DateTime? _hidetime;
		private string _videolist;
		private int? _plattype;
		/// <summary>
		/// 
		/// </summary>
		public int? ShareId
		{
			set{ _shareid=value;}
			get{return _shareid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShareContent
		{
			set{ _sharecontent=value;}
			get{return _sharecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ShareImgList
		{
			set{ _shareimglist=value;}
			get{return _shareimglist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ShareCount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsId
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PromotionAmount
		{
			set{ _promotionamount=value;}
			get{return _promotionamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CatId
		{
			set{ _catid=value;}
			get{return _catid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ShowTime
		{
			set{ _showtime=value;}
			get{return _showtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? HideTime
		{
			set{ _hidetime=value;}
			get{return _hidetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoList
		{
			set{ _videolist=value;}
			get{return _videolist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlatType
		{
			set{ _plattype=value;}
			get{return _plattype;}
		}
		#endregion Model

	}
}

