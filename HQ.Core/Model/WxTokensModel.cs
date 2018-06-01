using System;
namespace HQ.Model
{
	/// <summary>
	/// 微信token维护实体
	/// </summary>
	[Serializable]
	public partial class WxTokensModel
	{
		public WxTokensModel()
		{}
		#region Model
		private int _id;
		private string _token;
		private DateTime? _buildtime;
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
		public string Token
		{
			set{ _token=value;}
			get{return _token;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BuildTime
		{
			set{ _buildtime=value;}
			get{return _buildtime;}
		}
		#endregion Model

	}
}

