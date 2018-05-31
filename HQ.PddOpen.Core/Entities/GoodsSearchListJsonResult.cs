using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class GoodsSearchListJsonResult : IPinduoduoJsonResult
    {
        public GoodsSearchListEntity goods_search_response { get; set; }
    }

    public class GoodsSearchListEntity
    {
        /// <summary>
        /// 多多进宝商品对象列表
        /// </summary>
        public List<GoodsDetailItemEntity> goods_list { get; set; }
        /// <summary>
        /// 回商品总数
        /// </summary>
        public int total_count { get; set; }
    }

    /// <summary>
    /// 商品搜索条件
    /// </summary>
    public class GoodsSearchConditionEntity
    {
        /// <summary>
        /// 商品关键词，与opt_id字段选填一个或全部填写
        /// </summary>
        public string keyword { get; set; }
        /// <summary>
        /// 商品标签类目ID，使用pdd.goods.opt.get获取
        /// </summary>
        public int? opt_id { get; set; }
        /// <summary>
        /// 默认值1，商品分页数
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// 默认100，每页商品数量
        /// </summary>
        public int page_size { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public GoodsSortTypeOptions sort_type { get; set; }
        /// <summary>
        /// 是否只返回优惠券的商品，false返回所有商品，true只返回有优惠券的商品
        /// </summary>
        public bool with_coupon { get; set; }
        /// <summary>
        /// 范围列表
        /// 可选值：[{"range_id":0,"range_from":1,"range_to":1500},{"range_id":1,"range_from":1,"range_to":1500}]
        /// </summary>
        public RangeListEntity range_list { get; set; }
        /// <summary>
        /// 商品类目ID，使用pdd.goods.cats.get接口获取
        /// </summary>
        public int? cat_id { get; set; }
        /// <summary>
        /// 商品ID列表。例如：[123456,123]，当入参带有goods_id_list字段，将不会以opt_id、 cat_id、keyword维度筛选商品
        /// </summary>
        public long[] goods_id_list { get; set; }
    }

    public class RangeListEntity
    {
        /// <summary>
        /// 如果左区间不限制，range_from传空就行，右区间不限制，range_to传空就行
        /// </summary>
        public int? range_to { get; set; }
        /// <summary>
        /// 如果左区间不限制，range_from传空就行，右区间不限制，range_to传空就行
        /// </summary>
        public int? range_from { get; set; }
        /// <summary>
        /// 查询维度ID，枚举值如下：0-商品拼团价格区间，1-商品券后价价格区间，2-佣金比例区间，3-优惠券金额区间，4-加入多多进宝时间区间，5-销量区间，6-佣金金额区间，7-店铺描述评分区间，8-店铺物流评分区间，9-店铺服务评分区间
        /// </summary>
        public int range_id { get; set; }
    }
}
