using System;
namespace HQ.Model
{
    /// <summary>
    /// 好券圈(分享中心)文章实体
    /// </summary>
    [Serializable]
    public partial class ShareZoneArticleModel
    {
        public ShareZoneArticleModel()
        { }
        #region Model
        private int _shareid;
        private string _sharecontent;
        private string _shareimglist;
        private DateTime _createtime;
        private int _sharecount;
        private string _goodsid;
        private decimal _promotionamount;
        private int _catid;
        private DateTime? _showtime;
        private DateTime? _hidetime;
        private string _videolist;
        private int _plattype;
        /// <summary>
        /// 自增id
        /// </summary>
        public int ShareId
        {
            set { _shareid = value; }
            get { return _shareid; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string ShareContent
        {
            set { _sharecontent = value; }
            get { return _sharecontent; }
        }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ShareImgList
        {
            set { _shareimglist = value; }
            get { return _shareimglist; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 转发次数
        /// </summary>
        public int ShareCount
        {
            set { _sharecount = value; }
            get { return _sharecount; }
        }
        /// <summary>
        /// 商品id
        /// </summary>
        public string GoodsId
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        /// <summary>
        /// 佣金
        /// </summary>
        public decimal PromotionAmount
        {
            set { _promotionamount = value; }
            get { return _promotionamount; }
        }
        /// <summary>
        /// 所属分类
        /// </summary>
        public int CatId
        {
            set { _catid = value; }
            get { return _catid; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? ShowTime
        {
            set { _showtime = value; }
            get { return _showtime; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? HideTime
        {
            set { _hidetime = value; }
            get { return _hidetime; }
        }
        /// <summary>
        /// 视频列表
        /// </summary>
        public string VideoList
        {
            set { _videolist = value; }
            get { return _videolist; }
        }
        /// <summary>
        /// 平台类型，对应枚举HQEnums.PlatformTypeOptions
        /// </summary>
        public int PlatType
        {
            set { _plattype = value; }
            get { return _plattype; }
        }
        #endregion Model

    }
}

