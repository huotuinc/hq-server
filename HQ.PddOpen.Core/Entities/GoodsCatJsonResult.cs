using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsCatJsonResult : IPinduoduoJsonResult
    {
        public GoodsCateListEntity goods_cats_get_response { get; set; }
    }

    public class GoodsCateListEntity
    {
        public List<GoodsCateEntity> goods_cats_list { get; set; }
    }

    /// <summary>
    /// 商品标签对象
    /// </summary>
    public class GoodsCateEntity
    {
        /// <summary>
        /// 层级，1-一级，2-二级，3-三级，4-四级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// id所属父类目ID，其中，parent_id=0时为顶级节点
        /// </summary>
        public int parent_cat_id { get; set; }
        /// <summary>
        /// 商品类目名称
        /// </summary>
        public string cat_name { get; set; }
        /// <summary>
        /// 商品类目ID
        /// </summary>
        public int cat_id { get; set; }
    }
}
