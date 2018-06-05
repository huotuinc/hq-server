using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.Zone
{
    public class ZoneArticleView
    {
        public long goodsId { get; set; }//商品id
        public string head { get; set; }//发布者头像
        public string name { get; set; } //发布者名称
        public string content { get; set; }//文章内容
        public string type { get; set; }//类型：0图片1视频
        public string pictures { get; set; }//图片列表
        public string smallPictures { get; set; }//小图地址
        public string videos { get; set; }//视频地址
        public string time { get; set; }//发布时间
        public string turnAmount { get; set; }//转发次数
        public string reward { get; set; }//分享赚可得钻
        public string linkUrl { get; set; }//转链接地址
    }
}
