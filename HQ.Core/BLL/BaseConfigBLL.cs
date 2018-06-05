using HQ.Common.Caching;
using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 基础配置逻辑层
    /// </summary>
    public class BaseConfigBLL
    {
        private readonly BaseConfigDAL dal = new BaseConfigDAL();
        private static BaseConfigBLL instance = new BaseConfigBLL();
        private const string CACHEDEPFILE = "/resource/cache/baseconfig.txt";
        private const string CACHEKEY = "hq_baseconfig";

        private BaseConfigBLL()
        { }

        public static BaseConfigBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
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
        /// 从缓存中获取基本配置信息
        /// </summary>
        /// <returns></returns>
        public BaseConfigModel GetModelCached()
        {
            if (HttpContext.Current != null)
            {
                BaseConfigModel model = WebCacheHelper<BaseConfigModel>.Get(CACHEKEY);
                if (model == null)
                {
                    model = dal.GetTopModel();
                    if (model == null) return null;
                    WebCacheHelper.Insert(CACHEKEY, model, new System.Web.Caching.CacheDependency(this.GetDepFile()));
                }
                return model;
            }
            else
            {
                return dal.GetTopModel();
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseConfigModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseConfigModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ConfigId)
        {
            return dal.Delete(ConfigId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseConfigModel GetModel(int ConfigId)
        {
            return dal.GetModel(ConfigId);
        }

        public BaseConfigModel GetTopModel()
        {
            return dal.GetTopModel();
        }
        #endregion  BasicMethod
    }
}
