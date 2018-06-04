using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.BLL.ShareZone;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HQ.ApiWeb.Controllers
{
    [HQApiAuthorize(false)]
    /// <summary>
    /// 好卷圈
    /// </summary>
    public class ZoneController : HQControllerBase
    {


        /// <summary>
        /// 分类
        /// </summary>
        /// <returns></returns>
        public ActionResult category()
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, ShareZoneCatBLL.Instance.getZoneCatList()));
        }

        /// <summary>
        /// 文章列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult zoneList(int categoryId, int pageIndex, int pageSize, HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, ShareZoneArticleBLL.Instance.listByCategoryId(header.platType, categoryId, pageIndex, pageSize)));
        }
    }
}