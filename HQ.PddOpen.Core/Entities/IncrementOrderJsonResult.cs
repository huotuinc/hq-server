using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class IncrementOrderJsonResult : IPinduoduoJsonResult
    {
        public IncrementOrderListEntity order_list_get_response { get; set; }
    }

    public class IncrementOrderListEntity
    {
        public List<IncrementOrderItemEntity> order_list { get; set; }
    }

    /// <summary>
    /// 多多进宝推广订单对象
    /// </summary>
    public class IncrementOrderItemEntity
    {

    }
}
