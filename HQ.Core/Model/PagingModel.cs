using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Micro.Mall.Core.Model
{
    public class PagingModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageCount { get; set; }
    }



    /// <summary>
    /// 查询内容
    /// </summary>
    public class PageQueryModel
    {
        public string TableName { get; set; }
        public string Fields { get; set; }
        public string OrderField { get; set; }
        public string SqlWhere { get; set; }
    }
}
