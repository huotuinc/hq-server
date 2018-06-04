using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class IncrementOrderJsonResult : IPinduoduoJsonResult
    {
        public IncrementOrderListEntity order_list_get_response { get; set; }
    }

    public class IncrementOrderListEntity
    {
        public List<IncrementOrderItemEntity> order_list { get; set; }
        public int total_count { get; set; }
    }

    /// <summary>
    /// 多多进宝推广订单对象
    /// </summary>
    public class IncrementOrderItemEntity
    {
        /// <summary>
        /// 订单确认签收时间
        /// </summary>
        public int order_receive_time { get; set; }
        /// <summary>
        /// 自定义参数，标志订单来源于哪个自定义参数
        /// </summary>
        public string custom_parameters { get; set; }
        /// <summary>
        /// 订单来源：0—单品（领券页）推广 1—红包活动推广 2—领券页底部推荐
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public int order_verify_time { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public int order_pay_time { get; set; }

        /// <summary>
        /// 成团时间
        /// </summary>
        public int order_group_success_time { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public int order_modify_at { get; set; }

        /// <summary>
        /// 订单状态描述
        /// </summary>
        public string order_status_desc { get; set; }
        /// <summary>
        /// 推广位ID
        /// </summary>
        public string p_id { get; set; }
        /// <summary>
        /// 
        ///订单状态： -1 未支付; 0-已支付；1-已成团；2-确认收货；3-审核成功；4-审核失败（不可提现）；5-已经结算；8-非多多进宝商品（无佣金订单）;10-已处罚
        /// </summary>
        public int order_status { get; set; }
        /// <summary>
        /// 佣金金额，单位为分
        /// </summary>
        public int promotion_amount { get; set; }
        /// <summary>
        /// 佣金比例，千分比
        /// </summary>
        public int promotion_rate { get; set; }
        /// <summary>
        /// 订单生成时间，UNIX时间戳
        /// </summary>
        public int order_create_time { get; set; }
        /// <summary>
        /// 实际支付金额，单位为分
        /// </summary>
        public int order_amount { get; set; }
        /// <summary>
        /// 订单中sku的单件价格，单位为分
        /// </summary>
        public int goods_price { get; set; }
        /// <summary>
        /// 购买商品的数量
        /// </summary>
        public int goods_quantity { get; set; }
        /// <summary>
        /// 商品缩略图
        /// </summary>
        public string goods_thumbnail_url { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string goods_name { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long goods_id { get; set; }
        /// <summary>
        /// 推广订单编号
        /// </summary>
        public string order_sn { get; set; }
    }
}
