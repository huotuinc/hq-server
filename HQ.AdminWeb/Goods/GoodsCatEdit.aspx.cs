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

namespace HQ.AdminWeb.Goods
{
    public partial class GoodsCatEdit : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadCatList();
                this.LoadDetail();
            }
        }

        private void LoadCatList()
        {
            dllParentId.Items.Clear();
            dllParentId.Items.Add(new ListItem("顶级分类", "0"));
            List<GoodsCatsModel> catList = GoodsCatsBLL.Instance.GetSortedList(this.PlatType);
            foreach (GoodsCatsModel catInfo in catList)
            {
                if (catInfo.ParentId == 0)
                {
                    dllParentId.Items.Add(new ListItem("└ " + catInfo.Name, catInfo.Id.ToString()));
                }
            }
        }

        private void LoadDetail()
        {
            if (this.CurrentId > 0)
            {
                GoodsCatsModel model = GoodsCatsBLL.Instance.GetModel(this.CurrentId, this.PlatType);
                if (model != null)
                {
                    txtCatId.Disabled = true;
                    dllParentId.Enabled = false;
                    txtCatId.Value = model.Id.ToString();
                    dllParentId.SelectedValue = model.ParentId.ToString();
                    txtCatName.Value = model.Name;
                    hidCatIcon.Value = model.Icon;
                    ddlStatus.SelectedValue = model.Status.ToString();
                }
            }
        }

        private void SaveInfo()
        {
            GoodsCatsModel model = null;
            if (this.CurrentId > 0)
            {
                model = GoodsCatsBLL.Instance.GetModel(this.CurrentId, this.PlatType);
            }
            else
            {
                model = new GoodsCatsModel();
            }
            model.Id = Convert.ToInt32(txtCatId.Value);
            model.Icon = hidCatIcon.Value.Trim();
            model.Name = txtCatName.Value.Trim();
            model.ParentId = Convert.ToInt32(dllParentId.SelectedValue);
            model.Status = Convert.ToInt16(ddlStatus.SelectedValue);
            model.PlatType = this.PlatType;
            model.LevelNo = model.ParentId == 0 ? 1 : 2;

            if (this.CurrentId > 0)
            {
                GoodsCatsBLL.Instance.Update(model);
                MessageBoxHelper.ResponseScript(this.Page, "updateSuccessCallback();");
            }
            else
            {
                if (GoodsCatsBLL.Instance.GetModel(model.Id, this.PlatType) != null)
                {
                    MessageBoxHelper.ResponseScript(this.Page, "showError('已经存在相应id的分类');");
                    return;
                }
                model.SortNum = model.Id;
                GoodsCatsBLL.Instance.Add(model);
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

        public int PlatType
        {
            get
            {
                return this.GetQueryString("plattype", 0);
            }
        }
    }
}