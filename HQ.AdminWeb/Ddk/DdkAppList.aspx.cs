using HQ.Core.BLL.Ddk;
using HQ.Core.BLL.PageBase;
using HQ.Core.Model.ViewModel;
using Newtonsoft.Json;
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
            if (this.GetQueryString("action", "") == "del")
            {
                AjaxResult result = this.DoDelete();
                Response.ContentType = "application/json";
                Response.Write(JsonConvert.SerializeObject(result));
                Response.End();
                return;
            }

            if (!IsPostBack)
            {
                this.LoadList();
            }
        }

        private AjaxResult DoDelete()
        {
            int id = this.GetFormValue("id", 0);
            if (DdkAppsBLL.Instance.Delete(id))
            {
                return AjaxResult.resultWith(AjaxResultEnum.请求成功);
            }
            else
            {
                return AjaxResult.resultWith(AjaxResultEnum.处理失败);
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