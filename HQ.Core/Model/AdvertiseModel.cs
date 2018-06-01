using System;
namespace HQ.Model
{
	/// <summary>
	/// 广告位
	/// </summary>
	[Serializable]
	public partial class AdvertiseModel
	{
		public AdvertiseModel()
		{}
		#region Model
		private int _adid;
		private int _adtype;
		private string _linkpic;
		private string _linkdata;
		private int _linktype;
		private int _status;
		private DateTime _createtime;
		private DateTime _begintime;
		private DateTime _endtime;
		private int _sortnum;
		private string _title;
		private string _remark;
		private int _plattype;
		/// <summary>
		/// 自增id
		/// </summary>
		public int AdId
		{
			set{ _adid=value;}
			get{return _adid;}
		}
		/// <summary>
		/// 广告类型，对应枚举HQEnums.xx
		/// </summary>
		public int AdType
		{
			set{ _adtype=value;}
			get{return _adtype;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string LinkPic
		{
			set{ _linkpic=value;}
			get{return _linkpic;}
		}
		/// <summary>
		/// 链接业务数据
		/// </summary>
		public string LinkData
		{
			set{ _linkdata=value;}
			get{return _linkdata;}
		}
		/// <summary>
		/// 链接类型，对应枚举HQEnums.xx
		/// </summary>
		public int LinkType
		{
			set{ _linktype=value;}
			get{return _linktype;}
		}
		/// <summary>
		/// 状态
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			set{ _begintime=value;}
			get{return _begintime;}
		}
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 排序号
		/// </summary>
		public int SortNum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
		}
		/// <summary>
		/// 标题，暂不用
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 备注信息
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        /// <summary>
        /// 所属平台类型，HQEnums.PlatformTypeOptions
        /// </summary>
        public int PlatType
		{
			set{ _plattype=value;}
			get{return _plattype;}
		}
		#endregion Model

	}
}

