using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsPromotionUrlJsonResult : IPinduoduoJsonResult
    {
        public GoodsPromotionUrlListEntity goods_promotion_url_generate_response { get; set; }
    }

    public class GoodsPromotionUrlListEntity
    {
        public List<GoodsPromotionUrlEntity> goods_promotion_url_list { get; set; }
    }

    /// <summary>
    /// 多多进宝推广链接对象
    /// </summary>
    public class GoodsPromotionUrlEntity
    {
        /// <summary>
        /// 唤醒拼多多app的推广短链接
        /// </summary>
        public string mobile_short_url { get; set; }
        /// <summary>
        /// 唤醒拼多多app的推广长链接
        /// </summary>
        public string mobile_url { get; set; }
        /// <summary>
        /// 推广短链接
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 推广长链接
        /// </summary>
        public string short_url { get; set; }
    }
}
