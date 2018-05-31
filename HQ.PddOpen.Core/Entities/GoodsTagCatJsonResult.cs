using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsTagCatJsonResult : IPinduoduoJsonResult
    {
        public List<GoodsTagCateEntity> goods_opt_get_response { get; set; }
    }

    /// <summary>
    /// 商品标签对象
    /// </summary>
    public class GoodsTagCateEntity
    {
        /// <summary>
        /// 层级，1-一级，2-二级，3-三级，4-四级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// id所属父ID，其中，parent_id=0时为顶级节点
        /// </summary>
        public int parent_opt_id { get; set; }
        /// <summary>
        /// 商品标签名
        /// </summary>
        public string opt_name { get; set; }
        /// <summary>
        /// 商品标签ID
        /// </summary>
        public int opt_id { get; set; }
    }
}
