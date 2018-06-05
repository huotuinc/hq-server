using HQ.Common;
using HQ.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.MallProvider
{
    /// <summary>
    /// 统一商品数据提供器
    /// </summary>
    public interface IGoodsProvider
    {
        /// <summary>
        /// 获取商品详情
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        HotGoodsModel GetGoodsDetail(long goodsId, out string errMsg);

        /// <summary>
        /// 分页获取商品列表
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        HotPageData<List<HotGoodsModel>> GetGoodsList(HotGoodsSearchCondition condition, out string errMsg);
    }
}
