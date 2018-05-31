using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class ThemeListJsonResult : IPinduoduoJsonResult
    {
        public ThemeListEntity theme_list_get_response { get; set; }
    }

    public class ThemeListEntity
    {
        public int total { get; set; }

        public List<ThemeListItemEntity> theme_list { get; set; }
    }
    /// <summary>
    /// 主题列表对象
    /// </summary>
    public class ThemeListItemEntity
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        public long id { get; set; }
        /// <summary>
        /// 主题图片
        /// </summary>
        public string image_url { get; set; }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 主题包含的商品数量
        /// </summary>
        public int goods_num { get; set; }
    }
}
