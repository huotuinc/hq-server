using HQ.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 搜索条件容器
    /// 一般用于后台在列表筛选后，对结果进行导出时保存获取筛选条件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HQSearchContext<T> where T : class, ISearchCondition
    {
        /// <summary>
        /// 保存条件
        /// </summary>
        /// <param name="searchCondtion"></param>
        public static void SetCondtion(T searchCondtion)
        {
            HttpContext.Current.Session[GetSearchCondtionKey()] = searchCondtion;
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        /// <returns></returns>
        public static T GetCondtion()
        {
            if (HttpContext.Current.Session[GetSearchCondtionKey()] != null)
            {
                T searchCondtion = HttpContext.Current.Session[GetSearchCondtionKey()] as T;
                return searchCondtion;
            }
            return null;
        }

        private static string GetSearchCondtionKey()
        {
            return "hq_" + typeof(T).Name;
        }
    }
}
