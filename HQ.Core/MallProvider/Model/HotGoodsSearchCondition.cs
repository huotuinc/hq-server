using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.MallProvider.Model
{
    public class HotGoodsSearchCondition
    {
        public string Keyword { get; set; }
        public int SortType { get; set; }
        public int pageSize { get; set; }
        public int page { get; set; }
    }
}
