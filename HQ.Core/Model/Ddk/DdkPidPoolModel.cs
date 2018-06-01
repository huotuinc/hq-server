using System;
namespace HQ.Model
{
	/// <summary>
	/// 多多客PID池实体
	/// </summary>
	[Serializable]
	public partial class DdkPidPoolModel
	{
		public DdkPidPoolModel()
		{}
		#region Model
		private int _id;
		private string _pid;
		private int? _appid;
		private bool _usestatus;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PId
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AppId
		{
			set{ _appid=value;}
			get{return _appid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UseStatus
		{
			set{ _usestatus=value;}
			get{return _usestatus;}
		}
		#endregion Model

	}
}

