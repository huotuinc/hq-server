using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.Goods
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    public class GoodsCatViewModel
    {
        public string title { get; set; }
        public int categoryId { get; set; }
        public List<SubCatViewModel> child { get; set; }
    }

    public class SubCatViewModel
    {
        public string title { get; set; }
        public int categoryId { get; set; }
        public string imgSrc { get; set; }
    }
}
