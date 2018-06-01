using System;
namespace HQ.Model
{
    /// <summary>
    /// 代理商实体
    /// </summary>
    [Serializable]
    public partial class AgentsModel
    {
        public AgentsModel()
        { }
        #region Model
        private int _agentid;
        private int _agenttype;
        private string _nickname;
        private string _loginname;
        private string _password;
        private int _status;
        private DateTime _createtime;
        private string _lastloginip;
        private DateTime? _lastlogintime;
        private string _remark;
        /// <summary>
        /// 代理商id
        /// </summary>
        public int AgentId
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 代理商类型，暂不用
        /// </summary>
        public int AgentType
        {
            set { _agenttype = value; }
            get { return _agenttype; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 最后登录ip
        /// </summary>
        public string LastLoginIp
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

