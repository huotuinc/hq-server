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
        /// 管理员id
        /// </summary>
        public int ManagerId
        {
            set { _managerid = value; }
            get { return _managerid; }
        }
        /// <summary>
        /// 账号名
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
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
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
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLocked
        {
            set { _islocked = value; }
            get { return _islocked; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 是否超管
        /// </summary>
        public bool IsSuper
        {
            set { _issuper = value; }
            get { return _issuper; }
        }
        /// <summary>
        /// 授权的菜单列表
        /// </summary>
        public string AuthMenus
        {
            set { _authmenus = value; }
            get { return _authmenus; }
        }
        /// <summary>
        /// 授权的功能列表
        /// </summary>
        public string AuthFuncs
        {
            set { _authfuncs = value; }
            get { return _authfuncs; }
        }
        #endregion Model
    }
}
