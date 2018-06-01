using HQ.DAL;
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
    }
}
