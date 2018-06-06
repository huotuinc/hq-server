using System;
using System.Collections.Generic;
using static HQ.Core.Enum.HQEnums;

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
		public List<UpgradeConditionModel> UpgradeCondition { get; set; }
        /// <summary>
		/// 等级类型(0-普通会员,10-代理商,20-运营商,30-军团长,40-分公司) 
		/// </summary>
		public UserLevelTypeOptions LevelType { get; set; }
        /// <summary>
        /// 升级模式(默认0-手动,1-自动)
        /// </summary>
        public int LevelModel { get; set; }
        #endregion Model

    }

    public class UpgradeConditionModel
    {
        /// <summary>
        /// 关键词
        /// </summary>
        public string ConditionKey { get; set;}
        /// <summary>
        /// 描述
        /// </summary>
        public string ConditionDecs { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public int ConditionValue { get; set; }
        /// <summary>
        /// 且or或(默认0-且,1-或)
        /// </summary>
        public int ConditionType { get; set; }
    }
}

