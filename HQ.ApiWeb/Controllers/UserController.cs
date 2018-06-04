using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.BLL.User;
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
    [HQApiAuthorize(true)]
    public class UserController : HQControllerBase
    {
        /// <summary>
        /// 收藏商品
        /// </summary>
        /// <param name="goodsid"></param>
        /// <returns></returns>
        public ActionResult favorite(HQRequestHeader header, long goodsid)
        {
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, (UserFavoriteBLL.Instance.favorite(goodsid, header.userId, (Int16)header.platType))));
        }

        /// <summary>
        /// 我的收藏
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult favoriteList(HQRequestHeader header, int pageIndex, int pageSize)
        {           
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK,null));
        }
    }
}