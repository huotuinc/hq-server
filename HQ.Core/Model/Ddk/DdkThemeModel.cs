using System;
namespace HQ.Model
{
    /// <summary>
    /// 多多客主题实体
    /// </summary>
    [Serializable]
    public partial class DdkThemeModel
    {
        public DdkThemeModel()
        { }
        #region Model
        private int _themeid;
        private string _imageurl;
        private string _name;
        private int _goodsnum;
        private DateTime? _updatetime;
        /// <summary>
        /// 多多客主题id
        /// </summary>
        public int ThemeId
        {
            set { _themeid = value; }
            get { return _themeid; }
        }
        /// <summary>
        /// 主题图片
        /// </summary>
        public string ImageUrl
        {
            set { _imageurl = value; }
            get { return _imageurl; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsNum
        {
            set { _goodsnum = value; }
            get { return _goodsnum; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}

