using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class ThemeGoodsSearchJsonResult : IPinduoduoJsonResult
    {
        public ThemeGoodsSearchEntity theme_list_get_response { get; set; }
    }

    public class ThemeGoodsSearchEntity
    {
        public int total { get; set; }

        public List<GoodsDetailItemEntity> goods_list { get; set; }
    }
}
