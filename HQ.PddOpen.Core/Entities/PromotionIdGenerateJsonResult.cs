using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class PromotionIdGenerateJsonResult : IPinduoduoJsonResult
    {
        public PromotionIdGenerateListEntity p_id_generate_response { get; set; }
    }

    public class PromotionIdGenerateListEntity
    {
        public List<PromotionIdGenerateItemEntity> p_id_list { get; set; }
    }

    /// <summary>
    /// 推广位对象
    /// </summary>
    public class PromotionIdGenerateItemEntity
    {
        /// <summary>
        /// 推广位ID
        /// </summary>
        public string p_id { get; set; }
        /// <summary>
        /// 推广位名称
        /// </summary>
        public string p_id_name { get; set; }
    }
}
