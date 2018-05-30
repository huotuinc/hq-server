using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;
using System.Web;

namespace HQ.Common
{
    /// <summary>
    /// 字符串帮助类
    /// </summary>
    public class StringHelper
    {
        private StringHelper() { }

        #region 去除HTML
        /// <summary>
        /// 去除HTML
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetStringNoneHtml(object o)
        {
            string Htmlstring = Convert.ToString(o);
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"(<[^>]+?>)|(&nbsp;)|\s", "", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<img[^>]*>;", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring.Replace("&ldquo;", "“");
            Htmlstring.Replace("&rdquo;", "”");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region 切割字符串
        /// <summary>
        /// 切割字符串【去除HTML】
        /// </summary>
        /// <param name="o"></param>
        /// <param name="length">字节长度</param>
        /// <param name="endStr">结束字符</param>
        /// <returns></returns>
        public static string GetSubStringNoneHtml(object o, int length, string endStr)
        {
            return GetSubString(GetStringNoneHtml(o), length, endStr);
        }


        /// <summary>
        /// 切割字符串
        /// </summary>
        /// <param name="o"></param>
        /// <param name="length">字节长度</param>
        /// <param name="endStr">结束字符</param>
        /// <returns></returns>
        public static string GetSubString(object o, int length, string endStr)
        {
            string sStr = "";
            if (o != null)
                sStr = o.ToString();
            string resultString = string.Empty;
            byte[] myByte = System.Text.Encoding.GetEncoding("gbk").GetBytes(sStr);
            length = length - endStr.Length;
            if (myByte.Length > length)
            {
                resultString = Encoding.GetEncoding("gbk").GetString(myByte, 0, length);
                string lastChar = resultString.Substring(resultString.Length - 1, 1);
                if (lastChar.Equals(sStr.Substring(resultString.Length - 1, 1)))
                {//如果截取后最后一个字符与原始输入字符串中同一位置的字符相等，则表示截取完成
                    sStr = resultString;
                }
                else
                {//如果不相等，则减去一个字节再截取
                    sStr = Encoding.GetEncoding("gbk").GetString(myByte, 0, length - 1);
                }
                return sStr + endStr;
            }
            return sStr;
        }
        #endregion

        #region 过滤特殊字符 用于sql
        /// <summary>
        /// 过滤特殊字符 用于sql
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetSafeString(object o)
        {
            Regex reg = new Regex(@"^(\w|-)+$");
            string tem = o.ToString();
            if (!reg.IsMatch(tem))
            {
                tem = "";
            }
            return tem;
        }
        #endregion

        #region 获得一个按时间的随机数
        /// <summary>
        /// 获得一个按时间的随机数
        /// </summary>
        /// <returns></returns>
        public static string GetDataTimeRnd()
        {
            string year, month, day, hour, minute, second, millisecond;
            DateTime date = DateTime.Now;
            Random rand = new Random();
            year = date.Year.ToString();
            if (date.Month < 10)
                month = "0" + date.Month.ToString();
            else
                month = date.Month.ToString();
            if (date.Day < 10)
                day = "0" + date.Day.ToString();
            else
                day = date.Day.ToString();
            if (date.Hour < 10)
                hour = "0" + date.Hour.ToString();
            else
                hour = date.Hour.ToString();
            if (date.Minute < 10)
                minute = "0" + date.Minute.ToString();
            else
                minute = date.Minute.ToString();
            if (date.Second < 10)
                second = "0" + date.Second.ToString();
            else
                second = date.Second.ToString();
            if (date.Millisecond < 10)
                millisecond = "00" + date.Millisecond.ToString();
            else if (date.Millisecond < 100)
                millisecond = "0" + date.Millisecond.ToString();
            else
                millisecond = date.Millisecond.ToString();
            return year + month + day + hour + minute + second + millisecond + rand.Next(1000).ToString();
        }
        #endregion

        #region 读取文件
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="strFilePath">文件绝对路径</param>
        /// <returns></returns>
        public static StringBuilder ReadFileByGb2312(string strFilePath)
        {
            using (StreamReader m_streamReader = new StreamReader(strFilePath, System.Text.Encoding.GetEncoding("gb2312")))
            {
                StringBuilder m_strToEnd = new StringBuilder();
                m_strToEnd.Append(m_streamReader.ReadToEnd());
                m_streamReader.Close();
                return m_strToEnd;
            }
        }

        /// <summary>
        /// 从字符串中读取某个标签下的内容，<!--tagname-->内容<!--/tagname-->
        /// </summary>
        /// <param name="strSign"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        public static string ReadSign(string strSign, string strContent)
        {
            if (strSign == null || strSign.Length == 0) return strContent;

            string strPattern = @"<!--" + strSign + "-->.*<!--/" + strSign + "-->";
            string strTemp = "";
            MatchCollection mc;
            Regex r = new Regex(strPattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            mc = r.Matches(strContent);
            for (int i = 0; i < mc.Count; i++)
            {
                strTemp += mc[i].Value;
            }
            return strTemp;
        }

        /// <summary>
        /// 得到缓存依赖KEY
        /// </summary>
        /// <param name="customerid">商户Id</param>
        /// <returns></returns>
        public static string GetDepFile(string key, string CACHEDEPFILE)
        {
            string depFile = HttpContext.Current.Server.MapPath(string.Format(CACHEDEPFILE, key));
            if (!Directory.Exists(Path.GetDirectoryName(depFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(depFile));
            }
            if (!File.Exists(depFile))
            {
                File.Create(depFile).Dispose();
            }
            return depFile;
        }
        /// <summary>
        /// 刷新缓存
        /// </summary>
        /// <param name="customerid">商户Id</param>
        public static void RefreshCache(string key, string CACHEDEPFILE)
        {
            string depFile = HttpContext.Current.Server.MapPath(string.Format(CACHEDEPFILE, key));
            File.WriteAllText(depFile, DateTime.Now.ToString());
        }
        #endregion

        #region 获得客户的IP
        /// <summary>
        /// 获得客户的IP
        /// </summary>
        /// <returns></returns>
        public static string GetUserIp()
        {
            try
            {
                string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ip == null || ip.Length == 0 || ip.ToLower().IndexOf("unknown") > -1)
                {
                    ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    if (ip.IndexOf(',') > -1)
                    {
                        ip = ip.Substring(0, ip.IndexOf(','));
                    }
                    if (ip.IndexOf(';') > -1)
                    {
                        ip = ip.Substring(0, ip.IndexOf(';'));
                    }
                }

                Regex regex = new Regex("[^0-9.]");
                if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
                {
                    ip = HttpContext.Current.Request.UserHostAddress;
                    if (ip == null || ip.Length == 0 || regex.IsMatch(ip))
                    {
                        ip = "0.0.0.0";
                    }
                }
                return ip;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 获得两个日期的间隔
        /// <summary>
        /// 获得两个日期的间隔
        /// </summary>
        /// <param name="DateTime1">日期一。</param>
        /// <param name="DateTime2">日期二。</param>
        /// <returns>日期间隔TimeSpan。</returns>
        public static TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
        #endregion

        #region 格式化日期时间
        /// <summary>
        /// 格式化日期时间
        /// </summary>
        /// <param name="dateTime1">日期时间</param>
        /// <param name="dateMode">显示模式</param>
        /// <returns>0-9种模式的日期</returns>
        public static string FormatDate(DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }
        #endregion

        #region HTML转行成TEXT
        /// <summary>
        /// HTML转行成TEXT
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string HtmlToTxt(string strHtml)
        {
            string[] aryReg ={
            @"<script[^>]*?>.*?</script>",
            @"<(\/\s*)?!?((\w+:)?\w+)(\w+(\s*=?\s*(([""'])(\\[""'tbnr]|[^\7])*?\7|\w+)|.{0})|\s)*?(\/\s*)?>",
            @"([\r\n])[\s]+",
            @"&(quot|#34);",
            @"&(amp|#38);",
            @"&(lt|#60);",
            @"&(gt|#62);", 
            @"&(nbsp|#160);", 
            @"&(iexcl|#161);",
            @"&(cent|#162);",
            @"&(pound|#163);",
            @"&(copy|#169);",
            @"&#(\d+);",
            @"-->",
            @"<!--.*\n"
            };

            string newReg = aryReg[0];
            string strOutput = strHtml;
            for (int i = 0; i < aryReg.Length; i++)
            {
                Regex regex = new Regex(aryReg[i], RegexOptions.IgnoreCase);
                strOutput = regex.Replace(strOutput, string.Empty);
            }

            strOutput.Replace("<", "");
            strOutput.Replace(">", "");
            strOutput.Replace("\r\n", "");


            return strOutput;
        }
        #endregion

        #region 得到字符串长度，一个汉字长度为2
        /// <summary>
        /// 得到字符串长度，一个汉字长度为2
        /// </summary>
        /// <param name="inputString">参数字符串</param>
        /// <returns></returns>
        public static int StrLength(string inputString)
        {
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            int tempLen = 0;
            byte[] s = ascii.GetBytes(inputString);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                    tempLen += 2;
                else
                    tempLen += 1;
            }
            return tempLen;
        }
        #endregion

        #region 生成随机数
        /// <summary>
        /// [MinNum,MaxNum)
        /// </summary>
        /// <param name="MinNum"></param>
        /// <param name="MaxNum"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int MinNum, int MaxNum)
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());
            return r.Next(MinNum, MaxNum);
        }
        /// <summary>
        /// 生成指定位随机数(包含数据大小写字母)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CreateCheckCode(int n)
        {
            char[] CharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string sCode = "";
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
            {
                sCode += CharArray[random.Next(CharArray.Length)];
            }
            return sCode;
        }
        /// <summary>
        /// 生成指定位随机数，根据类型生成不同的随机数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="createtype">类型 0:字母加数字 1数字 2字母</param>
        /// <returns></returns>
        public static string CreateCheckCode(int n, int createtype, Random random)
        {
            string sCode = "";
            if (createtype == 0)
            {
                char[] CharArray = { '0', 'A', 'B', 'C', 'D', 'E', 'F', '1', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', '2', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', '3', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', '4', 'e', 'f', 'g', 'h', 'j', 'k', '5', 'l', 'm', 'n', 'o', '6', 'p', 'q', 'r', 's', '7', 't', 'u', 'v', 'w', '8', 'x', 'y', 'z', '9' };
                for (int i = 0; i < n; i++)
                {
                    sCode += CharArray[random.Next(CharArray.Length)];
                }
            }
            else if (createtype == 1)
            {
                char[] CharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                for (int i = 0; i < n; i++)
                {
                    sCode += CharArray[random.Next(CharArray.Length)];
                }
            }
            else if (createtype == 2)
            {
                char[] CharArray = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                for (int i = 0; i < n; i++)
                {
                    sCode += CharArray[random.Next(CharArray.Length)];
                }
            }
            return sCode;
        }
        
        /// <summary>
        /// 生成指定位随机数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CreateCheckCodeWithNum(int n)
        {
            char[] CharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string sCode = "";
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < n; i++)
            {
                sCode += CharArray[random.Next(CharArray.Length)];
            }
            return sCode;
        }

        #region

        /// <summary>
        /// 短地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ShortUrl(string url)
        {
            //可以自定义生成MD5加密字符传前的混合KEY
            string key = "huotu";
            //要使用生成URL的字符
            string[] chars = new string[]{
	            "a","b","c","d","e","f","g","h",
	            "i","j","k","l","m","n","o","p",
                "q","r","s","t","u","v","w","x",
	            "y","z","0","1","2","3","4","5",
	            "6","7","8","9","A","B","C","D",
	            "E","F","G","H","I","J","K","L",
	            "M","N","O","P","Q","R","S","T",
	            "U","V","W","X","Y","Z"
	          };
            //对传入网址进行MD5加密
            string hex = EncryptHelper.MD5_8(key + url);
            
            string[] resUrl = new string[4];

            for (int i = 0; i < 4; i++)
            {
                //把加密字符按照8位一组16进制与0x3FFFFFFF进行位与运算
                int hexint = 0x3FFFFFFF & Convert.ToInt32("0x" + hex.Substring(i * 8, 8), 16);
                string outChars = string.Empty;
                for (int j = 0; j < 6; j++)
                {
                    //把得到的值与0x0000003D进行位与运算，取得字符数组chars索引
                    int index = 0x0000003D & hexint;
                    //把取得的字符相加
                    outChars += chars[index];
                    //每次循环按位右移5位
                    hexint = hexint >> 5;
                }
                //把字符串存入对应索引的输出数组
                resUrl[i] = outChars;
            }

            return resUrl[0];
        }

        #endregion


        #endregion

        #region 获取页面值[这个PageBaseHelper类中有的]
        public static string GetQueryString(string sQueryKey, string sDefaultValue)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request.QueryString[sQueryKey] != null && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[sQueryKey]))
            {
                return HttpContext.Current.Request.QueryString[sQueryKey];
            }
            return sDefaultValue;
        }

        /// <summary>
        /// 获取Request.QueryString中的指定键的值
        /// </summary>
        /// <param name="sQueryKey">键</param>
        /// <param name="iDefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetQueryString(string sQueryKey, int iDefaultValue)
        {
            int iValue = 0;
            if (Int32.TryParse(GetQueryString(sQueryKey, iDefaultValue.ToString()), out iValue))
            {
                return iValue;
            }
            return iDefaultValue;
        }
        /// <summary>
        /// 获取Request.QueryString中的指定键的值
        /// </summary>
        /// <param name="sQueryKey">键</param>
        /// <param name="dDefaultValue">默认值</param>
        /// <returns></returns>
        public static double GetQueryString(string sQueryKey, double dDefaultValue)
        {
            double dValue = 0;
            if (double.TryParse(GetQueryString(sQueryKey, dDefaultValue.ToString()), out dValue))
            {
                return dValue;
            }
            return dDefaultValue;
        }
        /// <summary>
        /// 获取Request.Form中的指定键的值
        /// </summary>
        /// <param name="sFormName">键</param>
        /// <param name="sDefaultValue">默认值</param>
        /// <returns></returns>
        public static string GetFormValue(string sFormName, string sDefaultValue)
        {
            if (HttpContext.Current != null && HttpContext.Current.Request.Form[sFormName] != null)
            {
                return HttpContext.Current.Request.Form[sFormName];
            }
            return sDefaultValue;
        }

        /// <summary>
        /// 获取Request.Form中的指定键的值
        /// </summary>
        /// <param name="sFormName">键</param>
        /// <param name="iDefaultValue">默认值</param>
        /// <returns></returns>
        public static int GetFormValue(string sFormName, int iDefaultValue)
        {
            int iValue = 0;
            if (Int32.TryParse(GetFormValue(sFormName, iDefaultValue.ToString()), out iValue))
            {
                return iValue;
            }
            return iDefaultValue;
        }
        #endregion

        #region 获得html中的图片的信息
        /// <summary>
        /// 获得html中的图片
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签 

            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;

        }
        #endregion

        #region 只保留P标签的存在

        /// <summary>
        /// 获得html中"<p></p>"标签中的内容
        /// </summary>
        /// <param name="sHtmlText"></param>
        /// <returns></returns>
        public static string[] GetContentbyPhtml(string sHtmlText)
        {
            // 定义正则表达式用来匹配 <p></p>之间的内容 标签 
            Regex regImg = new Regex(@"<p[^>]*>(.*?)</p>", RegexOptions.IgnoreCase);
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sContentList = new string[matches.Count];
            foreach (Match match in matches)
                sContentList[i++] = GetStringNoneHtml(match.Groups[1].Value);
            return sContentList;
        }
        #endregion


        #region 创建html文件
        /// <summary>
        /// 创建html并返回html文件地址路径
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string createhtml(object content, int configid)
        {
            string customPath = ConfigHelper.GetConfigString("contenthtmlpath", "/html/{0}/");
            Random rnd = new Random();
            string shtmlDate = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-") + rnd.NextDouble().ToString();
            string htmlPath = string.Format(customPath, configid);
            string htmlPathFile = HttpContext.Current.Server.MapPath(htmlPath);
            //判断文件目录是否存在            
            if (!System.IO.Directory.Exists(htmlPathFile))
                System.IO.Directory.CreateDirectory(htmlPathFile);

            string fileName = shtmlDate + ".html";

            string htmlFile = htmlPathFile + fileName;
            //判断文件是否存在
            if (!File.Exists(htmlFile))
            {
                File.Create(htmlFile).Close();
            }
            FileStream fs = new FileStream(htmlFile, FileMode.Append);
            byte[] data = new UTF8Encoding().GetBytes(content.ToString());
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            return htmlPath + fileName;
        }
        #endregion

        /// <summary>
        /// 生成优惠券随机数
        /// </summary>
        /// <param name="ran"></param>
        /// <param name="xLen"></param>
        /// <returns></returns>
        public static string RandomNo(Random ran, int xLen)
        {
            string[] char_array = new string[34];
            char_array[0] = "1";
            char_array[1] = "2";
            char_array[2] = "3";
            char_array[3] = "4";
            char_array[4] = "5";
            char_array[5] = "6";
            char_array[6] = "7";
            char_array[7] = "8";
            char_array[8] = "9";
            char_array[9] = "A";
            char_array[10] = "B";
            char_array[11] = "C";
            char_array[12] = "D";
            char_array[13] = "E";
            char_array[14] = "F";
            char_array[15] = "G";
            char_array[16] = "H";
            char_array[17] = "I";
            char_array[18] = "J";
            char_array[19] = "K";
            char_array[20] = "L";
            char_array[21] = "M";
            char_array[22] = "N";
            char_array[23] = "P";
            char_array[24] = "Q";
            char_array[25] = "R";
            char_array[26] = "S";
            char_array[27] = "T";
            char_array[28] = "W";
            char_array[29] = "U";
            char_array[30] = "V";
            char_array[31] = "X";
            char_array[32] = "Y";
            char_array[33] = "Z";

            string output = "";
            double tmp = 0;
            while (output.Length < xLen)
            {
                tmp = ran.NextDouble();
                output = output + char_array[(int)(tmp * 34)].ToString();
            }
            return output;
        }

        /// <summary>
        /// 获取时间的友好的提示
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetFriendlyTime(string dt)
        {
            try
            {
                TimeSpan span = DateTime.Now - Convert.ToDateTime(dt);
                if (span.TotalDays > 30)
                {
                    return string.Format("{0}个月{1}天前", (int)span.TotalDays / 30, (int)span.TotalDays % 30);
                }
                if (span.TotalDays > 1)
                {
                    return string.Format("{0}天{1}小时前", (int)Math.Floor(span.TotalDays), span.Hours);
                }
                else if (span.TotalHours > 1)
                {
                    return string.Format("{0}小时{1}分钟前", (int)Math.Floor(span.TotalHours), span.Minutes);
                }
                else if (span.TotalMinutes > 1)
                {
                    return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                }
                else if (span.TotalSeconds >= 1)
                {
                    return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取枚举的注释
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription<T>(int value) where T : new()
        {
            Type t = typeof(T);
            foreach (System.Reflection.MemberInfo mInfo in t.GetMembers())
            {
                if (mInfo.Name == t.GetEnumName(value))
                {
                    foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo))
                    {
                        if (attr.GetType() == typeof(System.ComponentModel.DescriptionAttribute))
                        {
                            return ((System.ComponentModel.DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return "";
        }

        public static bool IsMobile(string text)
        {
            return Regex.IsMatch(text, @"^1\d{10}$", RegexOptions.Compiled);
        }

        /// <summary>
        /// 载入错误信息
        /// </summary>
        /// <param name="code">ErrorPageOptions</param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static string LoadErrorNote(int code, string desc)
        {
            string file = string.Format("/resource/error_template/{0}.html", code);
            string fullfile = HttpContext.Current.Server.MapPath(file);
            if (File.Exists(fullfile))
            {
                string content = File.ReadAllText(fullfile);
                content = content.Replace("{$desc$}", desc);
                return content;
            }
            return desc;
        }

        /// <summary>
        /// 得到时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            return ((DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000).ToString();
        }

        #region 手机登录授权码相关解析
        /// <summary>
        /// 生存app 授权码
        /// </summary>
        /// <param name="customerId">商户ID</param>
        /// <param name="userid">用户ID</param>
        /// <param name="code">验证码</param>
        /// <param name="secure">app密钥</param>
        /// <returns></returns>
        public static string GetAuthorizeCodeToEncrypting(int customerId, int userid, string code, string secure)
        {
            string encryStr = string.Format("{0}|{1}|{2}|{3}", customerId, userid.ToString(), code, secure);
            return EncryptHelper.Encrypt32(encryStr, "!@&*houtu");
        }

        /// <summary>
        /// 根据app授权码获得解密后的字符串{customerid}|{mobile}|{code}|{secure}
        /// </summary>
        /// <param name="authorizeCode"></param>
        /// <returns></returns>
        public static string GetAuthorizeCodeToDecrypting(string authorizeCode)
        {
            return EncryptHelper.Decrypt32(authorizeCode, "!@&*houtu");
        }

        /// <summary>
        /// 判断是否是授权码
        /// </summary>
        /// <returns></returns>
        public static bool isAuthorizeCode(string UnionIdOrAuthor)
        {
            try
            {
                string str = GetAuthorizeCodeToDecrypting(UnionIdOrAuthor);
                if (!string.IsNullOrEmpty(str) && str.Contains('|'))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据授权码解析出商户ID
        /// </summary>
        /// <param name="authorizeCode">app授权码</param>
        /// <returns></returns>
        public static int GetCustomerID(string authorizeCode)
        {
            try
            {
                string authorize = GetAuthorizeCodeToDecrypting(authorizeCode);
                if (!string.IsNullOrEmpty(authorize) && authorize.Contains('|'))
                {
                    if (authorize.Split('|') != null && authorize.Split('|').Length > 0)
                    {
                        return Convert.ToInt32(authorize.Split('|')[0]);
                    }
                }
            }
            catch
            { 
            }
            return -1;
        }

        /// <summary>
        /// 根据授权码解析出商户ID
        /// </summary>
        /// <param name="authorizeCode">app授权码</param>
        /// <returns></returns>
        public static int GetUserID(string authorizeCode)
        {
            try
            {
                string authorize = GetAuthorizeCodeToDecrypting(authorizeCode);
                if (!string.IsNullOrEmpty(authorize) && authorize.Contains('|'))
                {
                    if (authorize.Split('|') != null && authorize.Split('|').Length > 2)
                    {
                        return Convert.ToInt32(authorize.Split('|')[1]);
                    }
                }
            }
            catch
            {
            }
            return -1;
        }

        /// <summary>
        /// 根据授权码解析出商户ID
        /// </summary>
        /// <param name="authorizeCode">app授权码</param>
        /// <returns></returns>
        public static string GetSecure(string authorizeCode)
        {
            try
            {
                string authorize = GetAuthorizeCodeToDecrypting(authorizeCode);
                if (!string.IsNullOrEmpty(authorize) && authorize.Contains('|'))
                {
                    if (authorize.Split('|') != null && authorize.Split('|').Length > 3)
                    {
                        return authorize.Split('|')[3];
                    }
                }
            }
            catch
            {
            }
            return null;
        }

        #endregion

        /// <summary>
        /// 获取访问者IP
        /// </summary>
        /// <returns></returns>
        public static string GetClientIp()
        {
            try
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)//using proxy
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();//Return real client IP.
                }
                else //not using proxy or can't get the Client IP
                {
                    return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();//While it can't get the Client IP, it will return proxy IP.
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

//newtonsoft报错，添加
namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}