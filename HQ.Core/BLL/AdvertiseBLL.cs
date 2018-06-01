using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 广告位逻辑层
    /// </summary>
    public class AdvertiseBLL
    {
        private readonly AdvertiseDAL dal = new AdvertiseDAL();
        private static AdvertiseBLL instance = new AdvertiseBLL();
        private AdvertiseBLL()
        { }

        public static AdvertiseBLL Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
