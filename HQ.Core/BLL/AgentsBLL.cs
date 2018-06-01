using HQ.DAL;
using HQ.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 代理商逻辑层
    /// </summary>
    public class AgentsBLL
    {
        private readonly AgentsDAL dal = new AgentsDAL();
        private static AgentsBLL instance = new AgentsBLL();
        private AgentsBLL()
        { }

        public static AgentsBLL Instance
        {
            get
            {
                return instance;
            }
        }

        #region  
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AgentsModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(AgentsModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int AgentId)
        {
            return dal.Delete(AgentId);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AgentsModel GetModel(int AgentId)
        {
            return dal.GetModel(AgentId);
        }

        #endregion  
    }
}
