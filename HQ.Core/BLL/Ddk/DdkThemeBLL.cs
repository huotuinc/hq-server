using HQ.Common;
using HQ.DAL;
using HQ.Model;
using HQ.PddOpen.Core;
using HQ.PddOpen.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.Ddk
{
    /// <summary>
    /// 多多客主题逻辑层
    /// </summary>
    public class DdkThemeBLL
    {
        private readonly DdkThemeDAL dal = new DdkThemeDAL();
        private static DdkThemeBLL instance = new DdkThemeBLL();
        private DdkThemeBLL()
        { }

        public static DdkThemeBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 从拼多多同步主题数据到数据库中
        /// </summary>
        /// <returns></returns>
        public bool Sync(out string errMsg)
        {
            errMsg = "";
            DdkAppsModel appInfo = DdkAppProvider.Instance.GetModelByDefault();
            if (appInfo == null)
            {
                errMsg = "未能找到多多客应用配置信息";
                return false;
            }

            try
            {
                int pageSize = 50;
                int page = 1;
                int curPageItemNums = pageSize;
                List<DdkThemeModel> listResult = new List<DdkThemeModel>();
                while (curPageItemNums >= pageSize)
                {
                    ThemeListJsonResult themeListJsonResult = DdkApi.GetThemeList(appInfo.ClientId, appInfo.ClientSecret, page, pageSize);
                    List<ThemeListItemEntity> themeList = themeListJsonResult.theme_list_get_response.theme_list;
                    curPageItemNums = themeList.Count;
                    foreach (ThemeListItemEntity entity in themeList)
                    {
                        listResult.Add(new DdkThemeModel()
                        {
                            GoodsNum = entity.goods_num,
                            ImageUrl = entity.image_url,
                            Name = entity.name,
                            ThemeId = (int)entity.id,
                            UpdateTime = DateTime.Now
                        });
                    }
                    page++;
                }
                dal.TruncateTable();
                foreach (DdkThemeModel model in listResult)
                {
                    this.Add(model);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.Write("DdkThemeBLL.Sync发生异常：" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(DdkThemeModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DdkThemeModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ThemeId)
        {
            return dal.Delete(ThemeId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DdkThemeModel GetModel(int ThemeId)
        {
            return dal.GetModel(ThemeId);
        }

        /// <summary>
        /// 分页获取列表
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public DataTable GetList(int pageSize, int pageIndex, out int recordCount, string keyword)
        {
            return dal.GetList(pageSize, pageIndex, out recordCount, keyword);
        }
        #endregion  BasicMethod
    }
}
