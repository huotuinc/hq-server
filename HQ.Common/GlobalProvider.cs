using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HQ.Common;

namespace HQ.Common
{
    public static class GlobalProvider
    {
        #region 判断是否为空

        #region 判断字符串是否为空,返回true为空，否则不为空
        /// <summary>
        /// 判断字符串是否为空,返回true为空，否则不为空
        /// </summary>
        /// <param name="boolValue">字符串值</param>
        /// <returns></returns>
        public static bool StrIsNull(this string boolValue)
        {
            if (boolValue != null && boolValue != "" && boolValue.ToLower() != "null" && !string.IsNullOrEmpty(boolValue) && boolValue.ToString().Trim().Length != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 判断字符串是否为空,返回true为空，否则不为空
        /// <summary>
        /// 判断字符串是否为空,为空返回空字符 否则源数据返回
        /// </summary>
        /// <param name="boolValue">字符串值</param>
        /// <returns></returns>
        public static string StrToString(this object boolValue)
        {
            if (boolValue != null && boolValue.ToString() != "" && boolValue.ToString().ToLower() != "null" && boolValue.ToString() != "undefined" && !string.IsNullOrEmpty(boolValue.ToString()) && boolValue.ToString().Trim().Length != 0)
            {
                return boolValue.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion


        #region 判断数据集(DataSet)是否为空
        /// <summary>
        /// 判断数据集(DataSet)是否为空
        /// </summary>
        /// <param name="ds">数据集</param>
        /// <returns></returns>
        public static bool DsIsNull(this DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0] == null || ds.Tables[0].Columns.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断DataTable表是否为空
        /// <summary>
        /// 判断DataTable表是否为空
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public static bool DtIsNull(this DataTable dt)
        {
            if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断DataRow是否为空
        /// <summary>
        /// 判断DataRow是否为空
        /// </summary>
        /// <param name="dr">Rows行数组</param>
        /// <returns></returns>
        public static bool DRIsNull(this DataRow[] dr)
        {
            if (dr == null || dr.Length == 0 || dr[0].ItemArray.Length == 0 || dr[0].Table.Columns.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断List对象是否为空
        /// <summary>
        /// 判断List对象是否为空
        /// </summary>
        /// <param name="list">List对象</param>
        /// <returns></returns>
        public static bool ListIsNull<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断IList对象是否为空
        /// <summary>
        /// 判断IList对象是否为空
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="list">集合类型</param>
        /// <returns></returns>
        public static bool IListIsNull<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断object[]对象是否为空
        /// <summary>
        /// 判断object[]对象是否为空
        /// </summary>
        /// <param name="obj">对象数组</param>
        /// <returns></returns>
        public static bool ObjIsNull(this object[] obj)
        {
            if (obj == null || obj.Length == 0)
                return true;
            else
                return false;
        }
        #endregion

        #endregion


        /// <summary>
        /// 判断版本是否有更新
        /// </summary>
        /// <param name="version">最新版本号</param>
        /// <param name="currentVersion">当前版本号</param>
        /// <returns></returns>
        public static bool IsVersionUpdate(this string version, string currentVersion)
        {
            try
            {
                string _currentVersion = string.Empty;
                string _newVersion = string.Empty;
                //当前版本号
                var cv = currentVersion.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (cv.Length > 2 && cv.Length < 4)
                    _currentVersion = currentVersion.Remove(currentVersion.LastIndexOf("."), 1);

                //新版本号
                var nv = version.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (nv.Length > 2 && nv.Length < 4)
                    _newVersion = version.Remove(version.LastIndexOf("."), 1);
                if (Convert.ToDouble(_newVersion) <= Convert.ToDouble(_currentVersion))
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}


public static class Extends
{

    #region MD5
    /// <summary>
    /// md5加密
    /// </summary>
    /// <param name="str"></param>
    /// <param name="code">16与32位加密</param>
    /// <returns></returns>
    public static string MD5(this string str, int code = 32)
    {
        if (code == 16) //16位MD5加密（取32位加密的9~25字符）
        {
            return EncryptHelper.MD5(str).ToLower().Substring(8, 16);
        }
        if (code == 32)
        {
            return EncryptHelper.MD5(str).ToLower();
        }
        return str;
    }
    #endregion
}