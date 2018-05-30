using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace HQ.Common.Caching
{
    /// <summary>
    /// 缓存加载器
    /// </summary>
    /// <returns></returns>
    public delegate object CacheLoaderDelegate();

    /// <summary>
    /// 通用缓存类，适用于win/web
    /// </summary>
    public class CommonCacheHelper
    {
        private static readonly Dictionary<string, CacheEntry> _dicCache = new Dictionary<string, CacheEntry>(); //dictionary 非现线程安全 
        private static ReaderWriterLock _rwLock = new ReaderWriterLock(); //读写锁，缓存一般情况下多为读操作，写操作较少，所以选这个

        /// <summary>
        /// 返回缓存项，包括更新时间等描述
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static CacheEntry GetCacheEntry(string key)
        {
            CacheEntry entry = null;
            try
            {
                _rwLock.AcquireReaderLock(1000);
                if (Contains(key))
                {
                    entry = Instance[key];
                }
                return entry;
                //return new Exception("CacheEntry不存在，请使用 Get(string key, CacheLoaderDelegate loader)调用");
            }
            finally
            {
                _rwLock.ReleaseReaderLock();
            }
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return Instance.ContainsKey(key);
        }

        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        public static void Insert(string key, object content)
        {
            try
            {
                _rwLock.AcquireWriterLock(500);
                if (!Contains(key))
                {
                    CacheEntry entry = new CacheEntry();
                    entry.Content = content;
                    DateTime dtNow = DateTime.Now;
                    entry.CreateTime = dtNow;
                    entry.LastUpdate = dtNow;
                    entry.CacheLoader = null;                    
                    _dicCache.Add(key, entry);
                }
            }
            finally
            {
                 _rwLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// 获取缓存值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            CacheEntry entry = null;
            try
            {
                _rwLock.AcquireReaderLock(1000);
                if (Contains(key))
                {
                    entry = Instance[key];
                }
                if (entry != null)
                {
                    return entry.Content;
                }
                return new Exception("CacheEntry不存在，请使用 Get(string key, CacheLoaderDelegate loader)调用");
            }
            finally
            {
                _rwLock.ReleaseReaderLock();
            }
        }


        /// <summary>
        /// 获取缓存值重载
        /// </summary>
        /// <param name="key"></param>
        /// <param name="loader"></param>
        /// <returns></returns>
        public static object Get(string key, CacheLoaderDelegate loader)
        {
            CacheEntry entry = null;
            try
            {
                
                if (Contains(key))
                {
                    _rwLock.AcquireReaderLock(1000);
                    entry = Instance[key];
                }
                else
                {
                    entry = new CacheEntry();
                    if (loader != null)
                    {
                        _rwLock.AcquireWriterLock(500);
                        entry.Content = loader();
                        DateTime dtNow = DateTime.Now;
                        entry.CreateTime = dtNow;
                        entry.LastUpdate = dtNow;
                        entry.CacheLoader = loader;
                        _dicCache.Add(key,entry);
                    }
                }
                return entry.Content;
            }
            finally
            {
                if(_rwLock.IsReaderLockHeld)
                    _rwLock.ReleaseReaderLock();
                if (_rwLock.IsWriterLockHeld)
                    _rwLock.ReleaseWriterLock();
            }
        }

        /// <summary>
        /// 根据键值更新缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="content"></param>
        public static void Update(string key, object content)
        {
            try
            {
                if(Contains(key))
                {
                    _rwLock.AcquireWriterLock(500);
                    _dicCache[key].Content = content;
                    _dicCache[key].LastUpdate = DateTime.Now;
                }
            }
            finally
            {
                if (_rwLock.IsWriterLockHeld)
                {
                    _rwLock.ReleaseWriterLock();
                }
            }
        }

        /// <summary>
        /// 根据键值移除缓存
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            try
            {
                if (Contains(key))
                {
                    _rwLock.AcquireWriterLock(500);
                    _dicCache.Remove(key);
                }
            }
            finally
            {
                if (_rwLock.IsWriterLockHeld)
                {
                    _rwLock.ReleaseWriterLock();
                }
            }
            
        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        /// <returns></returns>
        public static bool Clear()
        {
            if (_dicCache.Count == 0)
            {
                try
                {
                    _rwLock.AcquireWriterLock(500);
                    _dicCache.Clear();
                    return true;
                }
                finally
                {
                    _rwLock.ReleaseWriterLock();
                }
            }
            return false;

        }

        /// <summary>
        /// 返回缓存字典
        /// </summary>
        public static Dictionary<string, CacheEntry> Instance
        {
            get
            {
                return _dicCache;
            }
        }

        

    }
}
