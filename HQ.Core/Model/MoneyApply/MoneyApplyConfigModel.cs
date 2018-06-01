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
		{}
		#region Model
		private int _cfgid;
		private int? _applytype;
		private decimal? _applyfeerate;
		private decimal? _applyminfee;
		private decimal? _baseamount;
		private int? _monthcount;
		private int? _settlementday;
		/// <summary>
		/// 
		/// </summary>
		public int CfgId
		{
			set{ _cfgid=value;}
			get{return _cfgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApplyType
		{
			set{ _applytype=value;}
			get{return _applytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ApplyFeeRate
		{
			set{ _applyfeerate=value;}
			get{return _applyfeerate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ApplyMinFee
		{
			set{ _applyminfee=value;}
			get{return _applyminfee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BaseAmount
		{
			set{ _baseamount=value;}
			get{return _baseamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? MonthCount
		{
			set{ _monthcount=value;}
			get{return _monthcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SettlementDay
		{
			set{ _settlementday=value;}
			get{return _settlementday;}
		}
		#endregion Model

	}
}

