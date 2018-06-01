using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.ShareZone
{
    /// <summary>
    /// 好券圈(分享中心)文章逻辑层
    /// </summary>
    public class ShareZoneArticleBLL
    {
        private readonly ShareZoneArticleDAL dal = new ShareZoneArticleDAL();
        private static ShareZoneArticleBLL instance = new ShareZoneArticleBLL();
        private ShareZoneArticleBLL()
        { }

        public static ShareZoneArticleBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
