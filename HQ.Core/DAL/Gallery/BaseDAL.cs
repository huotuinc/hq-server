using HQ.Common;
using HQ.Common.DB;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HQ.Core.DAL.Gallery
{
    /// <summary>
    /// Description:分页基类
    /// Author:xhl
    /// Time:2015/06/16
    /// </summary>
    public class BaseDAL
    {
        /// <summary>
        /// 分页获取PageData对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public HotPageData<DataTable> getPageData(string sql, int page, int pageSize)
        {
            HotPageData<DataTable> data = new HotPageData<DataTable>();
            int pageCount = 0;//页码数
            int maxCount = 0;//总记录数
            DataTable table = DbHelperSQL.GetSplitDataTable(sql, pageSize, page, out maxCount);
            if (table != null && table.Rows.Count > 0)
            {
                pageCount = maxCount / pageSize;
                if (maxCount % pageSize != 0)
                {
                    ++pageCount;
                }
            }
            data.Rows = table;
            data.PageCount = pageCount;
            data.Total = maxCount;
            data.PageSize = pageSize;
            data.PageIndex = page;
            return data;
        }

        /// <summary>
        /// 根据Sql语句获取Json
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string getJson(string sql, int page, int pageSize)
        {
            HotPageData<DataTable> data = this.getPageData(sql, page, pageSize);
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(data, timeConverter);
        }
    }
}
