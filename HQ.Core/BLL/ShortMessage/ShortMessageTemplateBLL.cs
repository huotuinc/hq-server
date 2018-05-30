using HQ.Core.DAL.ShortMessage;
using HQ.Core.Model.ShortMessage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 短信模板管理逻辑层
    /// </summary>
    public class ShortMessageTemplateBLL
    {
        private readonly ShortMessageTemplateDAL dal = new ShortMessageTemplateDAL();
        private static ShortMessageTemplateBLL instance = new ShortMessageTemplateBLL();
        private ShortMessageTemplateBLL()
        { }

        public static ShortMessageTemplateBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ShortMessageTemplateModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ShortMessageTemplateModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {
            return dal.Delete(Id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ShortMessageTemplateModel GetModel(int Id)
        {
            return dal.GetModel(Id);
        }
        #endregion  BasicMethod

        public DataTable GetAllList()
        {
            return dal.GetAllList();
        }

        public bool Exsit(int sceneType)
        {
            return dal.Exsit(sceneType);
        }

        /// <summary>
        /// 根据场景和商户号获得模板信息
        /// </summary>
        /// <param name="sceneType"></param>
        /// <returns></returns>
        public ShortMessageTemplateModel GetModelBySceneType(int sceneType)
        {
            return dal.GetModelBySceneType(sceneType);
        }
    }
}
