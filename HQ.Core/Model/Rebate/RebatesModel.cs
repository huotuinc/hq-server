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
        { }
        #region Model
        private int _id;
        private int _userid;
        private int _rebatetype;
        private decimal _flowmoney;
        private decimal _finalmoney;
        private DateTime _createtime;
        private DateTime? _lastmodify;
        private string _rebatedesc;
        private int _contribuserid;
        private int _settlestatus;
        private int _contribdepth;
        private string _orderid;
        private int _agentid;
        private int _plattype;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
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
        /// 返利类型
        /// </summary>
        public int RebateType
        {
            set { _rebatetype = value; }
            get { return _rebatetype; }
        }
        /// <summary>
        /// 总返利
        /// </summary>
        public decimal FlowMoney
        {
            set { _flowmoney = value; }
            get { return _flowmoney; }
        }
        /// <summary>
        /// 实际可得返利
        /// </summary>
        public decimal FinalMoney
        {
            set { _finalmoney = value; }
            get { return _finalmoney; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModify
        {
            set { _lastmodify = value; }
            get { return _lastmodify; }
        }
        /// <summary>
        /// 返利描述
        /// </summary>
        public string RebateDesc
        {
            set { _rebatedesc = value; }
            get { return _rebatedesc; }
        }
        /// <summary>
        /// 贡献人
        /// </summary>
        public int ContribUserId
        {
            set { _contribuserid = value; }
            get { return _contribuserid; }
        }
        /// <summary>
        /// 结算状态
        /// </summary>
        public int SettleStatus
        {
            set { _settlestatus = value; }
            get { return _settlestatus; }
        }
        /// <summary>
        /// 贡献人距离获得返利人的深度
        /// </summary>
        public int ContribDepth
        {
            set { _contribdepth = value; }
            get { return _contribdepth; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 代理商id
        /// </summary>
        public int AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 所属平台类型
        /// </summary>
        public int PlatType
        {
            set { _plattype = value; }
            get { return _plattype; }
        }
        #endregion Model

    }
}

