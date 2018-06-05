using HQ.Common;
using HQ.Core.BLL.ManagerProvider;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb
{
    public partial class AjaxHandler : PageBaseHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxResult result = null;
            switch (this.Action)
            {
                case "login":
                    result = this.Login();
                    break;
                case "logout":
                    result = this.Logout();
                    break;
            }
            Response.ContentType = "application/json";
            Response.Write(JsonConvert.SerializeObject(result));
            Response.End();
        }

        private AjaxResult Login()
        {
            int roleType = this.GetFormValue("roletype", 0);
            string loginName = this.GetFormValue("loginname", "");
            string passWord = this.GetFormValue("password", "");
            if (loginName == "" || passWord == "")
            {
                return AjaxResult.resultWith(AjaxResultEnum.处理失败, "账号名或密码未输入", null);
            }
            ManagerProviderBase provider = ManagerProviderFactory.Current.GetInstance((HQEnums.ManagerRoleOptions)roleType);
            int result = provider.DoLogin(loginName, passWord);
            if (result == 0)
            {
                return AjaxResult.resultWith(AjaxResultEnum.处理失败, "账号被锁定", null);
            }
            else if (result == 1)
            {
                return AjaxResult.resultWith(AjaxResultEnum.请求成功);
            }
            return AjaxResult.resultWith(AjaxResultEnum.处理失败, "账号名或密码错误", null);
        }

        private AjaxResult Logout()
        {
            ManagerProviderBase provider = ManagerProviderFactory.Current.GetInstance(HQEnums.ManagerRoleOptions.后台管理员);
            provider.DoLoginOut();

            return AjaxResult.resultWith(AjaxResultEnum.请求成功);
        }

        public string Action
        {
            get
            {
                return this.GetFormValue("action", "");
            }
        }
    }
}