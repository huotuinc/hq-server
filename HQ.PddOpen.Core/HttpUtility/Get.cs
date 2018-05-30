using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HQ.PddOpen.Core;
using HQ.PddOpen.Core.Entities;
using HQ.PddOpen.Core.Exceptions;

namespace Senparc.Weixin.HttpUtility
{
    /// <summary>
    /// Get请求处理
    /// </summary>
    public static class Get
    {
        #region 同步方法

        /// <summary>
        /// GET方式请求URL，并返回T类型
        /// </summary>
        /// <typeparam name="T">接收JSON的数据类型</typeparam>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <returns></returns>
        public static T GetJson<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = RequestUtility.HttpGet(url, encoding);

            //WeixinTrace.SendLog(url, returnText);

            JavaScriptSerializer js = new JavaScriptSerializer();
            if (maxJsonLength.HasValue)
            {
                js.MaxJsonLength = maxJsonLength.Value;
            }

            if (returnText.Contains("error_code"))
            {
                //可能发生错误
                ErrorJsonResult errorResult = js.Deserialize<ErrorJsonResult>(returnText);

                //发生错误
                throw new ErrorJsonResultException(
                    string.Format("拼多多请求发生错误！错误代码：{0}，说明：{1}",
                                    (int)errorResult.error_code, errorResult.error_msg), null, errorResult, url);

            }

            T result = js.Deserialize<T>(returnText);

            return result;
        }

        /// <summary>
        /// 从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        public static void Download(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            WebClient wc = new WebClient();
            var data = wc.DownloadData(url);
            foreach (var b in data)
            {
                stream.WriteByte(b);
            }
        }

        #endregion

        #region 异步方法

        /// <summary>
        /// 异步GetJsonA
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <param name="maxJsonLength">允许最大JSON长度</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ErrorJsonResultException"></exception>
        public static async Task<T> GetJsonAsync<T>(string url, Encoding encoding = null, int? maxJsonLength = null)
        {
            string returnText = await RequestUtility.HttpGetAsync(url, encoding);

            JavaScriptSerializer js = new JavaScriptSerializer();
            if (maxJsonLength.HasValue)
            {
                js.MaxJsonLength = maxJsonLength.Value;
            }

            if (returnText.Contains("error_code"))
            {
                //可能发生错误
                ErrorJsonResult errorResult = js.Deserialize<ErrorJsonResult>(returnText);
                //发生错误
                throw new ErrorJsonResultException(
                    string.Format("拼多多请求发生错误！错误代码：{0}，说明：{1}",
                                    (int)errorResult.error_code, errorResult.error_msg), null, errorResult, url);

            }

            T result = js.Deserialize<T>(returnText);

            return result;
        }

        /// <summary>
        /// 异步从Url下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task DownloadAsync(string url, Stream stream)
        {
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

            WebClient wc = new WebClient();
            var data = await wc.DownloadDataTaskAsync(url);
            await stream.WriteAsync(data, 0, data.Length);
            //foreach (var b in data)
            //{
            //    stream.WriteAsync(b);
            //}
        }

        #endregion
    }
}
