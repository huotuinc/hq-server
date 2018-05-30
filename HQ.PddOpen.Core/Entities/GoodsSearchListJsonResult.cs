using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsSearchListJsonResult:IPinduoduoJsonResult
    {
        public object goods_search_response { get; set; }
    }

    public class GoodsSearchListEntity
    {
        /// <summary>
        /// 多多进宝商品对象列表
        /// </summary>
        public List<GoodsSearchItemEntity> goods_list { get; set; }
        /// <summary>
        /// 回商品总数
        /// </summary>
        public int total_count { get; set; }
    }

    public class GoodsSearchItemEntity
    {
        public long avg_serv { get; set; }
        public long avg_lgst { get; set; }
        public long avg_desc { get; set; }
        public string goods_gallery_urls { get; set; }
        public string opt_name { get; set; }
        public int opt_id { get; set; }
    }
}
