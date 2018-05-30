using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class PromotionIdJsonResult : IPinduoduoJsonResult
    {
        public PromotionIdListEntity p_id_query_response { get; set; }
    }

    public class PromotionIdListEntity
    {
        /// <summary>
        /// 返回推广位总数
        /// </summary>
        public int total_count { get; set; }

        /// <summary>
        /// 多多进宝推广位对象列表
        /// </summary>
        public List<PromotionIdItemEntity> p_id_list { get; set; }
    }

    /// <summary>
    /// 推广位对象
    /// </summary>
    public class PromotionIdItemEntity
    {
        /// <summary>
        /// 推广位生成时间
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// 推广位ID
        /// </summary>
        public string p_id { get; set; }
    }
}
