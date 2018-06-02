using HQ.Core.ViewModel.Zone;
using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.ShareZone
{
    /// <summary>
    /// 好券圈(分享中心)文章分类逻辑层
    /// </summary>
    public class ShareZoneCatBLL
    {
        private readonly ShareZoneCatDAL dal = new ShareZoneCatDAL();
        private static ShareZoneCatBLL instance = new ShareZoneCatBLL();
        private ShareZoneCatBLL()
        {

        }

        public static ShareZoneCatBLL Instance
        {
            get
            {
                return instance;
            }
        }

        public List<ZoneCategoryView> getZoneCatList()
        {
            return dal.getZoneCatList();
        }


    }
}
