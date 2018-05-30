namespace HQ.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Linq;

    public class CommonUtil {

        public static String CreateNoncestr(int length) {
            String chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String res = "";
            Random rd = new Random();
            for (int i = 0; i < length; i++) {
                res += chars[rd.Next(chars.Length - 1)];
            }
            return res;
        }

        public static String CreateNoncestr() {
            String chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            String res = "";
            Random rd = new Random();
            for (int i = 0; i < 16; i++) {
                res += chars[rd.Next(chars.Length - 1)];
            }
            return res;
        }

        private static string UrlEncode(string temp) {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < temp.Length; i++) {
                string t = temp[i].ToString();
                string k = HttpUtility.UrlEncode(t);
                if (t == k) {
                    stringBuilder.Append(t);
                } else {
                    stringBuilder.Append(k.ToUpper());
                }
            }
            return stringBuilder.ToString();
        }
        

        public static string FormatQueryParaMap(Dictionary<string, string> parameters)
        {

            string buff = "";
            try
            {

                var result = from pair in parameters orderby pair.Key select pair;
                foreach (KeyValuePair<string, string> pair in result)
                {
                    if (pair.Key != "")
                    {
                        buff += pair.Key + "="
                                + UrlEncode(pair.Value) + "&";

                    }
                }
                if (buff.Length == 0 == false)
                {
                    buff = buff.Substring(0, (buff.Length - 1) - (0));
                }
            }
            catch (Exception e)
            {
                throw new SDKRuntimeException(e.Message);
            }

            return buff;
        }

        public static string FormatBizQueryParaMap(Dictionary<string, string> paraMap,
                bool urlencode, bool tolower = true)
        {

            string buff = "";
            try
            {
                var result = from pair in paraMap orderby pair.Key select pair;
                foreach (KeyValuePair<string, string> pair in result)
                {
                    if (pair.Key != "")
                    {

                        string key = pair.Key;
                        string val = pair.Value;
                        if (urlencode)
                        {
                            val= UrlEncode(val);
                        }
                        if (tolower)
                        {
                            buff += key.ToLower() + "=" + val + "&";
                        }
                        else
                        {
                            buff += key + "=" + val + "&";
                        }
                        
                    }
                }

                if (buff.Length == 0 == false)
                {
                    buff = buff.Substring(0, (buff.Length - 1) - (0));
                }
            }
            catch (Exception e)
            {
                throw new SDKRuntimeException(e.Message);
            }
            //LogHelper.WriteSuccess("buff----->" + buff);
            return buff;
        }

        public static bool IsNumeric(String str)
        {
            try
            {
                int.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ArrayToXml(Dictionary<string, string> arr)
        {
            String xml = "<xml>";

            foreach (KeyValuePair<string, string> pair in arr)
            {
                String key = pair.Key;
                String val = pair.Value;
                if (IsNumeric(val))
                {
                    xml += "<" + key + ">" + val + "</" + key + ">";

                }
                else
                    xml += "<" + key + "><![CDATA[" + val + "]]></" + key + ">";
            }

            xml += "</xml>";
            return xml;
        }

        public static Dictionary<string, string> XmlToArray(string xml)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            XDocument doc = XDocument.Parse(xml);
            foreach (XElement ele in doc.Root.Elements())
            {
                dic.Add(ele.Name.LocalName, ele.Value);
            }
            return dic;
        }

        /// <summary>
        /// ªÒ»°Sign
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key"></param>
        /// <param name="paramToLower"></param>
        /// <returns></returns>
        public static string GetSign(Dictionary<string, string> parameters, string key, bool paramToLower = true)
        {
            string sign = CommonUtil.FormatBizQueryParaMap(parameters, false, paramToLower);
            return MD5SignUtil.Sign(sign, key);
        }
    }
}
