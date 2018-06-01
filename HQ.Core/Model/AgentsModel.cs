using System;
namespace HQ.Model
{
	/// <summary>
	/// 代理商实体
	/// </summary>
	[Serializable]
	public partial class AgentsModel
	{
		public AgentsModel()
		{}
		#region Model
		private int _agentid;
		private int? _agenttype;
		private string _nickname;
		private string _loginname;
		private string _password;
		private int? _status;
		private DateTime? _createtime;
		private string _lastloginip;
		private DateTime? _lastlogintime;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int AgentId
		{
			set{ _agentid=value;}
			get{return _agentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AgentType
		{
			set{ _agenttype=value;}
			get{return _agenttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
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
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastLoginIp
		{
			set{ _lastloginip=value;}
			get{return _lastloginip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastLoginTime
		{
			set{ _lastlogintime=value;}
			get{return _lastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

