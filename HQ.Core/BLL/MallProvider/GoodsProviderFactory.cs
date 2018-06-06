using HQ.Core.BLL.MallProvider.Pinduoduo;
using HQ.Core.Enum;
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

        public static IGoodsProvider GetInstance(int platTypeVal)
        {
            HQEnums.PlatformTypeOptions platType = (HQEnums.PlatformTypeOptions)platTypeVal;
            return GetInstance(platType);
        }

        public static IGoodsProvider GetInstance(HQEnums.PlatformTypeOptions platType)
        {
            switch (platType)
            {
                case HQEnums.PlatformTypeOptions.拼多多:
                    return pptProvider;
            }
            return pptProvider;
        }
    }
}
