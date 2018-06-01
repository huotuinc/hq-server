using System;
namespace HQ.Model
{
    /// <summary>
    /// 返利(佣金)记录
    /// </summary>
    [Serializable]
	public partial class RebatesModel
	{
		public RebatesModel()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private int? _rebatetype;
		private decimal? _flowmoney;
		private decimal? _finalmoney;
		private DateTime? _createtime;
		private DateTime? _lastmodify;
		private string _rebatedesc;
		private int? _contribuserid;
		private int? _settlestatus;
		private int? _contribdepth;
		private string _orderid;
		private int? _agentid;
		private int? _plattype;
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
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RebateType
		{
			set{ _rebatetype=value;}
			get{return _rebatetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FlowMoney
		{
			set{ _flowmoney=value;}
			get{return _flowmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FinalMoney
		{
			set{ _finalmoney=value;}
			get{return _finalmoney;}
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
		public DateTime? LastModify
		{
			set{ _lastmodify=value;}
			get{return _lastmodify;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RebateDesc
		{
			set{ _rebatedesc=value;}
			get{return _rebatedesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ContribUserId
		{
			set{ _contribuserid=value;}
			get{return _contribuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SettleStatus
		{
			set{ _settlestatus=value;}
			get{return _settlestatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ContribDepth
		{
			set{ _contribdepth=value;}
			get{return _contribdepth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AgentId
		{
			set{ _agentid=value;}
			get{return _agentid;}
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

