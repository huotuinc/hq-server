using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.Model
{
    public class GoodsCatsSearchCondition : ISearchCondition
    {
        public int ParentId { get; set; }
        public int PlatType { get; set; }
    }
}
