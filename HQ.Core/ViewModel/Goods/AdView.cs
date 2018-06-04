using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.ViewModel.Goods
{
    public class AdView
    {
        public int adType { get; set; }//1、首页轮播图2、四宫格推广3、主题4、外链
        public string pictureUrl { get; set; }//图片
        public string linkdata { get; set; }// 跳转地址或商品id或主题id
        public int linktype { get; set; }//链接类型：0：商品详情 1：商品列表 2：主题商品列表
    }
}
