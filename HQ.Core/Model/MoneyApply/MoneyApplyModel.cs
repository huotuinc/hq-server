using System;
namespace HQ.Model
{
    /// <summary>
    /// 提现申请记录实体
    /// </summary>
    [Serializable]
    public partial class MoneyApplyModel
    {
        public MoneyApplyModel()
        { }
        #region Model
        private int _applyid;
        private int _userid;
        private string _username;
        private string _realname;
        private int _applytype;
        private string _applyaccount;
        private decimal _applyamount;
        private int _applystatus;
        private string _applymemo;
        private DateTime _applytime;
        private string _bankname;
        private string _bankinfo;
        private decimal _applyfee;
        private decimal _applyfeerate;
        private int _agentid;
        /// <summary>
        /// 自增id
        /// </summary>
        public int ApplyId
        {
            set { _applyid = value; }
            get { return _applyid; }
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
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 提现方式
        /// </summary>
        public int ApplyType
        {
            set { _applytype = value; }
            get { return _applytype; }
        }
        /// <summary>
        /// 提现账号
        /// </summary>
        public string ApplyAccount
        {
            set { _applyaccount = value; }
            get { return _applyaccount; }
        }
        /// <summary>
        /// 提现金额
        /// </summary>
        public decimal ApplyAmount
        {
            set { _applyamount = value; }
            get { return _applyamount; }
        }
        /// <summary>
        /// 提现状态
        /// </summary>
        public int ApplyStatus
        {
            set { _applystatus = value; }
            get { return _applystatus; }
        }
        /// <summary>
        /// 提现备注
        /// </summary>
        public string ApplyMemo
        {
            set { _applymemo = value; }
            get { return _applymemo; }
        }
        /// <summary>
        /// 提现时间
        /// </summary>
        public DateTime ApplyTime
        {
            set { _applytime = value; }
            get { return _applytime; }
        }
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 所属支行
        /// </summary>
        public string BankInfo
        {
            set { _bankinfo = value; }
            get { return _bankinfo; }
        }
        /// <summary>
        /// 提现手续费
        /// </summary>
        public decimal ApplyFee
        {
            set { _applyfee = value; }
            get { return _applyfee; }
        }
        /// <summary>
        /// 当前手续费率
        /// </summary>
        public decimal ApplyFeeRate
        {
            set { _applyfeerate = value; }
            get { return _applyfeerate; }
        }
        /// <summary>
        /// 所属代理商
        /// </summary>
        public int AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        #endregion Model

    }
}

