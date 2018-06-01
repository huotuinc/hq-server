using HQ.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.Core.BLL
{
    /// <summary>
    /// 订单逻辑层
    /// </summary>
    public class OrdersBLL
    {
        private readonly OrdersDAL dal = new OrdersDAL();
        private static OrdersBLL instance = new OrdersBLL();
        private OrdersBLL()
        { }

        public static OrdersBLL Instance
        {
            get
            {
                return instance;
            }
        }


    }
}
