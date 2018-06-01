using HQ.ApiWeb.Models;
using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.BLL.User;
using HQ.Core.Enum;
using HQ.Core.Model.ViewModel;
using HQ.Model;
using Micro.Base.Common;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace HQ.ApiWeb.Filters
{
    /// <summary>
    /// API签名拦截器
    /// </summary>
    public class HQApiAuthorizeAttribute : ActionFilterAttribute
    {
        private bool flgCheckLogin = true;

        /// <summary>
        /// 签名校验
        /// </summary>
        /// <param name="checkLogin">是否检查用户登录状态，默认为true</param>
        public HQApiAuthorizeAttribute(bool checkLogin = true)
        {
            this.flgCheckLogin = checkLogin;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //获取头部信息
            HttpContextBase context = filterContext.HttpContext;
            string appVersion = GetHeaderValue(context, "appVersion");//APP版本
            string hwid = GetHeaderValue(context, "hwid");//设备号
            string mobileType = GetHeaderValue(context, "mobileType");//设备类型
            int osType = GetHeaderIntValue(context, "osType", (int)HQEnums.ClientOsTypeOptions.unknown);//系统类型  miniprogram->0；ios->1；android->2；h5->3
            string osVersion = GetHeaderValue(context, "osVersion");// 系统版本
            string ttid = GetHeaderValue(context, "ttid");//渠道信息
            string userToken = GetHeaderValue(context, "userToken");//用户token
            string userId = GetHeaderValue(context, "userId");//用户ID

            //签名校验
            if (!this.DebugMode)
            {
                string requestSign = context.Request["sign"];
                if (string.IsNullOrEmpty(requestSign))
                {
                    filterContext.Result = this.GetJsonResult(HQEnums.ResultOptionType.签名未传);
                    return;
                }
                JObject prams = GetParams(filterContext.HttpContext.Request);
                SortedDictionary<string, string> paramters = new SortedDictionary<string, string>();
                paramters.Add("userToken", userToken);
                foreach (var item in prams)
                {
                    if (item.Key != "sign" && !string.IsNullOrEmpty(item.Value.ToString()))
                    {
                        paramters.Add(item.Key.ToLower(), item.Value.ToString());
                    }
                }

                string currentSign = HotSignatureHelper.BuildSign(paramters, HQGlobalConfigProvider.ApiSecret, new HotSignatureHelper.BuildSettingModel()
                {
                    JoinFormat = HotSignatureHelper.PreSignStrJoinFormatOptions.None,
                    EcryptType = HotSignatureHelper.EncryptTypeOptions.MD5_UTF8_32,
                    SaltPosition = HotSignatureHelper.SaltAppendPositionOptions.Suffix
                });

                if (!requestSign.Equals(currentSign))
                {
                    filterContext.Result = this.GetJsonResult(HQEnums.ResultOptionType.签名错误);
                    return;
                }
            }

            //登录校验，由调用的地方自行决定是否需要
            if (this.flgCheckLogin)
            {
                UsersModel userInfo = UsersBLL.Instance.GetModelByToken(userToken);
                if (userInfo == null)
                {
                    filterContext.Result = this.GetJsonResult(HQEnums.ResultOptionType.用户未登录);
                    return;
                }
                if (userInfo.UserId.ToString() != userId)
                {
                    filterContext.Result = this.GetJsonResult(HQEnums.ResultOptionType.用户登录信息非法);
                    return;
                }
                if (userInfo.IsLocked == 1)
                {
                    filterContext.Result = this.GetJsonResult(HQEnums.ResultOptionType.用户已被冻结);
                    return;
                }
            }

            //注入header参数
            var actionParameters = filterContext.ActionDescriptor.GetParameters();
            foreach (var p in actionParameters)
            {
                if (p.ParameterType == typeof(HQ.ApiWeb.Models.HQRequestHeader))
                {
                    int iUserId = 0;
                    int.TryParse(userId, out iUserId);
                    filterContext.ActionParameters[p.ParameterName] = new HQRequestHeader()
                    {
                        appVersion = appVersion,
                        hwid = hwid,
                        mobileType = mobileType,
                        osType = osType,
                        ttid = ttid,
                        userIdStr = userId,
                        userId = iUserId,
                        userToken = userToken
                    };
                    break;
                }
            }
        }

        #region 助手方法
        private JsonResult GetJsonResult(HQEnums.ResultOptionType resutType)
        {
            return new JsonResult() { ContentType = "application/json", Data = new ApiResult(resutType), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// 是否开启debug模式
        /// </summary>
        private bool DebugMode
        {

            get
            {
                return true;
                try
                {
                    string debug = ConfigHelper.GetConfigString("debug", "false");
                    return Convert.ToBoolean(debug);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError(string.Format("get DebugMode error-->Statck:{0},Message:{1}", ex.StackTrace, ex.Message));
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取 get/post 数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private JObject GetParams(HttpRequestBase Request)
        {
            JObject p = new JObject();
            if (Request.HttpMethod.ToLower() == "post")
            {
                NameValueCollection values = HttpContext.Current.Request.Form;
                foreach (string m in values.Keys)
                {
                    p.Add(m, HttpContext.Current.Server.UrlDecode(values[m]));
                }
            }
            else
            {
                NameValueCollection values = HttpContext.Current.Request.QueryString;
                foreach (string m in values.Keys)
                {
                    p.Add(m, HttpContext.Current.Server.UrlDecode(values[m]));
                }
            }
            return p;
        }

        private string GetHeaderValue(HttpContextBase context, string keyName, string defaultValue = "")
        {
            string v = defaultValue;
            foreach (var key in context.Request.Headers.AllKeys)
            {
                if (key.ToLower().Equals(keyName.ToLower()))
                {
                    return context.Request.Headers.Get(key);
                }
            }
            return v;
        }
        private int GetHeaderIntValue(HttpContextBase context, string keyName, int defaultValue = 0)
        {
            int v = defaultValue;
            foreach (var key in context.Request.Headers.AllKeys)
            {
                if (key.ToLower().Equals(keyName.ToLower()))
                {
                    string temp = context.Request.Headers.Get(key);
                    if (int.TryParse(temp, out v))
                    {
                        return v;
                    }
                }
            }
            return v;
        }
        #endregion
    }
}