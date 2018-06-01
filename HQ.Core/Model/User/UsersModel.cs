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
		private int _levelid;
		private string _wxnickname;
		private string _wxheadimg;
		private DateTime? _regtime;
		private string _loginname;
		private string _password;
		private int? _agentid;
		private int _isagentproxy;
		private int _belongoneid;
		private int _belongtwoid;
		private int _belongthreeid;
		private decimal _balance;
		private decimal _lockbalance;
		private decimal _totalrebate;
		private string _promotionid;
		private string _promotionextid;
		private string _realname;
		private int _islocked;
		private string _token;
		private string _invitecode;
		/// <summary>
		/// 用户id
		/// </summary>
		public int UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 等级id
		/// </summary>
		public int LevelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 微信昵称
		/// </summary>
		public string WxNickName
		{
			set{ _wxnickname=value;}
			get{return _wxnickname;}
		}
		/// <summary>
		/// 微信头像
		/// </summary>
		public string WxHeadImg
		{
			set{ _wxheadimg=value;}
			get{return _wxheadimg;}
		}
		/// <summary>
		/// 注册时间
		/// </summary>
		public DateTime? RegTime
		{
			set{ _regtime=value;}
			get{return _regtime;}
		}
		/// <summary>
		/// 账号名
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 所属代理商
		/// </summary>
		public int? AgentId
		{
			set{ _agentid=value;}
			get{return _agentid;}
		}
		/// <summary>
		/// 是否是代理商前台映射用户
		/// </summary>
		public int IsAgentProxy
		{
			set{ _isagentproxy=value;}
			get{return _isagentproxy;}
		}
		/// <summary>
		/// 所属上线id
		/// </summary>
		public int BelongOneId
		{
			set{ _belongoneid=value;}
			get{return _belongoneid;}
		}
        /// <summary>
        /// 所属上上线id
        /// </summary>
        public int BelongTwoId
		{
			set{ _belongtwoid=value;}
			get{return _belongtwoid;}
		}
        /// <summary>
        /// 所属上上上线id
        /// </summary>
        public int BelongThreeId
		{
			set{ _belongthreeid=value;}
			get{return _belongthreeid;}
		}
		/// <summary>
		/// 余额
		/// </summary>
		public decimal Balance
		{
			set{ _balance=value;}
			get{return _balance;}
		}
		/// <summary>
		/// 锁定余额
		/// </summary>
		public decimal LockBalance
		{
			set{ _lockbalance=value;}
			get{return _lockbalance;}
		}
		/// <summary>
		/// 累计返利
		/// </summary>
		public decimal TotalRebate
		{
			set{ _totalrebate=value;}
			get{return _totalrebate;}
		}
		/// <summary>
		/// 多多客推广位id
		/// </summary>
		public string PromotionId
		{
			set{ _promotionid=value;}
			get{return _promotionid;}
		}
        /// <summary>
        /// 多多客推广位id扩展
        /// </summary>
        public string PromotionExtId
		{
			set{ _promotionextid=value;}
			get{return _promotionextid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int IsLocked
		{
			set{ _islocked=value;}
			get{return _islocked;}
		}
		/// <summary>
		/// 用户token
		/// </summary>
		public string Token
		{
			set{ _token=value;}
			get{return _token;}
		}
		/// <summary>
		/// 邀请码
		/// </summary>
		public string InviteCode
		{
			set{ _invitecode=value;}
			get{return _invitecode;}
		}
		#endregion Model

	}
}

