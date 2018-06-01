using System;
namespace HQ.Model
{
    /// <summary>
    /// 好券圈(分享中心)文章分类实体
    /// </summary>
    [Serializable]
	public partial class ShareZoneCatModel
	{
		public ShareZoneCatModel()
		{}
		#region Model
		private int _catid;
		private string _catname;
		private int? _sortnum;
		private int? _status;
		/// <summary>
		/// 
		/// </summary>
		public int CatId
		{
			set{ _catid=value;}
			get{return _catid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CatName
		{
			set{ _catname=value;}
			get{return _catname;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

