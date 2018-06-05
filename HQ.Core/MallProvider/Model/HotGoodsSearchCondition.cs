using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.MallProvider.Model
{
    /// <summary>
    /// 商品搜索条件
    /// </summary>
    public class HotGoodsSearchCondition
    {
        public HotGoodsSearchCondition()
        {
            this.Page = 1;
            this.PageSize = 20;
        }
        /// <summary>
        /// 商品关键词
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public HotGoodsSortFieldOptions SortField { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public HotGoodsSortTypeOptions SortType { get; set; }
        /// <summary>
        /// 页码数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        ///  默认值1，商品分页数
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 是否只返回优惠券的商品，false返回所有商品，true只返回有优惠券的商品
        /// </summary>
        public bool WithCoupon { get; set; }
        /// <summary>
        /// 商品分类ID，注：拼多多商品分类我们使用的是标签分类，对应optid
        /// </summary>
        public int CatId { get; set; }
        /// <summary>
        ///  商品ID列表。例如：[123456,123]，当入参带有goods_id_list字段，将不会以opt_id、 cat_id、keyword维度筛选商品
        /// </summary>
        public long[] GoodsIdList { get; set; }
    }

    public enum HotGoodsSortFieldOptions
    {
        默认 = 0,
        佣金比例 = 1,
        价格 = 2,
        销量 = 3,
        优惠券金额 = 4,
        券后价 = 5,
        佣金金额 = 6,
        加入时间 = 7
    }

    public enum HotGoodsSortTypeOptions
    {
        ASC = 0,
        DESC = 1
    }
}
