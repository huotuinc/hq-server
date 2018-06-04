using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.BLL;
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
    public class GoodsControllerr : HQControllerBase
    {
        /// <summary>
        /// 首页推荐
        /// </summary>
        /// <returns></returns>
        public ActionResult recommend(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, AdvertiseBLL.Instance.listForIndex(header.platType)));
        }
    }
}