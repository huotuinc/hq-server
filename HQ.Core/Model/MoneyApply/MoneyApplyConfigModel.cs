using System;
namespace HQ.Model
{
    /// <summary>
    /// 提现申请配置实体
    /// </summary>
    [Serializable]
    public partial class MoneyApplyConfigModel
    {
        public MoneyApplyConfigModel()
        { }
        #region Model
        private int _cfgid;
        private int _applytype;
        private decimal _applyfeerate;
        private decimal _applyminfee;
        private decimal _baseamount;
        private int _monthcount;
        private int _settlementday;
        /// <summary>
        /// 自增id
        /// </summary>
        public int CfgId
        {
            set { _cfgid = value; }
            get { return _cfgid; }
        }
        /// <summary>
        /// 提现渠道
        /// </summary>
        public int ApplyType
        {
            set { _applytype = value; }
            get { return _applytype; }
        }
        /// <summary>
        /// 提现手续费率
        /// </summary>
        public decimal ApplyFeeRate
        {
            set { _applyfeerate = value; }
            get { return _applyfeerate; }
        }
        /// <summary>
        /// 最低提现手续费
        /// </summary>
        public decimal ApplyMinFee
        {
            set { _applyminfee = value; }
            get { return _applyminfee; }
        }
        /// <summary>
        /// 起提金额
        /// </summary>
        public decimal BaseAmount
        {
            set { _baseamount = value; }
            get { return _baseamount; }
        }
        /// <summary>
        /// 每月可提现次数
        /// </summary>
        public int MonthCount
        {
            set { _monthcount = value; }
            get { return _monthcount; }
        }
        /// <summary>
        /// 结算时间
        /// </summary>
        public int SettlementDay
        {
            set { _settlementday = value; }
            get { return _settlementday; }
        }
        #endregion Model

    }
}

