using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HQ.ApiWeb.Controllers
{
    [HQApiAuthorize(false)]
    public class HomeController : HQControllerBase
    {
        public ActionResult Index(HQRequestHeader header)
        {
            int userId = header.userId;
            return View();
        }

        public JsonResult Test(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK));
        }

        public JsonResult Test2(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, header));
        }
        
        public JsonResult Test3(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, "自己想写的文字", header));
        }

        [HQApiAuthorize(true)]
        public JsonResult Test4(HQRequestHeader header)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, "自己想写的文字", header));
        }
    }
}