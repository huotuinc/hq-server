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
        { }
        #region Model
        private int _id;
        private string _token;
        private DateTime _buildtime;
        /// <summary>
        /// 自增id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 微信accesstoken
        /// </summary>
        public string Token
        {
            set { _token = value; }
            get { return _token; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime BuildTime
        {
            set { _buildtime = value; }
            get { return _buildtime; }
        }

        public int TypeKey { get; set; }
        #endregion Model

    }
}

