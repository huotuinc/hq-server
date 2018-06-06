using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.Order
{
    [Serializable]
    public class OrderViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string imgSrc { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string goodsName { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal orderAmount { get; set; }
        /// <summary>
        /// 佣金额度
        /// </summary>
        public decimal promotionAmount { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int orderStatus { get; set; }
        /// <summary>
        /// 成团时间
        /// </summary>
        public string orderGroupCuccessTime { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string orderCreateTime { get; set; }

    }
}
