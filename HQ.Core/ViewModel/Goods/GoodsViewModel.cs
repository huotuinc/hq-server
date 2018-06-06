using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.Goods
{
    /// <summary>
    /// 商品视图实体
    /// </summary>
    public class GoodsViewModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 平台类型
        /// </summary>
        public int platform { get; set; }
        /// <summary>
        /// 主图
        /// </summary>
        public string imgSrc { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public string goodsPrice { get; set; }
        /// <summary>
        /// 销量
        /// </summary>
        public int salesVolume { get; set; }
        /// <summary>
        /// 优惠券价格
        /// </summary>
        public string couponPrice { get; set; }
        /// <summary>
        /// 最终价格
        /// </summary>
        public string finalPrice { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool isFav { get; set; }
        /// <summary>
        /// 赚取佣金
        /// </summary>
        public string earnMoney { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public long goodsId { get; set; }
        /// <summary>
        /// 商品简介
        /// </summary>
        public string goodsIntro { get; set; }
        /// <summary>
        /// 图片册
        /// </summary>
        public string[] imgs { get; set; }
    }
}
