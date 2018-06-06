using HQ.ApiWeb.Filters;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HQ.ApiWeb.Controllers
{
    [HQApiAuthorize(true)]
    public class OrderController : HQControllerBase
    {
        // GET: Order
        public ActionResult list()
        {
           var result=ApiResult.ResultWith(HQEnums.ResultOptionType.OK);

            return Json(result);
        }
    }
}