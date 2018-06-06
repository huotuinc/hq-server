using HQ.ApiWeb.Filters;
using HQ.ApiWeb.Models;
using HQ.Core.BLL.User;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using HQ.Core.ViewModel.User;
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
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, UserFavoriteBLL.Instance.favoriteList(header.userId, header.platType, pageIndex, pageSize)));
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="header"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        public ActionResult favoriteDelete(HQRequestHeader header, string ids)
        {
            if (String.IsNullOrEmpty(ids)) return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.参数有误));
            if (ids.EndsWith(",")) ids = ids.Substring(0, ids.Length - 1);

            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, (UserFavoriteBLL.Instance.favoriteDelete(ids, header.userId, (Int16)header.platType))));
        }

        /// <summary>
        /// 我的团队
        /// </summary>
        /// <param name="header"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult myTeams(HQRequestHeader header, int pageIndex, int pageSize)
        {
            MyTeamView view = UsersBLL.Instance.MyTeams(header.userId, pageIndex, pageSize);
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, view));
        }

        public ActionResult myProfit(HQRequestHeader header)
        {
            MyProfitView profit = UsersBLL.Instance.myProfit(header.userId);
            return Json(ApiResult.ResultWith(HQEnums.ResultOptionType.OK, profit));
        }
    }
}