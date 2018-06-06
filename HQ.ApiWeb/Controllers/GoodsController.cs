using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.BLL.MallProvider;
using HQ.Core.Enum;
using HQ.Core.Model;
using HQ.Core.Model.ViewModel;
using HQ.Core.ViewModel.Goods;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HQ.ApiWeb.Controllers
{
    [HQApiAuthorize(false)]
    public class GoodsController : HQControllerBase
    {
        /// <summary>
        /// 首页推荐
        /// </summary>
        /// <returns></returns>
        public ActionResult recommend(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, AdvertiseBLL.Instance.listForIndex(header.platType)));
        }

        public JsonResult Search(HQRequestHeader header, string keyword, int page = 1, int pageSize = 10)
        {
            return null;
        }

        public JsonResult List(HQRequestHeader header, int categoryId, int filterType, string keyword, string sortType = "desc", int page = 1, int pageSize = 10)
        {
            return null;
        }

        public JsonResult Detail(HQRequestHeader header, long goodsId)
        {
            return null;
        }

        public JsonResult Category()
        {
            return null;
        }

        private HotPageData<List<GoodsViewModel>> GetGoodsList(HQRequestHeader header, HotGoodsSearchCondition condition)
        {
            HotPageData<List<HotGoodsModel>> pageData = GoodsProviderFactory.GetInstance(header.platType).GetGoodsList(condition, out string errMsg);
            HotPageData<List<GoodsViewModel>> pageViewData = new HotPageData<List<GoodsViewModel>>();
            pageViewData.PageCount = pageData.PageCount;
            pageViewData.PageIndex = pageData.PageIndex;
            pageViewData.PageSize = pageData.PageSize;
            pageViewData.Total = pageData.Total;
            List<GoodsViewModel> viewList = new List<GoodsViewModel>();
            foreach (HotGoodsModel goodsInfo in pageData.Rows)
            {
                GoodsViewModel viewInfo = new GoodsViewModel();
                viewInfo.couponPrice = goodsInfo.CouponDiscount.ToString("F2");
                viewInfo.earnMoney = goodsInfo.PromotionAmount.ToString("F2");//????要乘一个百分比
                viewInfo.finalPrice = goodsInfo.CouponedPrice.ToString("F2");
                viewInfo.goodsId = goodsInfo.GoodsId;
                viewInfo.goodsIntro = goodsInfo.GoodsDesc;
                viewInfo.goodsPrice = goodsInfo.MinGroupPrice.ToString("F2");
                viewInfo.imgs = goodsInfo.GoodsGalleryUrls.ToArray();
                viewInfo.imgSrc = goodsInfo.GoodsThumbnailUrl;
                viewInfo.isFav = false;//???赋值
                viewInfo.platform = header.platType;
                viewInfo.salesVolume = goodsInfo.SoldQuantity;
                viewInfo.title = goodsInfo.GoodsName;
                viewList.Add(viewInfo);
            }
            pageViewData.Rows = viewList;
            return pageViewData;
        }
    }
}