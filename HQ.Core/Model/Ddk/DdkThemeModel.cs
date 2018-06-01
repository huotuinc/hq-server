using System;
namespace HQ.Model
{
	/// <summary>
	/// 多多客主题实体
	/// </summary>
	[Serializable]
	public partial class DdkThemeModel
	{
		public DdkThemeModel()
		{}
		#region Model
		private int? _themeid;
		private string _imageurl;
		private string _name;
		private int? _goodsnum;
		private DateTime? _updatetime;
		/// <summary>
		/// 
		/// </summary>
		public int? ThemeId
		{
			set{ _themeid=value;}
			get{return _themeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GoodsNum
		{
			set{ _goodsnum=value;}
			get{return _goodsnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

	}
}

