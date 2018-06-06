using HQ.Common;
using HQ.Core.BLL;
using HQ.Core.Enum;
using HQ.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 微信token统一生成负责人,appid,appsecret绑定模式下
    /// provider只管提供数据，builder只管保证最新的token
    /// </summary>
    public class WxSecretTokenBuilder
    {
        private static object lockHelper = new object();
        private static WxSecretTokenBuilder instance = new WxSecretTokenBuilder();
        private WxSecretTokenBuilder()
        { }

        /// <summary>
        /// 单例出口
        /// </summary>
        public static WxSecretTokenBuilder Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            try
            {
                List<WeixinMPInfo> lstMpInfos = this.LoadAllMpInfo();
                this.Execute(lstMpInfos);
            }
            catch (Exception ex)
            {
                LogHelper.Write(string.Format("WeixinTokenBuilder->Start异常：{0}", ex.Message + "|" + ex.StackTrace));
            }
        }

        /// <summary>
        /// 读取所有公众号的appid等信息
        /// </summary>
        /// <returns></returns>
        private List<WeixinMPInfo> LoadAllMpInfo()
        {
            List<WeixinMPInfo> lstMpInfos = new List<WeixinMPInfo>();
            lstMpInfos.Add(new WeixinMPInfo()
            {
                AppId = HQGlobalConfigProvider.GetBaseConfig().WxAppId,
                AppSecret = HQGlobalConfigProvider.GetBaseConfig().WxAppSecret,
                Name = ""
            });
            return lstMpInfos;
        }

        /// <summary>
        /// 执行批量生产
        /// </summary>
        /// <param name="lstMpInfos"></param>
        private void Execute(List<WeixinMPInfo> lstMpInfos)
        {
            DateTime dtBegin = DateTime.Now;
            LogHelper.Write(string.Format("开始执行Token更新操作，共{0}个...", lstMpInfos.Count));
            int completed = 0, successed = 0;
            foreach (WeixinMPInfo mpInfo in lstMpInfos)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object obj)
                {
                    WeixinMPInfo _mpInfo = (WeixinMPInfo)obj;
                    string accessToken = "";
                    string jsapiTicket = "";
                    string errMsg = "";
                    try
                    {
                        accessToken = this.RefreshAccessToken(_mpInfo, out errMsg);
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            jsapiTicket = this.RefreshJsApiTicket(accessToken, _mpInfo, out errMsg);
                        }

                        if (errMsg != "")
                        {
                            LogHelper.Write(">>>更新token失败：" + errMsg);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Write(string.Format(">>>更新token失败：{0}", ex.Message));
                    }

                    lock (lockHelper)
                    {
                        completed++;
                        if (accessToken != "" && jsapiTicket != "")
                        {
                            successed++;
                        }
                        if (completed >= lstMpInfos.Count)
                        {
                            TimeSpan tsEplase = DateTime.Now.Subtract(dtBegin);
                            LogHelper.Write(string.Format("执行Token更新操作结束，耗时:{0}分{1}秒，共操作{2}个，成功{3}个",
                                tsEplase.Minutes, tsEplase.Seconds, completed, successed));
                        }
                    }
                }), mpInfo);
            }
        }

        /// <summary>
        /// 刷新accessToken，数据库更新
        /// </summary>
        /// <param name="mpInfo">公众账号APPID等信息</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        private string RefreshAccessToken(WeixinMPInfo mpInfo, out string errMsg)
        {
            string accessToken = WeixinTokenBuildHelper.BuildAccessToken(mpInfo.AppId, mpInfo.AppSecret, out errMsg);

            if (accessToken == "")
            {
                return "";
            }
            //尝试更新，没有就新增
            WxTokensModel model = WxTokensBLL.Instance.GetModel((int)HQEnums.WxTokenTypeOptions.Accesstoken);
            if (model == null)
            {
                WxTokensBLL.Instance.Add(new WxTokensModel()
                {
                    BuildTime = DateTime.Now,
                    Token = accessToken,
                    TypeKey = (int)HQEnums.WxTokenTypeOptions.Accesstoken
                });
            }
            else
            {
                model.Token = accessToken;
                model.BuildTime = DateTime.Now;
                WxTokensBLL.Instance.Update(model);
            }
            return accessToken;
        }

        /// <summary>
        /// 刷新jsapi_ticket，数据库更新
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="mpInfo"></param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        private string RefreshJsApiTicket(string accessToken, WeixinMPInfo mpInfo, out string errMsg)
        {
            string ticket = WeixinTokenBuildHelper.BuildJsApiTickets(accessToken, out errMsg);
            if (ticket == "")
            {
                return "";
            }
            //尝试更新，没有就新增
            WxTokensModel model = WxTokensBLL.Instance.GetModel((int)HQEnums.WxTokenTypeOptions.Jsticket);
            if (model == null)
            {
                WxTokensBLL.Instance.Add(new WxTokensModel()
                {
                    BuildTime = DateTime.Now,
                    Token = ticket,
                    TypeKey = (int)HQEnums.WxTokenTypeOptions.Jsticket
                });
            }
            else
            {
                model.Token = ticket;
                model.BuildTime = DateTime.Now;
                WxTokensBLL.Instance.Update(model);
            }
            return ticket;
        }
    }

    /// <summary>
    /// 微信token生成助手
    /// </summary>
    public class WeixinTokenBuildHelper
    {
        /// <summary>
        /// 生成微信AccessToken
        /// </summary>
        /// <param name="appId">ID</param>
        /// <param name="appSecret">秘钥</param>
        /// <param name="errMsg">出错信息</param>
        /// <returns></returns>
        public static string BuildAccessToken(string appId, string appSecret, out string errMsg)
        {
            errMsg = "";
            try
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appId, appSecret);
                IHttpForm _httpForm = new HttpForm("", 15000, true, 8);
                url += "&rnd=" + Guid.NewGuid().ToString();
                HttpFormResponse _response = _httpForm.Get(new HttpFormGetRequest()
                {
                    Url = url
                });
                Dictionary<object, object> dict = JsonConvert.DeserializeObject<Dictionary<object, object>>(_response.Response);
                if (dict.ContainsKey("access_token"))
                {

                    return dict["access_token"].ToString();
                }
                errMsg = string.Format("获取AccessToken失败:{0}", _response.Response);
                return "";
            }
            catch (Exception ex)
            {
                errMsg = string.Format("BuildAccessToken异常:{0}|{1}", ex.Message, ex.StackTrace);
                return "";
            }
        }

        /// <summary>
        /// 生成JSSDK_API调用用到的票据
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="errMsg">出错信息</param>
        /// <returns></returns>
        public static string BuildJsApiTickets(string accessToken, out string errMsg)
        {
            errMsg = "";
            try
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?type=jsapi&access_token={0}", accessToken);
                IHttpForm _httpForm = new HttpForm("", 1500, true, 8);
                url += "&rnd=" + Guid.NewGuid().ToString();
                HttpFormResponse _response = _httpForm.Get(new HttpFormGetRequest()
                {
                    Url = url
                });
                Dictionary<object, object> dict = JsonConvert.DeserializeObject<Dictionary<object, object>>(_response.Response);
                if (dict.ContainsKey("ticket"))
                {
                    return dict["ticket"].ToString();
                }
                errMsg = string.Format("获取JsApiTickets失败:{0}", _response.Response);
                return "";
            }
            catch (Exception ex)
            {
                errMsg = string.Format("BuildJsApiTickets异常::{0}|{1}", ex.Message, ex.StackTrace);
                return "";
            }
        }
    }

    /// <summary>
    /// 微信公众号信息
    /// </summary>
    public class WeixinMPInfo
    {
        /// <summary>
        /// 商城名称
        /// </summary>
        public string Name { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
    }
}
