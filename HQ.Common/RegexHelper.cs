using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HQ.Common
{
    /// <summary>
    /// 操作正则表达式的公共类
    /// </summary>    
    public class RegexHelper
    {
        #region 验证输入字符串是否与模式字符串匹配

        #region 重载1
        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>        
        public static bool IsMatch( string input, string pattern )
        {
            return IsMatch( input, pattern, RegexOptions.IgnoreCase );
        } 
        #endregion

        #region 重载2
        /// <summary>
        /// 验证输入字符串是否与模式字符串匹配，匹配返回true
        /// </summary>
        /// <param name="input">输入的字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="options">筛选条件,比如是否忽略大小写</param>
        public static bool IsMatch( string input, string pattern, RegexOptions options )
        {
            return Regex.IsMatch( input, pattern, options );
        } 
        #endregion

        #endregion        

        #region 获取匹配的值

        #region 重载1
        /// <summary>
        /// 获取匹配的值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="resultPattern">结果模式字符串,范例："$1"用来获取第一个( )内的值</param>
        /// <param name="options">筛选条件,比如是否忽略大小写</param>
        public static string GetMatchValue( string input, string pattern, string resultPattern, RegexOptions options )
        {
            //判断是否匹配
            if ( Regex.IsMatch( input, pattern, options ) )
            {
                return Regex.Match( input, pattern, options ).Result( resultPattern );
            }
            else
            {
                return string.Empty;
            }
        } 
        #endregion

        #region 重载2
        /// <summary>
        /// 获取匹配的值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        /// <param name="resultPattern">结果模式字符串,范例："$1"用来获取第一个( )内的值</param>
        public static string GetMatchValue( string input, string pattern, string resultPattern )
        {
            return GetMatchValue( input, pattern, resultPattern, RegexOptions.IgnoreCase );
        }
        #endregion

        #region 重载3
        /// <summary>
        /// 获取匹配的值
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="pattern">模式字符串</param>
        public static string GetMatchValue( string input, string pattern )
        {
            if ( Regex.IsMatch( input, pattern, RegexOptions.IgnoreCase ) )
            {
                return Regex.Match( input, pattern, RegexOptions.IgnoreCase ).Value;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #endregion
    }
}
