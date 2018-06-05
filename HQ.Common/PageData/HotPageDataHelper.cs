using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Common.PageData
{
    public class HotPageDataHelper<T, E> where T : class
    {
        public static HotPageData<T> Convert(E dt, int total, int pageSize, int page, Func<E, T> converter)
        {
            HotPageData<T> data = new HotPageData<T>();
            int pageCount = total / pageSize;
            if (total % pageSize != 0)
            {
                ++pageCount;
            }
            data.Rows = converter(dt);
            data.PageCount = pageCount;
            data.Total = total;
            data.PageSize = pageSize;
            data.PageIndex = page;
            return data;
        }
    }

    public class HotPageDataHelper<T> where T : class
    {
        public static HotPageData<T> Convert(DataTable dt, int total, int pageSize, int page, Func<DataTable, T> converter)
        {
            HotPageData<T> data = new HotPageData<T>();
            int pageCount = total / pageSize;
            if (total % pageSize != 0)
            {
                ++pageCount;
            }
            data.Rows = converter(dt);
            data.PageCount = pageCount;
            data.Total = total;
            data.PageSize = pageSize;
            data.PageIndex = page;
            return data;
        }

        public static HotPageData<T> Convert(T rows, int total, int pageSize, int page)
        {
            HotPageData<T> data = new HotPageData<T>();
            int pageCount = total / pageSize;
            if (total % pageSize != 0)
            {
                ++pageCount;
            }
            data.Rows = rows;
            data.PageCount = pageCount;
            data.Total = total;
            data.PageSize = pageSize;
            data.PageIndex = page;
            return data;
        }

        public static HotPageData<DataTable> Convert(DataTable dt, int total, int pageSize, int page)
        {
            HotPageData<DataTable> data = new HotPageData<DataTable>();
            int pageCount = total / pageSize;
            if (total % pageSize != 0)
            {
                ++pageCount;
            }
            data.Rows = dt;
            data.PageCount = pageCount;
            data.Total = total;
            data.PageSize = pageSize;
            data.PageIndex = page;
            return data;
        }
    }
}
