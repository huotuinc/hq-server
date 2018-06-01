using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户收藏实体
	/// </summary>
	[Serializable]
	public partial class UserFavoriteModel
	{
		public UserFavoriteModel()
		{}
		#region Model
		private int _favid;
		private int? _userid;
		private long? _goodsid;
		private DateTime? _createtime;
		private int? _plattype;
		/// <summary>
		/// 
		/// </summary>
		public int FavId
		{
			set{ _favid=value;}
			get{return _favid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long? GoodsId
		{
			set{ _goodsid=value;}
			get{return _goodsid;}
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
		public int? PlatType
		{
			set{ _plattype=value;}
			get{return _plattype;}
		}
		#endregion Model

	}
}

