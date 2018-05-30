using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model.SystemConfig
{
    /// <summary>
    /// 后台管理员实体
    /// </summary>
    public class ManagerModel
    {
        #region Model
        private int _managerid;
        private string _loginname;
        private string _password;
        private DateTime? _lastlogintime;
        private string _lastloginip;
        private DateTime? _createtime;
        private bool _islocked;
        private string _remark;
        private bool _issuper;
        private string _authmenus;
        private string _authfuncs;
        /// <summary>
        /// 
        /// </summary>
        public int ManagerId
        {
            set { _managerid = value; }
            get { return _managerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIp
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsLocked
        {
            set { _islocked = value; }
            get { return _islocked; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuper
        {
            set { _issuper = value; }
            get { return _issuper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthMenus
        {
            set { _authmenus = value; }
            get { return _authmenus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuthFuncs
        {
            set { _authfuncs = value; }
            get { return _authfuncs; }
        }
        #endregion Model
    }
}
