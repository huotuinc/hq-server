using HQ.Common;
using HQ.Core.BLL.Ddk;
using HQ.Core.BLL.PageBase;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.Ddk
{
    public partial class DdkAppEdit : AdminPageBase
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
                DdkAppsModel model = DdkAppsBLL.Instance.GetModel(this.CurrentId);
                if (model != null)
                {
                    txtClientId.Value = model.ClientId;
                    txtClientSecret.Value = model.ClientSecret;
                    hidBindAgentId.Value = model.BindAgentId.HasValue ? model.BindAgentId.ToString() : "0";
                    ddlStatus.SelectedValue = model.Status.ToString();
                    ddlIsMain.SelectedValue = model.IsMain.ToString();
                }
            }
        }

        private void SaveInfo()
        {
            DdkAppsModel model = null;
            if (this.CurrentId > 0)
            {
                model = DdkAppsBLL.Instance.GetModel(this.CurrentId);
            }
            else
            {
                model = new DdkAppsModel();
            }

            model.ClientId = txtClientId.Value.Trim();
            model.ClientSecret = txtClientSecret.Value.Trim();
            model.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            model.IsMain = Convert.ToInt32(ddlIsMain.SelectedValue);
            model.BindAgentId = Convert.ToInt32(hidBindAgentId.Value);

            if (this.CurrentId > 0)
            {
                DdkAppsBLL.Instance.Update(model);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            else
            {
     
                DdkAppsBLL.Instance.Add(model);
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