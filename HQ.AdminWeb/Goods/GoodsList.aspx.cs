using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.BLL.MallProvider;
using HQ.Core.BLL.PageBase;
using HQ.Core.Enum;
using HQ.Core.Model;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HQ.AdminWeb.Goods
{
    public partial class GoodsList : AdminPageBase
    {
        protected string SubCatJson = "[]";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.LoadRootCats();
                this.LoadSortFileds();
                this.LoadList();
            }
        }

        private void LoadRootCats()
        {
            List<GoodsCatsModel> catList = GoodsCatsBLL.Instance.GetSortedList(this.CurrentPlatType);
            mainCatId.Items.Clear();
            mainCatId.Items.Add(new ListItem("==所有==", "-1"));
            foreach (GoodsCatsModel catInfo in catList)
            {
                if (catInfo.ParentId == 0)
                    mainCatId.Items.Add(new ListItem(catInfo.Name, catInfo.Id.ToString()));
            }
            this.SubCatJson = GetJson(catList);
        }

        private void LoadSortFileds()
        {
            sortField.Items.Clear();
            foreach (var item in Enum.GetNames(typeof(HotGoodsSortFieldOptions)))
            {
                sortField.Items.Add(new ListItem(item, Enum.Format(typeof(HotGoodsSortFieldOptions), Enum.Parse(typeof(HotGoodsSortFieldOptions), item), "d")));
            }
        }

        private void LoadList()
        {
            HotGoodsSearchCondition condition = this.GetSearchCondition();
            this.BindSearchCondition(condition);
            HotPageData<List<HotGoodsModel>> pageData = GoodsProviderFactory.Current.GetGoodsList(condition, out string errMsg);
            if (errMsg != "")
            {
                Response.Write(errMsg);
                Response.End();
                return;
            }
            recordCount = pageData.Total;
            rptList.DataSource = pageData.Rows;
            rptList.DataBind();
            pageCount = pageData.PageCount;
        }

        private HotGoodsSearchCondition GetSearchCondition()
        {
            int _mainCatId = this.GetQueryString("mainCatId", 0);
            int _subCatId = this.GetQueryString("subCatId", 0);
            int catId = _subCatId > 0 ? _subCatId : _mainCatId;
            
            HotGoodsSearchCondition condition = new HotGoodsSearchCondition()
            {
                SortField = (HotGoodsSortFieldOptions)this.GetQueryString("sortField", 0),
                SortType = (HotGoodsSortTypeOptions)this.GetQueryString("SortType", 0),
                WithCoupon = true,
                Page = pageIndex,
                PageSize = 60,
                CatId = catId,
                Keyword = Server.UrlDecode(this.GetQueryString("keyword", "")),
                GoodsIdList = null
            };
            return condition;
        }

        private void BindSearchCondition(HotGoodsSearchCondition condition)
        {
            mainCatId.Value = this.GetQueryString("mainCatId", "0");
            subCatId.Value = this.GetQueryString("subCatId", "0");
            keyword.Value = condition.Keyword;
            sortField.Value = ((int)condition.SortField).ToString();
            sortType.Value = ((int)condition.SortType).ToString();
        }

        public int CurrentPlatType
        {
            get
            {
                return (int)HQEnums.PlatformTypeOptions.拼多多;
            }
        }
    }
}