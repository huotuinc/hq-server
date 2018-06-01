using System;
namespace HQ.Model
{
	/// <summary>
	/// 返利(佣金)变更日志
	/// </summary>
	[Serializable]
	public partial class RebateLogsModel
	{
		public RebateLogsModel()
		{}
		#region Model
		private int _logid;
		private int? _userid;
		private int? _rebateid;
		private decimal? _chgmoney;
		private int? _logtype;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int LogId
		{
			set{ _logid=value;}
			get{return _logid;}
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
		public int? RebateId
		{
			set{ _rebateid=value;}
			get{return _rebateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ChgMoney
		{
			set{ _chgmoney=value;}
			get{return _chgmoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LogType
		{
			set{ _logtype=value;}
			get{return _logtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

