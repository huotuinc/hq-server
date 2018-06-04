using HQ.Common.Caching;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HQ.Core.BLL.Ddk
{
    /// <summary>
    /// 多多客应用信息提供器
    /// 系统中频繁会根据应用id,代理商id等来获得应用的秘钥信息，都从该类索取
    /// </summary>
    public class DdkAppProvider
    {
        private static readonly DdkAppProvider instance = new DdkAppProvider();
        private const string CACHEDEPFILE = "/resource/cache/ddkapp.txt";
        private const string CACHEKEY = "hq_ddkapp";

        private DdkAppProvider()
        { }

        public static DdkAppProvider Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 得到缓存依赖KEY
        /// </summary>
        /// <returns></returns>
        private string GetDepFile()
        {
            string depFile = HttpContext.Current.Server.MapPath(CACHEDEPFILE);
            if (!Directory.Exists(Path.GetDirectoryName(depFile)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(depFile));
            }
            if (!File.Exists(depFile))
            {
                File.Create(depFile).Dispose();
            }
            return depFile;
        }

        /// <summary>
        /// 刷新缓存
        /// </summary>
        public void RefreshCache()
        {
            string depFile = HttpContext.Current.Server.MapPath(CACHEDEPFILE);
            File.WriteAllText(depFile, DateTime.Now.ToString());
        }

        /// <summary>
        /// 从缓存中得到字典
        /// </summary>
        /// <returns></returns>
        public List<DdkAppsModel> GetAppCacheList()
        {
            if (HttpContext.Current != null)
            {
                List<DdkAppsModel> list = WebCacheHelper<List<DdkAppsModel>>.Get(CACHEKEY);
                if (list == null)
                {
                    list = DdkAppsBLL.Instance.GetEffectList();
                    if (list == null) return null;
                    WebCacheHelper.Insert(CACHEKEY, list, new System.Web.Caching.CacheDependency(this.GetDepFile()));
                }
                return list;
            }
            else
            {
                return DdkAppsBLL.Instance.GetEffectList();
            }
        }

        /// <summary>
        /// 根据应用自增id查找
        /// </summary>
        /// <param name="appId"></param>
        /// <returns></returns>
        public DdkAppsModel GetModelByAppId(int appId)
        {
            List<DdkAppsModel> appList = this.GetAppCacheList();
            return appList.Find(p => p.AppId == appId);
        }

        /// <summary>
        /// 根据锁关联的代理商id查找
        /// </summary>
        /// <param name="agentId"></param>
        /// <returns></returns>
        public DdkAppsModel GetModelByAgentId(int agentId)
        {
            List<DdkAppsModel> appList = this.GetAppCacheList();
            return appList.Find(p => p.BindAgentId == agentId);
        }

        /// <summary>
        /// 获取默认的应用
        /// </summary>
        /// <returns></returns>
        public DdkAppsModel GetModelByDefault()
        {
            List<DdkAppsModel> appList = this.GetAppCacheList();
            return appList.Find(p => p.IsMain == 1);
        }
    }
}
