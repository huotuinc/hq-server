using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.BLL;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using NLog;
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
        /// <summary>
        /// 日志
        /// </summary>
        static Logger log = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// 获取推广订单
        /// </summary>
        /// <param name="header"></param>
        /// <param name="orderStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult list(HQRequestHeader header, int orderStatus, int pageIndex, int pageSize, string date)
        {
            try
            {
                var list = OrdersBLL.Instance.GetMyOrder(header.platType, orderStatus, pageIndex, pageSize, date);
                var result = ApiResult.ResultWith(HQEnums.ResultOptionType.OK, list);

                return Json(result);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.服务器错误));
            }
        }
    }
}