using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户等级实体
	/// </summary>
	[Serializable]
	public partial class UserLevelModel
	{
		public UserLevelModel()
		{}
		#region Model
		private int _levelid;
		private int? _levelno;
		private string _levelname;
		private string _remark;
		private DateTime? _createtime;
		private string _upgradecondition;
		/// <summary>
		/// 
		/// </summary>
		public int LevelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LevelNo
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LevelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		public string UpgradeCondition
		{
			set{ _upgradecondition=value;}
			get{return _upgradecondition;}
		}
		#endregion Model

	}
}

