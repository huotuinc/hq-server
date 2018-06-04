using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQ.Common;
using HQ.Core.MallProvider.Model;

namespace HQ.Core.MallProvider.Pinduoduo
{
    /// <summary>
    /// 拼多多商品数据提供器
    /// </summary>
    public class PttGoodsProvider : IGoodsProvider
    {
        public HotGoodsModel GetGoodsDetail(long goodsId)
        {
            throw new NotImplementedException();
        }

        public HotPageData<HotGoodsModel> GetGoodsList(HotGoodsSearchCondition condition)
        {
            throw new NotImplementedException();
        }
    }
}
