using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Common
{
    public class HotPageData<T>
    {
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// 页面数
        /// </summary>
        public int PageCount { set; get; }
        /// <summary>
        ///数据行对象 
        /// </summary>
        public T Rows { get; set; }
    }

}
