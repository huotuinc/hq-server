using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
namespace HQ.Common
{
    public class ConvertHepler
    {

        #region datetime与unixtime相互转换
        /// <summary>
        /// datetime转换为unixtime
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }

        /// <summary>
        /// unix时间转换为datetime
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime UnixTimeToTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }

        /// <summary>
        /// 获取UTC时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Int64 GetUTCTime(DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (Int64)(time - startTime).TotalMilliseconds;
        }
        /// <summary>
        /// 从UTC时间转为正常时间格式（毫秒）
        /// </summary>
        /// <param name="t">毫秒</param>
        /// <returns></returns>
        public static DateTime GetTimeFromUTC(Int64 t)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return startTime.AddMilliseconds(t).ToLocalTime();
        }


        #endregion


        #region XML转换DataTable
        /// <summary>
        /// 获取xml 数据转换换DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetReadXml(string xmlpath)
        {
            DataTable dt = new DataTable();
            string filePath = HttpContext.Current.Server.MapPath(xmlpath);
            if (File.Exists(filePath))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(filePath);
                dt = ds.Tables[0];
                ds.Dispose();

            }
            return dt;
        }
        #endregion



        #region 操作 decimal  数据

        /// <summary>
        /// 是否为decimal值
        /// </summary>
        /// <param name="Object"></param>
        /// <returns></returns>
        public static bool IsDecimal(object Object)
        {
            try { decimal.Parse(Object.ToString()); return true; }
            catch { return false; }
        }
        /// <summary>
        /// 对象是否为 decimal  类型数据
        /// </summary>
        /// <param name="Object">要判断的对象</param>
        /// <param name="isTrue">返回是否转换成功</param>
        /// <returns>decimal值</returns>
        private static decimal IsDecimal(object Object, out bool isTrue)
        {
            try { isTrue = true; return decimal.Parse(Object.ToString()); }
            catch { isTrue = false; return 0; }
        }
        /// <summary>
        /// 转换成为 decimal 数据
        /// </summary>
        /// <param name="Object">要转换的对象</param>
        /// <returns>decimal 数据</returns>
        public static decimal ToDecimal(object Object) { return ToDecimal(Object, 0); }
        /// <summary>
        /// 转换成为 decimal 数据
        /// </summary>
        /// <param name="Object">要转换的对象</param>
        /// <param name="Default">默认值</param>
        /// <returns>decimal 数据</returns>
        public static decimal ToDecimal(object Object, decimal Default) { return ToDecimal(Object, Default, 0, 999999999); }

        /// <summary>
        /// 转换成为 decimal 数据
        /// </summary>
        /// <param name="Object">要转换的对象</param>
        /// <param name="Default">默认值</param>
        /// <param name="MinFloat"> 小于等于 转换成功后,下界限定的最小值,若超过范围 则返回 默认值</param>
        /// <returns>decimal 数据</returns>
        public static decimal ToDecimal(object Object, decimal Default, decimal MinFloat) { return ToDecimal(Object, Default, MinFloat, 999999999); }
        /// <summary>
        /// 转换成为 decimal 数据
        /// </summary>
        /// <param name="Object">要转换的对象</param>
        /// <param name="Default">默认值</param>
        /// <param name="MinDecimal"> 下界限定的最小值 , 若超过范围 , 则返回 默认值</param>
        /// <param name="MaxDecimal"> 上界限定的最大值 , 若超过范围 , 则返回 默认值</param>
        /// <returns>decimal 数据</returns>
        public static decimal ToDecimal(object Object, decimal Default, decimal MinDecimal, decimal MaxDecimal)
        {
            bool isTrue = false;
            decimal Decimal = IsDecimal(Object, out isTrue);
            if (!isTrue) return Default;
            if (Decimal < MinDecimal || Decimal > MaxDecimal) return Default;
            return Decimal;
        }
        #endregion

        /// <summary>
        /// 将对象属性转换为key-value对 jwei
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<String, Object> ObjectToDic(Object o)
        {
            Dictionary<String, Object> map = new Dictionary<string, object>();
            Type t = o.GetType();
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new Object[] { }));
                }
            }

            return map;
        }


        #region sign签名和参数排序

        /// <summary>
        /// 除去数组中的空值和签名参数
        /// </summary>
        /// <param name="dicArrayPre">过滤前的参数组</param>
        /// <returns>过滤后的参数组</returns>
        public static Dictionary<string, object> GetFilterPara(Dictionary<string, object> dicArrayPre)
        {
            Dictionary<string, object> dicArray = new Dictionary<string, object>();
            foreach (KeyValuePair<string, object> temp in dicArrayPre)
            {
                if (temp.Key.ToLower() != "sign")
                {
                    dicArray.Add(temp.Key, temp.Value);
                }
            }

            return SortPara(dicArray);
        }

        /// <summary>
        /// 根据字母a到z的顺序把参数排序
        /// </summary>
        /// <param name="dicArrayPre">排序前的参数组</param>
        /// <returns>排序后的参数组</returns>
        public static Dictionary<string, object> SortPara(Dictionary<string, object> dicArrayPre)
        {
            SortedDictionary<string, object> dicTemp = new SortedDictionary<string, object>(dicArrayPre);
            Dictionary<string, object> dicArray = new Dictionary<string, object>(dicTemp);

            return dicArray;
        }
        /// <summary>
        /// 获取签名
        /// </summary>
        /// <param name="sParaTemp"></param>
        /// <param name="sp_key">密钥，如key=sdjkfalskdjf或其他,sp_key是跟着newStr后面进行签名</param>
        /// <param name="newStr">返回拼接好的参数  key=value...</param>
        /// <param name="EncodingCode">签名编码，0：Default，1：UTF-8</param>
        /// <returns></returns>
        public static string Sign(Dictionary<string, object> sParaTemp, string sp_key, out string newStr, int EncodingCode = 0)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, object> kvp in sParaTemp)
            {
                sb.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
            }
            newStr = sb.ToString();
            string newStrTemp = newStr + sp_key;
            if (EncodingCode == 1)
                return EncryptHelper.MD5_8(newStrTemp);
            else
                return EncryptHelper.MD5(newStrTemp);
        }
        #endregion

    }
}
