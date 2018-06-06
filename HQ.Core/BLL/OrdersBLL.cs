using HQ.Core.ViewModel.Order;
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
        public List<OrdersModel> GetOroderList(int PlatType, int orderStatus, int pageIndex, int pageSize, string date = "")
        {
            return dal.GetOroderList(PlatType, orderStatus, pageIndex, pageSize, date);
        }

        /// <summary>
        /// 获取我直接下线的下单数量
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int GetMyMemberOrderNum(int UserId)
        {
            return dal.GetMyMemberOrderNum(UserId);
        }

        /// <summary>
        /// 获取推广订单
        /// </summary>
        /// <param name="PlatType"></param>
        /// <param name="orderStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OrderViewModel> GetMyOrder(int PlatType, int orderStatus, int pageIndex, int pageSize, string date = "")
        {
            List<OrderViewModel> list = new List<OrderViewModel>();
            var data = this.GetOroderList(PlatType, orderStatus, pageIndex, pageSize, date);
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(new OrderViewModel()
                    {
                        orderId=item.OrderId,
                        orderAmount=item.Amount.Value,
                        goodsName=item.GoodsName,
                        orderCreateTime=item.PayTime.Value.ToString("yyyy-MM-dd"),
                        orderGroupCuccessTime=item.GroupSuccessTime.Value.ToString("yyyy-MM-dd"),
                        orderStatus=item.Status.Value,
                        imgSrc=item.GoodsThumbnailUrl,
                        promotionAmount=0 /**TODO：输出到前端的佣金，需要单独计算*/

                    });
                }
            }

            return list;
        }
    }
}
