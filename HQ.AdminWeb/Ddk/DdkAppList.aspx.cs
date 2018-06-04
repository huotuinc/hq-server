using HQ.Core.BLL.Ddk;
using HQ.Core.BLL.PageBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.Ddk
{
    public partial class DdkAppList : AdminPageBase
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
            DataTable dt = DdkAppsBLL.Instance.GetList(pageSize, pageIndex, out recordCount);
            rptList.DataSource = dt;
            rptList.DataBind();
            pageCount = recordCount / pageSize;
            if (recordCount % pageSize != 0)
            {
                ++pageCount;
            }
        }
    }
}