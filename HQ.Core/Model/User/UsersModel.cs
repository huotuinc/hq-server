using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户实体
	/// </summary>
	[Serializable]
	public partial class UsersModel
	{
		public UsersModel()
		{}
		#region Model
		private int _userid;
		private int? _levelid;
		private string _wxnickname;
		private string _wxheadimg;
		private DateTime? _regtime;
		private string _loginname;
		private string _password;
		private int? _agentid;
		private int? _isagentproxy;
		private int? _belongoneid;
		private int? _belongtwoid;
		private int? _belongthreeid;
		private decimal? _balance;
		private decimal? _lockbalance;
		private decimal? _totalrebate;
		private string _promotionid;
		private string _promotionextid;
		private string _realname;
		private int? _islocked;
		private string _token;
		private string _invitecode;
		/// <summary>
		/// 
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LevelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WxNickName
		{
			set{ _wxnickname=value;}
			get{return _wxnickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WxHeadImg
		{
			set{ _wxheadimg=value;}
			get{return _wxheadimg;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
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
		public int? IsAgentProxy
		{
			set{ _isagentproxy=value;}
			get{return _isagentproxy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BelongOneId
		{
			set{ _belongoneid=value;}
			get{return _belongoneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BelongTwoId
		{
			set{ _belongtwoid=value;}
			get{return _belongtwoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? BelongThreeId
		{
			set{ _belongthreeid=value;}
			get{return _belongthreeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LockBalance
		{
			set{ _lockbalance=value;}
			get{return _lockbalance;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalRebate
		{
			set{ _totalrebate=value;}
			get{return _totalrebate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PromotionId
		{
			set{ _promotionid=value;}
			get{return _promotionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PromotionExtId
		{
			set{ _promotionextid=value;}
			get{return _promotionextid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsLocked
		{
			set{ _islocked=value;}
			get{return _islocked;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Token
		{
			set{ _token=value;}
			get{return _token;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InviteCode
		{
			set{ _invitecode=value;}
			get{return _invitecode;}
		}
		#endregion Model

	}
}

