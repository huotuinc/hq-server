using System;
namespace HQ.Model
{
	/// <summary>
	/// 热门搜索关键字实体
	/// </summary>
	[Serializable]
	public partial class HotKeywordModel
	{
		public HotKeywordModel()
		{}
		#region Model
		private int _id;
		private int? _plattype;
		private string _keyword;
		private int? _sortnum;
		private DateTime? _createtime;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PlatType
		{
			set{ _plattype=value;}
			get{return _plattype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

