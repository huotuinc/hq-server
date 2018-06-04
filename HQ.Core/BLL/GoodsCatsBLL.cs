using HQ.Core.Enum;
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

namespace HQ.Core.BLL
{
    /// <summary>
    /// 商品分类逻辑层
    /// </summary>
    public class GoodsCatsBLL
    {
        private readonly GoodsCatsDAL dal = new GoodsCatsDAL();
        private static GoodsCatsBLL instance = new GoodsCatsBLL();
        private GoodsCatsBLL()
        { }

        public static GoodsCatsBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        public List<GoodsCatsModel> GetCats(string clientId, string clientSecret)
        {
            List<GoodsCatsModel> rootList = new List<GoodsCatsModel>();
            this.GetListByDdkApi(clientId, clientSecret, 0, rootList);

            List<GoodsCatsModel> subList = new List<GoodsCatsModel>();
            foreach (GoodsCatsModel cat in rootList)
            {
                this.GetListByDdkApi(clientId, clientSecret, cat.Id, subList);
            }

            foreach (GoodsCatsModel cat in subList)
            {
                rootList.Add(cat);
            }
            return rootList;
        }

        public void GetListByDdkApi(string clientId, string clientSecret, int parentId, List<GoodsCatsModel> goodsCatList)
        {
            GoodsTagCatJsonResult catJsonResult = DdkApi.GetGoodsTagCatList(clientId, clientSecret, parentId);
            foreach (GoodsTagCateEntity cat in catJsonResult.goods_opt_get_response.goods_opt_list)
            {
                goodsCatList.Add(new GoodsCatsModel()
                {
                    Icon = "",
                    Id = cat.opt_id,
                    LevelNo = cat.level,
                    Name = cat.opt_name,
                    ParentId = cat.parent_opt_id,
                    SortNum = 0,
                    PlatType = (int)HQEnums.PlatformTypeOptions.拼多多
                });
            }
        }

        /// <summary>
        /// 获取某个商户的所有分类（已经按树形排序）
        /// </summary>
        /// <returns></returns>
        public List<GoodsCatsModel> GetSortedList(int platType)
        {
            List<GoodsCatsModel> allCates = dal.GetList(platType);

            //step1:找出根目录
            List<GoodsCatsModel> lstRootCates = allCates.FindAll(p => p.ParentId == 0);

            //step2:递归查找各自子集
            List<GoodsCatsModel> sortedListFinal = new List<GoodsCatsModel>();
            foreach (GoodsCatsModel model in lstRootCates)
            {
                sortedListFinal.Add(model);
                GetNode(model, allCates, sortedListFinal);
            }
            return sortedListFinal;
        }

        /// <summary>
        /// 递归排序
        /// </summary>
        /// <param name="model"></param>
        /// <param name="allCates"></param>
        /// <param name="sortedListFinal"></param>
        private void GetNode(GoodsCatsModel model, List<GoodsCatsModel> allCates, List<GoodsCatsModel> sortedListFinal)
        {
            List<GoodsCatsModel> lstFinds = allCates.FindAll(p => p.ParentId == model.Id);
            foreach (GoodsCatsModel m in lstFinds)
            {
                sortedListFinal.Add(m);
                GetNode(m, allCates, sortedListFinal);
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(GoodsCatsModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(GoodsCatsModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id, int PlatType)
        {
            return dal.Delete(Id, PlatType);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoodsCatsModel GetModel(int Id, int PlatType)
        {
            return dal.GetModel(Id, PlatType);
        }


        public DataTable GetListScheme()
        {
            return dal.GetListScheme();
        }

        /// <summary>
        /// 交换排序
        /// </summary>
        /// <param name="catId">分类id</param>
        /// <param name="platType">平台类型</param>
        /// <param name="type">1：下移；2：上移</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns></returns>
        public bool SwapPosition(int catId, int platType, int type, out string errMsg)
        {
            errMsg = "";
            GoodsCatsModel current = dal.GetModel(catId, platType);
            GoodsCatsModel swapInfo = null;
            if (type == 1)
            {
                swapInfo = dal.GetNext(current.SortNum, platType);
                errMsg = "已到底部";
            }
            else
            {
                swapInfo = dal.GetPrev(current.SortNum, platType);
                errMsg = "已到顶部";
            }
            if (swapInfo == null)
            {
                return false;
            }
            int curSort = current.SortNum;
            int swapSort = swapInfo.SortNum;
            current.SortNum = swapSort;
            swapInfo.SortNum = curSort;

            this.Update(current);
            this.Update(swapInfo);
            return true;
        }
        #endregion  BasicMethod
    }
}
