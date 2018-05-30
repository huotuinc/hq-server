using HQ.Common;
using HQ.Core.BLL.SystemConfig;
using HQ.Core.Model.SystemConfig;
using LM.Core.BLL.PageBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.SystemConfig
{
    public partial class ManagerEdit : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadDetail();
            }
        }

        private void LoadDetail()
        {
            if (this.CurrentId > 0)
            {
                ManagerModel model = ManagerBLL.Instance.GetModel(this.CurrentId);
                if (model != null)
                {
                    txtLoginName.Value = model.LoginName;
                    txtLoginName.Disabled = true;
                    txtIntro.Value = model.Remark;
                    ddlStatus.SelectedValue = model.IsLocked.ToString();
                    hidAuthMenus.Value = model.AuthMenus;
                }
            }
        }

        private void SaveInfo()
        {
            ManagerModel model = null;
            if (this.CurrentId > 0)
            {
                model = ManagerBLL.Instance.GetModel(this.CurrentId);
            }
            else
            {
                model = new ManagerModel();
            }
            model.Remark = txtIntro.Value.Trim();
            model.IsLocked = Convert.ToInt16(ddlStatus.SelectedValue) == 1;
            model.AuthMenus = hidAuthMenus.Value.Trim('|');
            model.IsSuper = false;
            if (txtLoginPassword.Value != "")
            {
                model.Password = EncryptHelper.MD5(txtLoginPassword.Value.Trim());
            }
            if (this.CurrentId > 0)
            {
                ManagerBLL.Instance.Update(model);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            else
            {
                model.LoginName = txtLoginName.Value;
                if (ManagerBLL.Instance.ExistsLoginName(model.LoginName))
                {
                    MessageBoxHelper.ResponseScript(this.Page, "showError('登录名已经存在');");
                    return;
                }
                model.CreateTime = DateTime.Now;
                ManagerBLL.Instance.Add(model);
                MessageBoxHelper.ResponseScript(this.Page, "addSuccessCallback();");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveInfo();
        }

        public int CurrentId
        {
            get
            {
                return this.GetQueryString("id", 0);
            }
        }
    }
}