using HQ.Common;
using HQ.Core.BLL.ShortMessage;
using HQ.Core.Enum;
using HQ.Core.Model.ShortMessage;
using LM.Core.BLL.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.SystemConfig
{
    public partial class ShortMessageTemplateList : AdminPageBase
    {
        protected Dictionary<string, string> SenceMsgDataPropertys = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.CurrentId > 0 || this.Action == "add")
                {
                    pnlEdit.Visible = true;
                    pnlList.Visible = false;
                    this.LoadSceneTypes();
                    this.LoadDetail();
                    this.LoadCurrentLocalTmplTags();
                }
                else
                {
                    pnlEdit.Visible = false;
                    pnlList.Visible = true;
                    this.LoadList();
                }
            }
        }

        private void LoadList()
        {
            DataTable dt = ShortMessageTemplateBLL.Instance.GetAllList();
            rptList.DataSource = dt;
            rptList.DataBind();
        }

        private void LoadSceneTypes()
        {
            dllSceneType.Items.Clear();
            dllSceneType.Items.Add(new ListItem("==所有==", "-1"));
            foreach (var item in Enum.GetNames(typeof(HQEnums.SmsSceneOptions)))
            {
                dllSceneType.Items.Add(new ListItem(item, Enum.Format(typeof(HQEnums.SmsSceneOptions), Enum.Parse(typeof(HQEnums.SmsSceneOptions), item), "d")));
            }
        }

        /// <summary>
        /// 载入某场景下的本地对象标签列表
        /// </summary>
        private void LoadCurrentLocalTmplTags()
        {
            HQEnums.SmsSceneOptions sence = (HQEnums.SmsSceneOptions)Convert.ToInt32(dllSceneType.SelectedValue);
            Dictionary<string, string> dicPropertys = ShortMessageContext.Intance.GetMessagePropertys(sence);
            this.SenceMsgDataPropertys = dicPropertys;
        }

        private void LoadDetail()
        {
            if (this.CurrentId > 0)
            {
                ShortMessageTemplateModel model = ShortMessageTemplateBLL.Instance.GetModel(this.CurrentId);
                if (model != null)
                {
                    dllSceneType.SelectedValue = model.SceneType.ToString();
                    ddlStatus.SelectedValue = model.Status.ToString();
                    txtTemplate.Value = model.Template;
                }
                dllSceneType.Enabled = false;
            }
        }

        private void SaveInfo()
        {
            ShortMessageTemplateModel model = null;
            if (this.CurrentId > 0)
            {
                model = ShortMessageTemplateBLL.Instance.GetModel(this.CurrentId);
            }
            else
            {
                model = new ShortMessageTemplateModel();
            }
            model.SceneType = Convert.ToInt16(dllSceneType.SelectedValue);
            model.Status = Convert.ToInt16(ddlStatus.SelectedValue);
            model.Template = txtTemplate.Value;
            model.Id = this.CurrentId;

            if (this.CurrentId > 0)
            {
                ShortMessageTemplateBLL.Instance.Update(model);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            else
            {
                if (ShortMessageTemplateBLL.Instance.Exsit(model.SceneType))
                {
                    MessageBoxHelper.ResponseScript(this.Page, "showError('当前场景配置信息已经存在，不允许新增');");
                    return;
                }
                model.CreateTime = DateTime.Now;
                ShortMessageTemplateBLL.Instance.Add(model);
                MessageBoxHelper.ResponseScript(this.Page, "addSuccessCallback();");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveInfo();
        }

        public string Action
        {
            get
            {
                return this.GetQueryString("action", "list");
            }
        }

        public int CurrentId
        {
            get
            {
                return this.GetQueryString("id", 0);
            }
        }

        protected void dllSceneType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadCurrentLocalTmplTags();
        }
    }

}