using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQ.Common;
using HQ.Common.PageData;
using HQ.Core.BLL.Ddk;
using HQ.Core.Model;
using HQ.Model;
using HQ.PddOpen.Core;
using HQ.PddOpen.Core.Entities;

namespace HQ.Core.BLL.MallProvider.Pinduoduo
{
    /// <summary>
    /// 拼多多商品数据提供器
    /// </summary>
    public class PttGoodsProvider : IGoodsProvider
    {
        public HotGoodsModel GetGoodsDetail(long goodsId, out string errMsg)
        {
            errMsg = "";
            try
            {
                DdkAppsModel appInfo = DdkAppProvider.Instance.GetModelByDefault();
                GoodsDetailJsonResult goodsDetailJsonResult = DdkApi.GetGoodsDetail(appInfo.ClientId, appInfo.ClientSecret, goodsId);
                List<GoodsDetailItemEntity> goodsList = goodsDetailJsonResult.goods_detail_response.goods_details;
                if (goodsList.Count > 0)
                {
                    return this.ConvertGoods(goodsList[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        public HotPageData<List<HotGoodsModel>> GetGoodsList(HotGoodsSearchCondition condition, out string errMsg)
        {
            errMsg = "";
            try
            {
                //排序转换
                GoodsSortTypeOptions goodsSortType = GoodsSortTypeOptions.综合排序;
                switch (condition.SortField)
                {
                    case HotGoodsSortFieldOptions.默认:
                        goodsSortType = GoodsSortTypeOptions.综合排序;
                        break;
                    case HotGoodsSortFieldOptions.价格:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.按价格升序 : GoodsSortTypeOptions.按价格降序;
                        break;
                    case HotGoodsSortFieldOptions.优惠券金额:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.优惠券金额排序升序 : GoodsSortTypeOptions.优惠券金额排序降序;
                        break;
                    case HotGoodsSortFieldOptions.佣金比例:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.按佣金比率升序 : GoodsSortTypeOptions.按佣金比例降序;
                        break;
                    case HotGoodsSortFieldOptions.佣金金额:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.按佣金金额升序排序 : GoodsSortTypeOptions.按佣金金额降序排序;
                        break;
                    case HotGoodsSortFieldOptions.券后价:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.券后价升序排序 : GoodsSortTypeOptions.券后价降序排序;
                        break;
                    case HotGoodsSortFieldOptions.加入时间:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.按照加入多多进宝时间升序 : GoodsSortTypeOptions.按照加入多多进宝时间降序;
                        break;
                    case HotGoodsSortFieldOptions.销量:
                        goodsSortType = condition.SortType == HotGoodsSortTypeOptions.ASC ? GoodsSortTypeOptions.按销量升序 : GoodsSortTypeOptions.按销量降序;
                        break;
                }

                //接口数据拉取
                DdkAppsModel appInfo = DdkAppProvider.Instance.GetModelByDefault();
                GoodsSearchListJsonResult goodsSearchListJsonResult = DdkApi.GetGoodsList(appInfo.ClientId, appInfo.ClientSecret, new GoodsSearchConditionEntity()
                {
                    cat_id = null,
                    goods_id_list = condition.GoodsIdList,
                    keyword = condition.Keyword,
                    opt_id = condition.CatId,
                    page = condition.Page,
                    page_size = condition.PageSize,
                    range_list = null,
                    with_coupon = condition.WithCoupon,
                    sort_type = goodsSortType
                });

                //数据加工
                GoodsSearchListEntity searchListEntity = goodsSearchListJsonResult.goods_search_response;
                HotPageData<List<HotGoodsModel>> pageData = HotPageDataHelper<List<HotGoodsModel>, List<GoodsDetailItemEntity>>.Convert(
                    searchListEntity.goods_list,
                    searchListEntity.total_count,
                    condition.PageSize,
                    condition.Page,
                    dt =>
                    {
                        List<HotGoodsModel> list = new List<HotGoodsModel>();
                        foreach (GoodsDetailItemEntity item in dt)
                        {
                            list.Add(this.ConvertGoods(item));
                        }
                        return list;
                    });
                return pageData;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return null;
            }
        }

        private HotGoodsModel ConvertGoods(GoodsDetailItemEntity ddkGoods)
        {
            HotGoodsModel model = new HotGoodsModel();
            model.AvgDesc = ddkGoods.avg_desc;
            model.AvgLogistic = ddkGoods.avg_lgst;
            model.AvgService = ddkGoods.avg_serv;
            model.CatId = ddkGoods.cat_id.HasValue ? ddkGoods.cat_id.Value : 0;
            model.CouponDiscount = Math.Round(Convert.ToDecimal(ddkGoods.coupon_discount) / 100, 2);
            model.CouponEndTime = ConvertHepler.UnixTimeToTime(ddkGoods.coupon_end_time.ToString());
            model.CouponMinOrderAmount = Math.Round(Convert.ToDecimal(ddkGoods.coupon_min_order_amount) / 100, 2);
            model.CouponRemainQuantity = ddkGoods.coupon_remain_quantity;
            model.CouponStartTime = ConvertHepler.UnixTimeToTime(ddkGoods.coupon_start_time.ToString());
            model.CouponTotalQuantity = ddkGoods.coupon_total_quantity;
            model.GoodsDesc = ddkGoods.goods_desc;
            model.GoodsEvalCount = ddkGoods.goods_eval_count;
            model.GoodsGalleryUrls = ddkGoods.goods_gallery_urls;
            model.GoodsId = ddkGoods.goods_id;
            model.GoodsImageUrl = ddkGoods.goods_image_url;
            model.GoodsName = ddkGoods.goods_name;
            model.MinGroupPrice = Math.Round(Convert.ToDecimal(ddkGoods.min_group_price) / 100, 2);
            model.MinNormalPrice = Math.Round(Convert.ToDecimal(ddkGoods.min_normal_price) / 100, 2);
            model.OptId = ddkGoods.opt_id.HasValue ? ddkGoods.opt_id.Value : 0;
            model.OptName = ddkGoods.opt_name;
            model.PromotionRate = ddkGoods.promotion_rate;
            model.SoldQuantity = ddkGoods.sold_quantity;
            model.GoodsThumbnailUrl = ddkGoods.goods_thumbnail_url;

            model.CouponedPrice = model.MinGroupPrice - model.CouponDiscount;
            model.PromotionAmount = Math.Round(model.CouponedPrice * model.PromotionRate / 100, 2);
            return model;
        }
    }
}
