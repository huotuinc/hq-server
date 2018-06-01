using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户变更日志
	/// </summary>
	[Serializable]
	public partial class UserLogsModel
	{
		public UserLogsModel()
		{}
		#region Model
		private int _logid;
		private int _userid;
		private int _logtype;
		private string _reamark;
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
		public string Reamark
		{
			set{ _reamark=value;}
			get{return _reamark;}
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

