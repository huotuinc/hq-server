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
    public class DdkApi
    {
        /// <summary>
        /// 多多进宝商品详情查询（pdd.ddk.goods.detail）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public static GoodsDetailJsonResult GetGoodsDetail(string clientId, string clientSecret, long goodsId)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.detail", clientId);
            coll.Add("goods_id_list", "[" + goodsId + "]");
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<GoodsDetailJsonResult>(result);
        }

        /// <summary>
        /// 多多进宝商品查询（pdd.ddk.goods.search）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static GoodsSearchListJsonResult GetGoodsList(string clientId, string clientSecret, GoodsSearchConditionEntity condition)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.search", clientId);
            if (!String.IsNullOrEmpty(condition.keyword)) coll.Add("keyword", condition.keyword);
            if (condition.opt_id.HasValue && condition.opt_id > 0) coll.Add("opt_id", condition.opt_id.ToString());
            if (condition.page > 0) coll.Add("page", condition.page.ToString());
            if (condition.page_size >= 10 && condition.page_size <= 100) coll.Add("page_size", condition.page_size.ToString());
            coll.Add("sort_type", ((int)condition.sort_type).ToString());
            coll.Add("with_coupon", condition.with_coupon.ToString().ToLower());
            if (condition.range_list != null)
            {
                StringBuilder sbTemp = new StringBuilder();
                if (condition.range_list.range_from.HasValue && condition.range_list.range_from > 0)
                {
                    sbTemp.AppendFormat("\"range_from\":{0},", condition.range_list.range_from);
                }
                if (condition.range_list.range_to.HasValue && condition.range_list.range_to > 0)
                {
                    sbTemp.AppendFormat("\"range_to\":{0},", condition.range_list.range_to);
                }
                if (sbTemp.Length > 0)
                {
                    sbTemp.AppendFormat("\"range_id\":{0}", condition.range_list.range_id);
                    coll.Add("range_list", string.Format("[{{0}}]", sbTemp.ToString()));
                }
            }
            if (condition.cat_id.HasValue) coll.Add("cat_id", condition.cat_id.ToString());
            if (condition.goods_id_list != null && condition.goods_id_list.Length > 0)
            {
                coll.Add("goods_id_list", "[" + string.Join(",", condition.goods_id_list) + "]");
            }
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<GoodsSearchListJsonResult>(result);
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
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.detail", clientId);
            coll.Add("page", page.ToString());
            coll.Add("page_size", pageSize.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<PromotionIdJsonResult>(result);
        }

        /// <summary>
        /// 创建多多进宝推广位（pdd.ddk.goods.pid.generate）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="number"></param>
        /// <param name="nameList"></param>
        /// <returns></returns>
        public static PromotionIdGenerateJsonResult GeneratePromotionId(string clientId, string clientSecret, int number, List<string> nameList = null)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.pid.generate", clientId);
            coll.Add("number", number.ToString());
            if (nameList != null && nameList.Count > 0 && nameList.Count != number)
            {
                throw new Exception("名称和生成的数量必须一致");
            }
            else
            {
                coll.Add("p_id_name_list", JsonConvert.SerializeObject(nameList));
            }
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<PromotionIdGenerateJsonResult>(result);
        }

        /// <summary>
        /// 多多进宝推广链接生成（pdd.ddk.goods.promotion.url.generate）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="pId"></param>
        /// <param name="goodsId"></param>
        /// <param name="isShortUrl"></param>
        /// <param name="isMultiGroup"></param>
        /// <param name="customParameters"></param>
        /// <returns></returns>
        public static GoodsPromotionUrlJsonResult GeneratePromotionUrl(string clientId, string clientSecret, string pId, long goodsId, Boolean isShortUrl, Boolean isMultiGroup, string customParameters)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.promotion.url.generate", clientId);
            coll.Add("p_id", pId);
            coll.Add("goods_id_list", "[" + goodsId + "]");
            coll.Add("generate_short_url", isShortUrl.ToString().ToLower());
            coll.Add("multi_group", isMultiGroup.ToString().ToLower());
            if (!string.IsNullOrEmpty(customParameters)) coll.Add("custom_parameters", customParameters);
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<GoodsPromotionUrlJsonResult>(result);
        }

        /// <summary>
        /// 最后更新时间段增量同步推广订单信息（pdd.ddk.order.list.increment.get）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="startUpdateTime">最近90天内多多进宝商品订单更新时间--查询时间开始</param>
        /// <param name="endUpdateTime">最近90天内多多进宝商品订单更新时间--查询时间结束</param>
        /// <param name="pId">推广位ID</param>
        /// <param name="pageSize">返回的每页结果订单数，默认为100，范围为10到100，建议使用40~50，可以提高成功率，减少超时数量。</param>
        /// <param name="page">第几页，从1到10000，默认1，注：使用最后更新时间范围增量同步时，必须采用倒序的分页方式（从最后一页往回取）才能避免漏单问题</param>
        /// <returns></returns>
        public static IncrementOrderJsonResult GetIncrementOrderList(string clientId, string clientSecret, DateTime startUpdateTime, DateTime endUpdateTime, string pId, int pageSize, int page)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.goods.promotion.url.generate", clientId);
            coll.Add("start_update_time", ConvertHepler.ConvertDateTimeInt(startUpdateTime).ToString());
            coll.Add("end_update_time", ConvertHepler.ConvertDateTimeInt(endUpdateTime).ToString());
            if (!string.IsNullOrEmpty(pId)) coll.Add("p_id", pId);
            coll.Add("page_size", pageSize.ToString());
            coll.Add("page", page.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<IncrementOrderJsonResult>(result);
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
            //todo pdd.ddk.cms.prom.url.generate（生成商城推广链接）
            return null;
        }

        /// <summary>
        /// 多多进宝主题列表查询（pdd.ddk.theme.list.get）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static ThemeListJsonResult GetThemeList(string clientId, string clientSecret, int page = 1, int pageSize = 10)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.theme.list.get", clientId);
            coll.Add("page", page.ToString());
            coll.Add("page_size", pageSize.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<ThemeListJsonResult>(result);
        }

        /// <summary>
        /// 多多进宝主题商品查询（pdd.ddk.theme.goods.search）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public static ThemeGoodsSearchJsonResult GetThemeGooodsList(string clientId, string clientSecret, long themeId)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.ddk.theme.goods.search", clientId);
            coll.Add("themeId", themeId.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<ThemeGoodsSearchJsonResult>(result);
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

        /// <summary>
        /// 查询商品标签列表（pdd.goods.opt.get）
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static GoodsTagCatJsonResult GetGoodsTagCatList(string clientId, string clientSecret, int parentId = 0)
        {
            NameValueCollection coll = InitNameValueCollection("pdd.goods.opt.get", clientId);
            coll.Add("parent_opt_id", parentId.ToString());
            coll.Add("sign", BuildSign(clientSecret, coll));
            string result = DoPost(coll);
            return GetResult<GoodsTagCatJsonResult>(result);
        }



        #region 助手方法
        private static NameValueCollection InitNameValueCollection(string type, string clientId)
        {
            return new NameValueCollection
            {
                { "type", type },
                { "client_id", clientId },
                { "timestamp", StringHelper.GetTimeStamp() }
            };
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

        private static T GetResult<T>(string returnText) where T : IPinduoduoJsonResult
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
