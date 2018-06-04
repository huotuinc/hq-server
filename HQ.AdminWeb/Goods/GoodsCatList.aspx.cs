using HQ.Core.BLL;
using HQ.Core.BLL.PageBase;
using HQ.Core.Enum;
using HQ.Core.Model;
using HQ.Core.Model.ViewModel;
using HQ.Model;
using LM.Core.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.Goods
{
    public partial class GoodsCatList : AdminPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AllCates = new List<GoodsCatsModel>();
            if (this.GetQueryString("action", "") == "export")
            {
                this.Export();
                return;
            }

            if (this.GetQueryString("action", "") == "swap")
            {
                AjaxResult result = this.Swap();
                Response.ContentType = "application/json";
                Response.Write(JsonConvert.SerializeObject(result));
                Response.End();
                return;
            }

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

        private void Export()
        {
            GoodsCatsSearchCondition condition = HQSearchContext<GoodsCatsSearchCondition>.GetCondtion();
            if (condition == null)
            {
                this.SetJsSegmentOut("showError('查询条件丢失');");
                return;
            }
            List<GoodsCatsModel> data = GoodsCatsBLL.Instance.GetSortedList(condition.PlatType);
            DataTable dt = this.Convert(data);
            if (dt.Rows.Count == 0)
            {
                this.SetJsSegmentOut("showError('没有找到一行数据');");
                return;
            }
            //导出字段准备
            List<ExportFieldApplyModel> lstMappings = new List<ExportFieldApplyModel>();
            lstMappings.Add(ExportFieldApplyModel.Build("Id", "id"));
            lstMappings.Add(ExportFieldApplyModel.Build("Name", "分类名"));
            lstMappings.Add(ExportFieldApplyModel.Build("LevelNo", "层级"));
            lstMappings.Add(ExportFieldApplyModel.Build("SortNum", "排序号"));
            lstMappings.Add(ExportFieldApplyModel.Build("Status", "状态"));
            lstMappings.Add(ExportFieldApplyModel.Build("Icon", "图片"));
            //内存中，直接下载
            string fileName = string.Format("goodscat-{0}({1}).xls", DateTime.Now.ToString("yyyyMMddHHmmss"), dt.Rows.Count);
            using (MemoryStream ms = HQExcelExporter.ExportToMemoryStream(dt, lstMappings, out string errmsg))
            {
                Response.ClearContent();
                Response.ContentType = "application/ms-excel";
                Response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.BinaryWrite(ms.ToArray());
            }
        }

        private AjaxResult Swap()
        {
            int catid = this.GetFormValue("catid", 0);
            int type = this.GetFormValue("type", 1);
            int platType = this.GetFormValue("plattype", 0);
            if (GoodsCatsBLL.Instance.SwapPosition(catid, platType, type, out string errMsg))
            {
                return AjaxResult.resultWith(AjaxResultEnum.请求成功);
            }
            return AjaxResult.resultWith(AjaxResultEnum.处理失败, errMsg, null);
        }

        private AjaxResult DoDelete()
        {
            int id = this.GetFormValue("id", 0);
            int platType = this.GetFormValue("plattype", 0);
            if (GoodsCatsBLL.Instance.Delete(id, platType))
            {
                return AjaxResult.resultWith(AjaxResultEnum.请求成功);
            }
            return AjaxResult.resultWith(AjaxResultEnum.处理失败);
        }

        public DataTable Convert(List<GoodsCatsModel> catList)
        {
            DataTable dt = GoodsCatsBLL.Instance.GetListScheme();
            foreach (GoodsCatsModel catInfo in catList)
            {
                DataRow dr = dt.NewRow();
                dr["Id"] = catInfo.Id;
                dr["Icon"] = catInfo.Icon;
                dr["LevelNo"] = catInfo.LevelNo;
                dr["Name"] = catInfo.LevelNo > 1 ? "└  " + catInfo.Name : catInfo.Name;
                dr["ParentId"] = catInfo.ParentId;
                dr["PlatType"] = catInfo.PlatType;
                dr["SortNum"] = catInfo.SortNum;
                dr["Status"] = catInfo.Status;
                dt.Rows.Add(dr);
            }
            dt.AcceptChanges();
            return dt;
        }

        private void LoadList()
        {
            GoodsCatsSearchCondition condition = this.GetSearchCondition();
            this.BindSearchCondition(condition);
            this.AllCates = GoodsCatsBLL.Instance.GetSortedList(condition.PlatType);
            HQSearchContext<GoodsCatsSearchCondition>.SetCondtion(condition);
        }

        private GoodsCatsSearchCondition GetSearchCondition()
        {
            GoodsCatsSearchCondition condition = new GoodsCatsSearchCondition
            {
                PlatType = this.GetQueryString("plattype", (int)HQEnums.PlatformTypeOptions.拼多多)
            };
            return condition;
        }

        private void BindSearchCondition(GoodsCatsSearchCondition condition)
        {
            plattype.Value = condition.PlatType.ToString();
        }

        public List<GoodsCatsModel> AllCates { get; set; }
    }
}