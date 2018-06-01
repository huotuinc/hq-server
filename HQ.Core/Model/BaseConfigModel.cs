using System;
namespace HQ.Model
{
    /// <summary>
    /// 基础配置实体
    /// </summary>
    [Serializable]
    public partial class BaseConfigModel
    {
        public BaseConfigModel()
        { }
        #region Model
        private int _configid;
        private string _wxappid;
        private string _wxappsecret;
        private int _rebatemode;
        private string _rebatesetting;
        private string _smssetting;
        private string _maindomain;
        /// <summary>
        /// 自增id
        /// </summary>
        public int ConfigId
        {
            set { _configid = value; }
            get { return _configid; }
        }
        /// <summary>
        /// 微信appid
        /// </summary>
        public string WxAppId
        {
            set { _wxappid = value; }
            get { return _wxappid; }
        }
        /// <summary>
        /// 微信appsecret
        /// </summary>
        public string WxAppSecret
        {
            set { _wxappsecret = value; }
            get { return _wxappsecret; }
        }
        /// <summary>
        /// 返利模式
        /// </summary>
        public int RebateMode
        {
            set { _rebatemode = value; }
            get { return _rebatemode; }
        }
        /// <summary>
        /// 返利设置信息
        /// </summary>
        public string RebateSetting
        {
            set { _rebatesetting = value; }
            get { return _rebatesetting; }
        }
        /// <summary>
        /// 短信设置信息
        /// </summary>
        public string SmsSetting
        {
            set { _smssetting = value; }
            get { return _smssetting; }
        }
        /// <summary>
        /// 主域名
        /// </summary>
        public string MainDomain
        {
            set { _maindomain = value; }
            get { return _maindomain; }
        }
        #endregion Model

    }
}

