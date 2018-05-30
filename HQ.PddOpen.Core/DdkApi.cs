using HQ.Common;
using HQ.PddOpen.Core.Entities;
using HQ.PddOpen.Core.Exceptions;
using Micro.Base.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HQ.PddOpen.Core
{
    /// <summary>
    /// 拼多多-多多客API
    /// </summary>
    internal class DdkApi
    {
        public static object GetGoodsDetail(string clientId, string clientSecret, List<string> goodsIds)
        {
            //todo pdd.ddk.goods.detail（多多进宝商品详情查询）
            return null;
        }

        public static object GetGoodsList(string clientId, string clientSecret)
        {
            //todo pdd.ddk.goods.search（多多进宝商品查询）
            return null;
        }

        /// <summary>
        /// 查询已经生成的推广位信息(pdd.ddk.goods.pid.query)
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PromotionIdJsonResult GetPromotionIdList(string clientId, string clientSecret, int page, int pageSize)
        {
            NameValueCollection coll = new NameValueCollection();
            coll.Add("type", "pdd.ddk.goods.pid.query");
            coll.Add("client_id", clientId);
            coll.Add("timestamp", GetTimeStamp());
            coll.Add("page", page.ToString());
            coll.Add("page_size", pageSize.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<PromotionIdJsonResult>(result);
        }

        public static object GeneratePromotionId(string clientId, string clientSecret)
        {
            //todo pdd.ddk.goods.pid.generate（创建多多进宝推广位）
            return null;
        }

        /// <summary>
        /// 多多进宝推广链接生成()
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static object GeneratePromotionUrl(string clientId, string clientSecret)
        {
            //todo pdd.ddk.goods.promotion.url.generate（多多进宝推广链接生成）
            return null;
        }

        public static object GetIncrementOrderList(string clientId, string clientSecret)
        {
            //todo pdd.ddk.order.list.increment.get（最后更新时间段增量同步推广订单信息）
            return null;
        }

        public static object GetCheckInPromotionBill(string clientId, string clientSecret)
        {
            //todo pdd.ddk.check.in.prom.bill.incr.get（签到红包分享账单列表）
            return null;
        }

        public static object GenerateCheckInPromotionUrl(string clientId, string clientSecret)
        {
            //todo pdd.ddk.check.in.prom.url.generate（生成签到分享推广链接）
            return null;
        }

        public static object GenerateCmsPromotionUrl(string clientId, string clientSecret)
        {
            //todo pdd.ddk.cms.prom.url.generate（生成签到分享推广链接）
            return null;
        }

        public static object GetThemeList(string clientId, string clientSecret)
        {
            //todo pdd.ddk.theme.list.get（多多进宝主题列表查询）
            return null;
        }

        public static object GetThemeDetail(string clientId, string clientSecret)
        {
            //todo pdd.ddk.theme.goods.search（多多进宝主题商品查询）
            return null;
        }

        public static object GenerateThemePromotionUrl(string clientId, string clientSecret)
        {
            //todo pdd.ddk.theme.prom.url.generate（多多进宝主题推广链接生成）
            return null;
        }

        public static object GetAppNewBillList(string clientId, string clientSecret)
        {
            //todo pdd.ddk.app.new.bill.list.get（多多客拉新账单）
            return null;
        }

        public static object GetGoodsTagCatList(string clientId, string clientSecret)
        {
            //todo pdd.goods.opt.get（查询商品标签列表）商品API中！
            return null;
        }

        #region 助手方法
        private static string GetTimeStamp()
        {
            return StringHelper.GetTimeStamp();
        }

        private static string DoPost(NameValueCollection collection)
        {
            IHttpForm httpForm = new HttpForm("", 60000, true, 8);
            HttpFormResponse response = httpForm.Post(new HttpFormPostRequest()
            {
                Url = Config.GATE_WAY,
                FormFields = collection
            });
            return response.Response;
        }

        private static string BuildSign(string clientSecret, NameValueCollection collection)
        {
            string sign = HotSignatureHelper.BuildSign(collection,
                                        clientSecret,
                                        new HotSignatureHelper.BuildSettingModel()
                                        {
                                            EcryptType = HotSignatureHelper.EncryptTypeOptions.MD5_UTF8_32,
                                            SaltPosition = HotSignatureHelper.SaltAppendPositionOptions.ALL,
                                            JoinFormat = HotSignatureHelper.PreSignStrJoinFormatOptions.None
                                        }).ToUpper();
            return sign;
        }

        private static string AppendParameters(string url, NameValueCollection coll)
        {
            string queryString = "";
            IEnumerator myEnumerator = coll.GetEnumerator();
            foreach (string s in coll.AllKeys)
            {
                queryString += string.Format("{0}={1}&", s, coll[s]);
            }
            queryString = queryString.TrimEnd('&');
            if (url.IndexOf('?') != -1)
            {
                url += "&";
            }
            else
            {
                url += "?";
            }
            return url += queryString;
        }

        private static T GetResult<T>(string returnText)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (returnText.Contains("error_code"))
            {
                ErrorJsonResult errorResult = js.Deserialize<ErrorJsonResult>(returnText);
                throw new ErrorJsonResultException(
                    string.Format("拼多多Post请求发生错误！错误代码：{0}，说明：{1}",
                                  (int)errorResult.error_response.error_code,
                                  errorResult.error_response.error_msg),
                    null, errorResult);
            }
            T result = js.Deserialize<T>(returnText);
            return result;
        }
        #endregion
    }
}
