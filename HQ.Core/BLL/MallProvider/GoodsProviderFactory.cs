using HQ.Core.BLL.MallProvider.Pinduoduo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.MallProvider
{
    /// <summary>
    /// 商品数据提供器工厂
    /// </summary>
    public class GoodsProviderFactory
    {
        private static readonly IGoodsProvider pptProvider = new PttGoodsProvider();
        private GoodsProviderFactory()
        {
        }

        public static IGoodsProvider Current
        {
            get
            {
                return pptProvider;
            }
        }
    }
}
