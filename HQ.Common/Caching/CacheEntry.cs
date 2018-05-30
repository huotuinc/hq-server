using System;
using System.Collections.Generic;
using System.Text;

namespace HQ.Common.Caching
{
    /// <summary>
    /// CommonCacheHelper中缓存实体
    /// </summary>
    public class CacheEntry
    {
        private DateTime _createTime = DateTime.Now;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return _createTime; }
            set { _createTime = value; }
        }


        private DateTime _lastUpdate;
        /// <summary>
        /// 上一次更新时间
        /// </summary>
        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        private object _content;
        /// <summary>
        /// 缓存具体值
        /// </summary>
        public object Content
        {
            get { return _content; }
            set { _content = value; }
        }

        private CacheLoaderDelegate loader;
        /// <summary>
        /// 加载委托
        /// </summary>
        public CacheLoaderDelegate CacheLoader
        {
            get { return loader; }
            set { loader = value; }
        }
	
	
    }
}
