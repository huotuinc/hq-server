using HQ.Common;
using HQ.Core.MallProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.MallProvider
{
    /// <summary>
    /// 商品数据提供器
    /// </summary>
    public interface IGoodsProvider
    {
        HotGoodsModel GetGoodsDetail(long goodsId);

        HotPageData<HotGoodsModel> GetGoodsList(int page, int pageSize, HotGoodsSearchCondition condition);
    }
}
