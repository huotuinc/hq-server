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
    /// 订单逻辑层
    /// </summary>
    public class OrdersBLL
    {
        private readonly OrdersDAL dal = new OrdersDAL();
        private static OrdersBLL instance = new OrdersBLL();

        public static OrdersBLL Instance { get => instance; set => instance = value; }

        private OrdersBLL()
        { }        
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="PlatType"></param>
        /// <param name="orderStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OrdersModel> GetOroderList(int PlatType, int orderStatus, int pageIndex, int pageSize, string date="")
        {
            return dal.GetOroderList(PlatType, orderStatus, pageIndex, pageSize, date);
        }



    }
}
