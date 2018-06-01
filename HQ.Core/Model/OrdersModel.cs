using System;
namespace HQ.Model
{
	/// <summary>
	/// 订单实体
	/// </summary>
	[Serializable]
	public partial class OrdersModel
	{
		public OrdersModel()
		{}
		#region Model
		private string _orderid;
		private string _ordersn;
		private DateTime? _paytime;
		private int? _status;
		private string _statusdesc;
		private DateTime? _groupsuccesstime;
		private DateTime? _receivetime;
		private int? _ordertype;
		private DateTime? _modifytime;
		private decimal? _promotionamount;
		private decimal? _amount;
		private decimal? _goodsprice;
		private int? _goodsquantity;
		private string _goodsthumbnailurl;
		private string _goodsname;
		private string _goodsid;
		private string _pid;
		private string _customparameters;
		private int? _userid;
		private int? _agentid;
		private int? _plattype;
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
		public string OrderSn
		{
			set{ _ordersn=value;}
			get{return _ordersn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PayTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StatusDesc
		{
			set{ _statusdesc=value;}
			get{return _statusdesc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? GroupSuccessTime
		{
			set{ _groupsuccesstime=value;}
			get{return _groupsuccesstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ReceiveTime
		{
			set{ _receivetime=value;}
			get{return _receivetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OrderType
		{
			set{ _ordertype=value;}
			get{return _ordertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ModifyTime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
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
		public decimal? Amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? GoodsPrice
		{
			set{ _goodsprice=value;}
			get{return _goodsprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? GoodsQuantity
		{
			set{ _goodsquantity=value;}
			get{return _goodsquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsThumbnailUrl
		{
			set{ _goodsthumbnailurl=value;}
			get{return _goodsthumbnailurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GoodsName
		{
			set{ _goodsname=value;}
			get{return _goodsname;}
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
		public string PId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomParameters
		{
			set{ _customparameters=value;}
			get{return _customparameters;}
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

