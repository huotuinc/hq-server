using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
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
    }
}