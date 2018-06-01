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
        { }
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
        private int _userid;
        private int _agentid;
        private int _plattype;
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 外部订单Id
        /// </summary>
        public string OrderSn
        {
            set { _ordersn = value; }
            get { return _ordersn; }
        }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime? PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 订单状态描述
        /// </summary>
        public string StatusDesc
        {
            set { _statusdesc = value; }
            get { return _statusdesc; }
        }
        /// <summary>
        /// 成团时间
        /// </summary>
        public DateTime? GroupSuccessTime
        {
            set { _groupsuccesstime = value; }
            get { return _groupsuccesstime; }
        }
        /// <summary>
        /// 确认收货时间
        /// </summary>
        public DateTime? ReceiveTime
        {
            set { _receivetime = value; }
            get { return _receivetime; }
        }
        /// <summary>
        /// 订单来源
        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? ModifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// 佣金金额
        /// </summary>
        public decimal? PromotionAmount
        {
            set { _promotionamount = value; }
            get { return _promotionamount; }
        }
        /// <summary>
        /// 订单实际支付金额
        /// </summary>
        public decimal? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? GoodsPrice
        {
            set { _goodsprice = value; }
            get { return _goodsprice; }
        }
        /// <summary>
        /// 购买数量
        /// </summary>
        public int? GoodsQuantity
        {
            set { _goodsquantity = value; }
            get { return _goodsquantity; }
        }
        /// <summary>
        /// 商品主图(缩略图)
        /// </summary>
        public string GoodsThumbnailUrl
        {
            set { _goodsthumbnailurl = value; }
            get { return _goodsthumbnailurl; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        /// <summary>
        /// 商品Id
        /// </summary>
        public string GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 推广位id
        /// </summary>
        public string PId
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 扩展参数
        /// </summary>
        public string CustomParameters
        {
            set { _customparameters = value; }
            get { return _customparameters; }
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 所属代理商id
        /// </summary>
        public int AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 所属平台，对应枚举HQEnums.PlatformTypeOptions
        /// </summary>
        public int PlatType
        {
            set { _plattype = value; }
            get { return _plattype; }
        }
        #endregion Model

    }
}

