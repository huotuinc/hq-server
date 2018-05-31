using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsDetailJsonResult : IPinduoduoJsonResult
    {
        public GoodsDetailListEntity goods_detail_response { get; set; }
    }

    public class GoodsDetailListEntity
    {
        public List<GoodsDetailItemEntity> goods_details { get; set; }
    }
    /// <summary>
    /// 多多进宝商品对象
    /// </summary>
    public class GoodsDetailItemEntity
    {
        /// <summary>
        /// 服务评分
        /// </summary>
        public int avg_serv { get; set; }
        /// <summary>
        /// 流评分
        /// </summary>
        public int avg_lgst { get; set; }
        /// <summary>
        /// 描述评分
        /// </summary>
        public int avg_desc { get; set; }
        /// <summary>
        /// 商品一~四级类目ID列表
        /// </summary>
        public List<int> cat_ids { get; set; }
        /// <summary>
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public int? cat_id { get; set; }
        /// <summary>
        /// 优惠券剩余数量
        /// </summary>
        public int coupon_remain_quantity { get; set; }
        /// <summary>
        /// 商品评价数
        /// </summary>
        public int goods_eval_count { get; set; }
        /// <summary>
        /// 商品评价分
        /// </summary>
        public double goods_eval_score { get; set; }
        /// <summary>
        /// 商品标签名称
        /// </summary>
        public string opt_name { get; set; }
        /// <summary>
        /// 优惠券门槛金额，单位为分
        /// </summary>
        public int coupon_min_order_amount { get; set; }
        /// <summary>
        /// 优惠券面额，单位为分
        /// </summary>
        public int coupon_discount { get; set; }
        /// <summary>
        /// 优惠券总数量
        /// </summary>
        public int coupon_total_quantity { get; set; }
        /// <summary>
        /// 优惠券生效时间，UNIX时间戳
        /// </summary>
        public int coupon_start_time { get; set; }
        /// <summary>
        /// 优惠券失效时间，UNIX时间戳
        /// </summary>
        public int coupon_end_time { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        public int promotion_rate { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string mall_name { get; set; }
        /// <summary>
        /// 商品标签ID，使用pdd.goods.opt.get接口获取
        /// </summary>
        public int opt_id { get; set; }
        /// <summary>
        /// 参与多多进宝的商品ID
        /// </summary>
        public long goods_id { get; set; }
        /// <summary>
        /// 参与多多进宝的商品标题
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 参与多多进宝的商品描述
        /// XXXXX
        /// </summary>
        public string goods_desc { get; set; }
        /// <summary>
        /// 多多进宝商品主图
        /// </summary>
        public string goods_image_url { get; set; }
        /// <summary>
        /// 商品轮播图
        /// </summary>
        public List<string> goods_gallery_urls { get; set; }
        /// <summary>
        /// 已售卖件数
        /// </summary>
        public int sold_quantity { get; set; }
        /// <summary>
        /// 最低价sku的拼团价，单位为分
        /// </summary>
        public int min_group_price { get; set; }
        /// <summary>
        /// 最低价sku的单买价，单位为分
        /// </summary>
        public int min_normal_price { get; set; }
    }
}
