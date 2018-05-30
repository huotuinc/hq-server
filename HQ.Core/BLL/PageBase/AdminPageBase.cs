using HQ.Common;
using HQ.Core;
using HQ.Core.BLL.ManagerProvider;
using HQ.Core.Enum;
using HQ.Core.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LM.Core.BLL.PageBase
{
    /// <summary>
    /// 后台页面基类
    /// </summary>
    public class AdminPageBase : PageBaseHelper
    {
        protected int pageIndex = 1;
        protected int pageSize = 20;
        protected int pageCount = 1;
        protected int recordCount = 0;

        /// <summary>
        /// cookie过时
        /// </summary>
        protected int CookieOutExpires = -100;
        /// <summary>
        /// cookie保存时间,分钟为单位
        /// </summary>
        protected int CookieExpires = 60;

        public AdminPageBase()
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);        //优先执行父级的初始化流程
            if (!checklogin())
            {
                ClearCookie();
            }
            this.pageIndex = this.GetQueryString("pageIndex", 1);
        }

        public ManagerViewModel CurrentManager { get; private set; }

        /// <summary>
        /// 是否认证点管理员登录
        /// </summary>
        public bool IsLoginByAgent
        {
            get
            {
                return this.CurrentManager.RoleType == (int)HQEnums.ManagerRoleOptions.代理商管理员;
            }
        }
        /// <summary>
        /// 是否后台管理员登录
        /// </summary>
        public bool IsLoginByBackManager
        {
            get
            {
                return this.CurrentManager.RoleType == (int)HQEnums.ManagerRoleOptions.后台管理员;
            }
        }

        /// <summary>
        /// 检查是否登陆
        /// </summary>
        public bool checklogin()
        {
            this.CurrentManager = this.MockBackManager();
            ManagerProviderFactory.Current.GetDefaultInstance().WriteCookie(this.CurrentManager);
            return true;

            //ManagerProviderBase provider = ManagerProviderFactory.Current.GetCurrentInstance();
            //if (provider == null) return false;
            //ManagerViewModel manager = provider.CheckLogin();
            //if (manager != null)
            //{
            //    this.CurrentManager = manager;
            //    this.currentRoleType = (HQEnums.ManagerRoleOptions)this.CurrentManager.RoleType;
            //    return true;
            //}
            return false;
        }

        #region 模拟登录
        private ManagerViewModel MockBackManager()
        {
            ManagerViewModel viewModel = new ManagerViewModel();
            viewModel.ManagerId = 1;
            viewModel.LoginName = "admin";
            viewModel.Password = "e10adc3949ba59abbe56e057f20f883e";
            viewModel.RoleType = (int)HQEnums.ManagerRoleOptions.后台管理员;
            viewModel.IsSuper = 1;
            viewModel.Noncestr = Guid.NewGuid().ToString().Replace("-", "");
            return viewModel;
        }

        private ManagerViewModel MockAgentManager()
        {
            ManagerViewModel viewModel = new ManagerViewModel();
            viewModel.ManagerId = 1;
            viewModel.LoginName = "agent11";
            viewModel.Password = "e10adc3949ba59abbe56e057f20f883e";
            viewModel.RoleType = (int)HQEnums.ManagerRoleOptions.代理商管理员;
            viewModel.Noncestr = Guid.NewGuid().ToString().Replace("-", "");
            return viewModel;
        }
        #endregion

        protected void ClearCookie()
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddYears(-112);
                Response.Cookies.Add(aCookie);
            }
            Response.Redirect("/Login.aspx");
        }

        /// <summary>
        /// 操作员id，返回0表示不是操作员
        /// </summary>
        protected int ManagerId
        {
            get
            {
                return 0;
            }
        }

        protected HQEnums.ManagerRoleOptions currentRoleType { set; get; }

        //判断是否是超级管理员
        protected bool IsSuperManager { set; get; }

        protected string FilterJsInvalidateChar(string str)
        {
            return str.Replace("'", "").Replace("\r", "").Replace("\n", "");
        }

        protected string CurrentHost
        {
            get
            {
                string host = Request.Url.Host;
                if (host.IndexOf('.') != -1)
                {
                    host = host.Substring(host.IndexOf('.') + 1);
                }
                return host;
            }
        }

        protected string jsSegmentOut = "";
        protected void SetJsSegmentOut(string js)
        {
            this.jsSegmentOut = string.Format("<script>{0}</script>", js);
        }

        #region 无限级分类相关
        char nbsp = (char)0xA0;
        /// <summary>
        /// 获取分类前缀符
        /// </summary>
        /// <param name="catPath"></param>
        /// <returns></returns>
        protected string GetCatPrefix(string catPath)
        {
            int depth = this.GetCatDepth(catPath);
            string prefix = "";
            for (int i = 0; i < depth; i++)
            {
                prefix += nbsp + "" + nbsp;
            }

            prefix += "└ ";
            return prefix;
        }

        /// <summary>
        /// 获取分类深度
        /// </summary>
        /// <param name="catPath"></param>
        /// <returns></returns>
        protected int GetCatDepth(string catPath)
        {
            return catPath.Trim('|').Split('|').Length;
        }
        #endregion

        /// <summary>
        /// 检查是否拥有菜单权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        protected bool CheckMenuPower(string menuId)
        {
            if (string.IsNullOrEmpty(this.CurrentManager.AuthMenus))
            {
                return false;
            }
            string temp = "|" + this.CurrentManager.AuthMenus.Trim('|') + "|";
            return temp.IndexOf("|" + menuId + "|") > -1;
        }
    }
}
