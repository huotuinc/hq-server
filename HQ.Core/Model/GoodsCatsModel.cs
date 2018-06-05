using System;
namespace HQ.Model
{
    /// <summary>
    /// 商品分类实体
    /// </summary>
    [Serializable]
    public partial class GoodsCatsModel
    {
        public GoodsCatsModel()
        {
            this.Status = 1;
        }
        #region Model
        private int _id;
        private int _plattype;
        private string _name;
        private int? _parentid;
        private int _level;
        private string _icon;
        private int _sortnum;
        /// <summary>
        /// 分类id
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属平台类型，对应枚举HQEnums.PlatformTypeOptions
        /// </summary>
        public int PlatType
        {
            set { _plattype = value; }
            get { return _plattype; }
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
        /// 所属上级id
        /// </summary>
        public int? ParentId
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 层次
        /// </summary>
        public int LevelNo
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon
        {
            set { _icon = value; }
            get { return _icon; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNum
        {
            set { _sortnum = value; }
            get { return _sortnum; }
        }
        /// <summary>
        /// 启用状态
        /// </summary>
        public int Status { get; set; }
        #endregion Model

    }
}

