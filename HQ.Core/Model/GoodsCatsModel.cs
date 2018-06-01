using System;
namespace HQ.Model
{
	/// <summary>
	/// 商品分类实体
	/// </summary>
	[Serializable]
	public partial class GoodsCatsModel
	{
		public GoodsCatsModel()
		{}
		#region Model
		private int _id;
		private int? _plattype;
		private string _name;
		private int? _parentid;
		private int? _level;
		private string _icon;
		private int? _sortnum;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Level
		{
			set{ _level=value;}
			get{return _level;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Icon
		{
			set{ _icon=value;}
			get{return _icon;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
		}
		#endregion Model

	}
}

