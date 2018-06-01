using System;
namespace HQ.Model
{
	/// <summary>
	/// 多多客应用
	/// </summary>
	[Serializable]
	public partial class DdkAppsModel
	{
		public DdkAppsModel()
		{}
		#region Model
		private int _appid;
		private int? _agentid;
		private string _clientid;
		private string _clientsecret;
		private int? _ismain;
		private int? _status;
		private int? _bindagentid;
		/// <summary>
		/// 
		/// </summary>
		public int AppId
		{
			set{ _appid=value;}
			get{return _appid;}
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
		public string ClientId
		{
			set{ _clientid=value;}
			get{return _clientid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ClientSecret
		{
			set{ _clientsecret=value;}
			get{return _clientsecret;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsMain
		{
			set{ _ismain=value;}
			get{return _ismain;}
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
		public int? BindAgentId
		{
			set{ _bindagentid=value;}
			get{return _bindagentid;}
		}
		#endregion Model

	}
}

