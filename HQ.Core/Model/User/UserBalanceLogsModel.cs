using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户余额变动流水实体
	/// </summary>
	[Serializable]
	public partial class UserBalanceLogsModel
	{
		public UserBalanceLogsModel()
		{}
		#region Model
		private int _logid;
		private int _userid;
		private decimal _chgmoney;
		private decimal _beforemoney;
		private decimal _aftermoney;
		private int _logtype;
		private string _remark;
		private DateTime _createtime;
		/// <summary>
		/// 自增id
		/// </summary>
		public int LogId
		{
			set{ _logid=value;}
			get{return _logid;}
		}
		/// <summary>
		/// 用户id
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 变动金额
		/// </summary>
		public decimal ChgMoney
		{
			set{ _chgmoney=value;}
			get{return _chgmoney;}
		}
		/// <summary>
		/// 变动前金额
		/// </summary>
		public decimal BeforeMoney
		{
			set{ _beforemoney=value;}
			get{return _beforemoney;}
		}
		/// <summary>
		/// 变动后金额
		/// </summary>
		public decimal AfterMoney
		{
			set{ _aftermoney=value;}
			get{return _aftermoney;}
		}
		/// <summary>
		/// 日志类型
		/// </summary>
		public int LogType
		{
			set{ _logtype=value;}
			get{return _logtype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

