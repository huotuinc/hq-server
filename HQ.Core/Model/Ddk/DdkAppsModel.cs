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
        { }
        #region Model
        private int _appid;
        private int? _agentid;
        private string _clientid;
        private string _clientsecret;
        private int _ismain;
        private int _status;
        private int? _bindagentid;
        /// <summary>
        /// AppId
        /// </summary>
        public int AppId
        {
            set { _appid = value; }
            get { return _appid; }
        }
        /// <summary>
        /// 废弃
        /// </summary>
        public int? AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClientId
        {
            set { _clientid = value; }
            get { return _clientid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ClientSecret
        {
            set { _clientsecret = value; }
            get { return _clientsecret; }
        }
        /// <summary>
        /// 是否主应用
        /// </summary>
        public int IsMain
        {
            set { _ismain = value; }
            get { return _ismain; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 绑定的代理商id
        /// </summary>
        public int? BindAgentId
        {
            set { _bindagentid = value; }
            get { return _bindagentid; }
        }
        #endregion Model

    }
}

