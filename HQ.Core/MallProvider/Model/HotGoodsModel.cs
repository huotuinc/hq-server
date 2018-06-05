using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.MallProvider.Model
{
    /// <summary>
    /// 好券商品实体
    /// 基于拼多多商品为原型
    /// </summary>
    public class HotGoodsModel
    {
        /// <summary>
        /// 服务评分
        /// </summary>
        public int AvgService { get; set; }
        /// <summary>
        /// 物流评分
        /// </summary>
        public int AvgLogistic { get; set; }
        /// <summary>
        /// 描述评分
        /// </summary>
        public int AvgDesc { get; set; }
        /// <summary>
        /// 商品类目id，拼多多对应pdd.goods.cats.get接口
        /// </summary>
        public int CatId { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        public int CouponRemainQuantity { get; set; }
        /// <summary>
        /// 商品评价数
        /// </summary>
        public int GoodsEvalCount { get; set; }
        /// <summary>
        /// 商品标签名称，这里对应GoodsCatModel
        /// </summary>
        public string OptName { get; set; }
        /// <summary>
        /// 优惠券门槛金额
        /// </summary>
        public decimal CouponMinOrderAmount { get; set; }
        /// <summary>
        /// 优惠券面额
        /// </summary>
        public decimal CouponDiscount { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        public int CouponTotalQuantity { get; set; }
        /// <summary>
        /// 优惠券生效时间
        /// </summary>
        public DateTime CouponStartTime { get; set; }
        /// <summary>
        /// 优惠券失效时间
        /// </summary>
        public DateTime CouponEndTime { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        public int PromotionRate { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string MallName { get; set; }
        /// <summary>
        /// 商品标签ID，拼多多对应pdd.goods.opt.get接口
        /// </summary>
        public int OptId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long GoodsId { get; set; }
        /// <summary>
        /// 参与多多进宝的商品标题
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 参与多多进宝的商品描述
        /// XXXXX
        /// </summary>
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 多多进宝商品主图
        /// </summary>
        public string GoodsImageUrl { get; set; }
        /// <summary>
        /// 商品轮播图
        /// </summary>
        public List<string> GoodsGalleryUrls { get; set; }
        /// <summary>
        /// 已售卖件数
        /// </summary>
        public int SoldQuantity { get; set; }
        /// <summary>
        /// 最低价sku的拼团价
        /// </summary>
        public decimal MinGroupPrice { get; set; }
        /// <summary>
        /// 最低价sku的单买价
        /// </summary>
        public decimal MinNormalPrice { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        public string GoodsThumbnailUrl { get; set; }
        /// <summary>
        /// 券后价
        /// </summary>
        public decimal CouponedPrice { get; set; }
        /// <summary>
        /// 赚取佣金
        /// </summary>
        public decimal PromotionAmount { get; set; }
    }
}
