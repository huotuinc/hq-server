using HQ.Core.BLL.SystemConfig;
using HQ.Core.BLL.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HQ.Core.Model.SystemConfig;

namespace HQ.AdminWeb.SystemConfig
{
    public partial class ManagerList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadList();
            }
        }

        private void LoadList()
        {
            ManagerSearchCondition condition = this.GetSearchCondition();
            this.BindSearchCondition(condition);
            DataTable dt = ManagerBLL.Instance.GetList(pageSize, pageIndex, out recordCount, condition);
            rptList.DataSource = dt;
            rptList.DataBind();
            pageCount = recordCount / pageSize;
            if (recordCount % pageSize != 0)
            {
                ++pageCount;
            }
        }

        private ManagerSearchCondition GetSearchCondition()
        {
            ManagerSearchCondition condition = new ManagerSearchCondition();
            condition.LoginName = Server.UrlDecode(this.GetQueryString("loginname", ""));
            condition.FilterSuper = true;
            return condition;
        }

        private void BindSearchCondition(ManagerSearchCondition condition)
        {
            loginname.Value = condition.LoginName;
        }
    }
}