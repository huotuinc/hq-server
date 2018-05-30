using HQ.Common;
using HQ.Core.BLL.ManagerProvider;
using LM.Core.BLL.PageBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.SystemConfig
{
    public partial class ModifyPassword : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtLoginName.Value = this.CurrentManager.LoginName;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManagerProviderBase provider = ManagerProviderFactory.Current.GetCurrentInstance();
            int result = provider.DoLogin(txtLoginName.Value, txtOldPass.Value.Trim());
            if (result == 0)
            {
                MessageBoxHelper.ResponseScript(this.Page, "updatePassCallback(0,'老密码输入有误');");
                return;
            }
            if (result == -1)
            {
                MessageBoxHelper.ResponseScript(this.Page, "updatePassCallback(0,'修改失败.');");
                return;
            }
            if (result == 1)
            {
                provider.UpdatePassword(txtLoginName.Value, txtNewPass.Value.Trim());
                MessageBoxHelper.ResponseScript(this.Page, "updatePassCallback(1,'修改成功');");
                return;
            }
        }
    }
}
