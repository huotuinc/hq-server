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
		private int _levelno;
		private string _levelname;
		private string _remark;
		private DateTime _createtime;
		private string _upgradecondition;
		/// <summary>
		/// 等级id
		/// </summary>
		public int LevelId
		{
			set{ _levelid=value;}
			get{return _levelid;}
		}
		/// <summary>
		/// 等级序号
		/// </summary>
		public int LevelNo
		{
			set{ _levelno=value;}
			get{return _levelno;}
		}
		/// <summary>
		/// 等级名称
		/// </summary>
		public string LevelName
		{
			set{ _levelname=value;}
			get{return _levelname;}
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
		/// 添加时间
		/// </summary>
		public DateTime Createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 升级条件
		/// </summary>
		public string UpgradeCondition
		{
			set{ _upgradecondition=value;}
			get{return _upgradecondition;}
		}
		#endregion Model

	}
}

