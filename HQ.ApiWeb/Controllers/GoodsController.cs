using HQ.ApiWeb.Filters;
using HQ.Core.BLL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HQ.ApiWeb.Controllers
{
    [HQApiAuthorize(false)]
    public class GoodsControllerr : Controller
    {
        /// <summary>
        /// 首页推荐
        /// </summary>
        /// <returns></returns>
        public ActionResult recommend()
        {
            String json = JsonConvert.SerializeObject(AdvertiseBLL.Instance.listForIndex());
            return Content(json, "application/json");
        }
    }
}