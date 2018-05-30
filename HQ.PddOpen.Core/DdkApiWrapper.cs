using HQ.Common;
using HQ.Common.PageData;
using HQ.PddOpen.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core
{
    /// <summary>
    /// 拼多多接口包装器
    /// 拼多多返回的JSON层次较深，本类在接口调用基础上再做包装，为了更好的调用体验
    /// </summary>
    public static class DdkApiWrapper
    {
        /// <summary>
        /// 查询已经生成的推广位信息
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static HotPageData<List<PromotionIdItemEntity>> GetPromotionIdList(string clientId, string clientSecret, int page, int pageSize)
        {
            PromotionIdJsonResult result = DdkApi.GetPromotionIdList(clientId, clientSecret, page, pageSize);
            return HotPageDataHelper<List<PromotionIdItemEntity>>.Convert(result.p_id_query_response.p_id_list, result.p_id_query_response.total_count, pageSize, page);
        }
    }
}
