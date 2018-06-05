using HQ.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 创蓝短信接口,V3版本
    /// </summary>
    public class ChuanglanSmsProvider : ISmsProvider
    {
        public bool SendSmsTest(string mobile, string content, out string msg)
        {
            msg = "";
            string serverUrl = "http://smssh1.253.com/msg/send/json";
            string account = "N6672712";
            string pswd = "Qn1XJLGi0jf85b";

            string postJsonTpl = "\"account\":\"{0}\",\"password\":\"{1}\",\"phone\":\"{2}\",\"report\":\"false\",\"msg\":\"{3}\"";
            string jsonBody = string.Format(postJsonTpl, account, pswd, "13754325420", "您的短信验证码为：133123 ，有效期10分钟，祝您生活愉快");

            //{"time":"20170410103836",
            //"msgId":"17041010383624511",
            //"errorMsg":"",
            //"code":"0"
            //}

            bool result = false;
            try
            {
                string jsonResult = doPostMethodToObj(serverUrl, "{" + jsonBody + "}", account, pswd);//请求地址请登录253云通讯自助通平台查看或者询问您的商务负责人获取
                ChuanglanSmsVerThreeResultModel objResult = JsonConvert.DeserializeObject<ChuanglanSmsVerThreeResultModel>(jsonResult);
                int code = Convert.ToInt32(objResult.code);
                switch (code)
                {
                    case 0:
                        result = true;
                        msg = "发送成功";
                        break;
                    case 101:
                        msg = "无此用户";
                        break;
                    case 102:
                        msg = "密码错";
                        break;
                    case 103:
                        msg = "提交过快（提交速度超过流速限制）";
                        break;
                    case 104:
                        msg = "系统忙（因平台侧原因，暂时无法处理提交的短信）";
                        break;
                    case 105:
                        msg = "敏感短信（短信内容包含敏感词）";
                        break;
                    case 106:
                        msg = "消息长度错（>536或<=0）";
                        break;
                    case 107:
                        msg = "包含错误的手机号码";
                        break;
                    case 108:
                        msg = "手机号码个数错（群发>50000或<=0;单发>200或<=0）";
                        break;
                    case 109:
                        msg = "无发送额度（该用户可用短信数已使用完）";
                        break;
                    case 110:
                        msg = "不在发送时间内";
                        break;
                    case 111:
                        msg = "超出该账户当月发送额度限制";
                        break;
                    case 112:
                        msg = "无此产品，用户没有订购该产品";
                        break;
                    case 113:
                        msg = "扩展码格式错（非数字或者长度不对）";
                        break;

                    case 115:
                        msg = "自动审核驳回";
                        break;
                    case 116:
                        msg = "签名不合法，未带签名（用户必须带签名的前提下）";
                        break;
                    case 117:
                        msg = "IP地址认证错,请求调用的IP地址不是系统登记的IP地址";
                        break;
                    case 118:
                        msg = "用户没有相应的发送权限";
                        break;
                    case 119:
                        msg = "用户已过期";
                        break;
                    case 120:
                        msg = "违反防盗用策略(日发送限制)";
                        break;
                    case 123:
                        msg = "发送类型错误";
                        break;
                    case 124:
                        msg = "白模板匹配错误";
                        break;
                    case 125:
                        msg = "匹配驳回模板，提交失败";
                        break;
                    case 127:
                        msg = "定时发送时间格式错误";
                        break;
                    case 128:
                        msg = "内容编码失败";
                        break;
                    case 129:
                        msg = "JSON格式错误";
                        break;
                    case 130:
                        msg = "请求参数错误（缺少必填参数）";
                        break;
                    default:
                        msg = objResult.errorMsg;
                        break;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return result;
        }

        public bool SendSms(string mobile, string content, out string msg)
        {
            msg = "";
            SmsSettingInfo smsSetting = HQGlobalConfigProvider.GetBaseConfig().SmsSetting;
            string serverUrl = smsSetting.ServiceUrl;
            string account = smsSetting.SerialNo;
            string pswd = smsSetting.Password;

            string postJsonTpl = "\"account\":\"{0}\",\"password\":\"{1}\",\"phone\":\"{2}\",\"report\":\"false\",\"msg\":\"{3}\"";
            string jsonBody = string.Format(postJsonTpl, account, pswd, mobile, content.Replace("\"", ""));

            bool result = false;
            try
            {
                string jsonResult = doPostMethodToObj(serverUrl, "{" + jsonBody + "}", account, pswd);
                ChuanglanSmsVerThreeResultModel objResult = JsonConvert.DeserializeObject<ChuanglanSmsVerThreeResultModel>(jsonResult);
                int code = Convert.ToInt32(objResult.code);
                switch (code)
                {
                    case 0:
                        result = true;
                        msg = "发送成功";
                        break;
                    case 101:
                        msg = "无此用户";
                        break;
                    case 102:
                        msg = "密码错";
                        break;
                    case 103:
                        msg = "提交过快（提交速度超过流速限制）";
                        break;
                    case 104:
                        msg = "系统忙（因平台侧原因，暂时无法处理提交的短信）";
                        break;
                    case 105:
                        msg = "敏感短信（短信内容包含敏感词）";
                        break;
                    case 106:
                        msg = "消息长度错（>536或<=0）";
                        break;
                    case 107:
                        msg = "包含错误的手机号码";
                        break;
                    case 108:
                        msg = "手机号码个数错（群发>50000或<=0;单发>200或<=0）";
                        break;
                    case 109:
                        msg = "无发送额度（该用户可用短信数已使用完）";
                        break;
                    case 110:
                        msg = "不在发送时间内";
                        break;
                    case 111:
                        msg = "超出该账户当月发送额度限制";
                        break;
                    case 112:
                        msg = "无此产品，用户没有订购该产品";
                        break;
                    case 113:
                        msg = "扩展码格式错（非数字或者长度不对）";
                        break;

                    case 115:
                        msg = "自动审核驳回";
                        break;
                    case 116:
                        msg = "签名不合法，未带签名（用户必须带签名的前提下）";
                        break;
                    case 117:
                        msg = "IP地址认证错,请求调用的IP地址不是系统登记的IP地址";
                        break;
                    case 118:
                        msg = "用户没有相应的发送权限";
                        break;
                    case 119:
                        msg = "用户已过期";
                        break;
                    case 120:
                        msg = "违反防盗用策略(日发送限制)";
                        break;
                    case 123:
                        msg = "发送类型错误";
                        break;
                    case 124:
                        msg = "白模板匹配错误";
                        break;
                    case 125:
                        msg = "匹配驳回模板，提交失败";
                        break;
                    case 127:
                        msg = "定时发送时间格式错误";
                        break;
                    case 128:
                        msg = "内容编码失败";
                        break;
                    case 129:
                        msg = "JSON格式错误";
                        break;
                    case 130:
                        msg = "请求参数错误（缺少必填参数）";
                        break;
                    default:
                        msg = objResult.errorMsg;
                        break;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return result;
        }

        public bool SendSmsMulti(string[] mobileList, string content, out string msg)
        {
            throw new NotImplementedException();
        }

        public static string doPostMethodToObj(string url, string jsonBody, string username, string password)
        {
            string result = String.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            // Create NetworkCredential Object 
            //NetworkCredential admin_auth = new NetworkCredential("username", "password");
            NetworkCredential admin_auth = new NetworkCredential(username, password);

            // Set your HTTP credentials in your request header
            httpWebRequest.Credentials = admin_auth;

            // callback for handling server certificates
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            using (StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
                streamWriter.Flush();
                streamWriter.Close();
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            }
            return result;
        }

    }

    internal class ChuanglanSmsVerThreeResultModel
    {
        public string time { get; set; }
        public string msgId { get; set; }
        public string errorMsg { get; set; }
        public string code { get; set; }
    }

}
