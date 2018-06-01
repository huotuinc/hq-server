using System;
namespace HQ.Model
{
	/// <summary>
	/// 用户第三方授权绑定实体
	/// </summary>
	[Serializable]
	public partial class UserOAuthBondsModel
	{
		public UserOAuthBondsModel()
		{}
		#region Model
		private decimal _bindid;
		private int _userid;
		private int _oauthtype;
		private string _identification;
		private string _refreshtoken;
		private DateTime _oauthtime;
		private string _oauthuinfo;
		private string _wxunionid;
		/// <summary>
		/// 自增id
		/// </summary>
		public decimal BindId
		{
			set{ _bindid=value;}
			get{return _bindid;}
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
		/// 授权类型
		/// </summary>
		public int OauthType
		{
			set{ _oauthtype=value;}
			get{return _oauthtype;}
		}
		/// <summary>
		/// 标识
		/// </summary>
		public string Identification
		{
			set{ _identification=value;}
			get{return _identification;}
		}
		/// <summary>
		/// 刷新token
		/// </summary>
		public string RefreshToken
		{
			set{ _refreshtoken=value;}
			get{return _refreshtoken;}
		}
		/// <summary>
		/// 授权时间
		/// </summary>
		public DateTime OauthTime
		{
			set{ _oauthtime=value;}
			get{return _oauthtime;}
		}
		/// <summary>
		/// 授权返回信息
		/// </summary>
		public string OauthUInfo
		{
			set{ _oauthuinfo=value;}
			get{return _oauthuinfo;}
		}
		/// <summary>
		/// 微信unionid
		/// </summary>
		public string WxUnionId
		{
			set{ _wxunionid=value;}
			get{return _wxunionid;}
		}
		#endregion Model

	}
}

