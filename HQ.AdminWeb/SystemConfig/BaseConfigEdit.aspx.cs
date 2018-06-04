using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.BLL.PageBase;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.SystemConfig
{
    public partial class BaseConfigEdit : AdminPageBase
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
            BaseConfigModel cfgModel = BaseConfigBLL.Instance.GetTopModel();
            if (cfgModel == null) return;
            SmsSettingInfo smsSetting = cfgModel.SmsSetting;
            if (cfgModel.SmsSetting != null)
            {
                txtSmsAccount.Value = cfgModel.SmsSetting.SerialNo;
                txtSmsPassword.Value = cfgModel.SmsSetting.Password;
                foreach (ListItem li in ddlSmsProvider.Items)
                {
                    if (li.Value.StartsWith(cfgModel.SmsSetting.Provider + "|"))
                    {
                        li.Selected = true;
                        break;
                    }
                }
            }
            txtWxAppId.Value = cfgModel.WxAppId;
            txtWxAppSecret.Value = cfgModel.WxAppSecret;
            txtMainDomain.Value = cfgModel.MainDomain;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BaseConfigModel cfgModel = BaseConfigBLL.Instance.GetTopModel();
            if (cfgModel == null) cfgModel = new BaseConfigModel();
            cfgModel.MainDomain = txtMainDomain.Value.Trim();
            string[] arrSmsProvider = ddlSmsProvider.SelectedValue.Split('|');
            cfgModel.SmsSetting = new SmsSettingInfo()
            {
                Provider = arrSmsProvider[0],
                ServiceUrl = arrSmsProvider[1],
                SerialNo = txtSmsAccount.Value.Trim(),
                Password = txtSmsPassword.Value.Trim()
            };
            cfgModel.WxAppId = txtWxAppId.Value.Trim();
            cfgModel.WxAppSecret = txtWxAppSecret.Value.Trim();

            if (cfgModel.ConfigId > 0)
            {
                BaseConfigBLL.Instance.Update(cfgModel);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            else
            {
                BaseConfigBLL.Instance.Add(cfgModel);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            BaseConfigBLL.Instance.RefreshCache();
        }
    }
}