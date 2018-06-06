using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HQ.Common.DB;
using HQ.Model;
using System.Collections.Generic;
using HQ.Common;
using Micro.Mall.Core.DAL;
using Micro.Mall.Core.Model;

namespace HQ.DAL
{
    /// <summary>
    /// 订单数据访问层
    /// </summary>
    public partial class OrdersDAL
    {
        public OrdersDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(HQ.Model.OrdersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HQ_Orders(");
            strSql.Append("OrderId,OrderSn,PayTime,Status,StatusDesc,GroupSuccessTime,ReceiveTime,OrderType,ModifyTime,PromotionAmount,Amount,GoodsPrice,GoodsQuantity,GoodsThumbnailUrl,GoodsName,GoodsId,PId,CustomParameters,UserId,AgentId,PlatType)");
            strSql.Append(" values (");
            strSql.Append("@OrderId,@OrderSn,@PayTime,@Status,@StatusDesc,@GroupSuccessTime,@ReceiveTime,@OrderType,@ModifyTime,@PromotionAmount,@Amount,@GoodsPrice,@GoodsQuantity,@GoodsThumbnailUrl,@GoodsName,@GoodsId,@PId,@CustomParameters,@UserId,@AgentId,@PlatType)");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar,35),
                    new SqlParameter("@OrderSn", SqlDbType.VarChar,35),
                    new SqlParameter("@PayTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@StatusDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@GroupSuccessTime", SqlDbType.DateTime),
                    new SqlParameter("@ReceiveTime", SqlDbType.DateTime),
                    new SqlParameter("@OrderType", SqlDbType.SmallInt,2),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@PromotionAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsQuantity", SqlDbType.Int,4),
                    new SqlParameter("@GoodsThumbnailUrl", SqlDbType.VarChar,300),
                    new SqlParameter("@GoodsName", SqlDbType.VarChar,500),
                    new SqlParameter("@GoodsId", SqlDbType.VarChar,50),
                    new SqlParameter("@PId", SqlDbType.VarChar,30),
                    new SqlParameter("@CustomParameters", SqlDbType.VarChar,30),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@AgentId", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderSn;
            parameters[2].Value = model.PayTime;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.StatusDesc;
            parameters[5].Value = model.GroupSuccessTime;
            parameters[6].Value = model.ReceiveTime;
            parameters[7].Value = model.OrderType;
            parameters[8].Value = model.ModifyTime;
            parameters[9].Value = model.PromotionAmount;
            parameters[10].Value = model.Amount;
            parameters[11].Value = model.GoodsPrice;
            parameters[12].Value = model.GoodsQuantity;
            parameters[13].Value = model.GoodsThumbnailUrl;
            parameters[14].Value = model.GoodsName;
            parameters[15].Value = model.GoodsId;
            parameters[16].Value = model.PId;
            parameters[17].Value = model.CustomParameters;
            parameters[18].Value = model.UserId;
            parameters[19].Value = model.AgentId;
            parameters[20].Value = model.PlatType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(HQ.Model.OrdersModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HQ_Orders set ");
            strSql.Append("OrderId=@OrderId,");
            strSql.Append("OrderSn=@OrderSn,");
            strSql.Append("PayTime=@PayTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("StatusDesc=@StatusDesc,");
            strSql.Append("GroupSuccessTime=@GroupSuccessTime,");
            strSql.Append("ReceiveTime=@ReceiveTime,");
            strSql.Append("OrderType=@OrderType,");
            strSql.Append("ModifyTime=@ModifyTime,");
            strSql.Append("PromotionAmount=@PromotionAmount,");
            strSql.Append("Amount=@Amount,");
            strSql.Append("GoodsPrice=@GoodsPrice,");
            strSql.Append("GoodsQuantity=@GoodsQuantity,");
            strSql.Append("GoodsThumbnailUrl=@GoodsThumbnailUrl,");
            strSql.Append("GoodsName=@GoodsName,");
            strSql.Append("GoodsId=@GoodsId,");
            strSql.Append("PId=@PId,");
            strSql.Append("CustomParameters=@CustomParameters,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("AgentId=@AgentId,");
            strSql.Append("PlatType=@PlatType");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
                    new SqlParameter("@OrderId", SqlDbType.VarChar,35),
                    new SqlParameter("@OrderSn", SqlDbType.VarChar,35),
                    new SqlParameter("@PayTime", SqlDbType.DateTime),
                    new SqlParameter("@Status", SqlDbType.SmallInt,2),
                    new SqlParameter("@StatusDesc", SqlDbType.VarChar,50),
                    new SqlParameter("@GroupSuccessTime", SqlDbType.DateTime),
                    new SqlParameter("@ReceiveTime", SqlDbType.DateTime),
                    new SqlParameter("@OrderType", SqlDbType.SmallInt,2),
                    new SqlParameter("@ModifyTime", SqlDbType.DateTime),
                    new SqlParameter("@PromotionAmount", SqlDbType.Decimal,9),
                    new SqlParameter("@Amount", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsPrice", SqlDbType.Decimal,9),
                    new SqlParameter("@GoodsQuantity", SqlDbType.Int,4),
                    new SqlParameter("@GoodsThumbnailUrl", SqlDbType.VarChar,300),
                    new SqlParameter("@GoodsName", SqlDbType.VarChar,500),
                    new SqlParameter("@GoodsId", SqlDbType.VarChar,50),
                    new SqlParameter("@PId", SqlDbType.VarChar,30),
                    new SqlParameter("@CustomParameters", SqlDbType.VarChar,30),
                    new SqlParameter("@UserId", SqlDbType.Int,4),
                    new SqlParameter("@AgentId", SqlDbType.Int,4),
                    new SqlParameter("@PlatType", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.OrderId;
            parameters[1].Value = model.OrderSn;
            parameters[2].Value = model.PayTime;
            parameters[3].Value = model.Status;
            parameters[4].Value = model.StatusDesc;
            parameters[5].Value = model.GroupSuccessTime;
            parameters[6].Value = model.ReceiveTime;
            parameters[7].Value = model.OrderType;
            parameters[8].Value = model.ModifyTime;
            parameters[9].Value = model.PromotionAmount;
            parameters[10].Value = model.Amount;
            parameters[11].Value = model.GoodsPrice;
            parameters[12].Value = model.GoodsQuantity;
            parameters[13].Value = model.GoodsThumbnailUrl;
            parameters[14].Value = model.GoodsName;
            parameters[15].Value = model.GoodsId;
            parameters[16].Value = model.PId;
            parameters[17].Value = model.CustomParameters;
            parameters[18].Value = model.UserId;
            parameters[19].Value = model.AgentId;
            parameters[20].Value = model.PlatType;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HQ_Orders ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HQ.Model.OrdersModel GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from HQ_Orders ");
            strSql.Append(" where ");
            SqlParameter[] parameters = {
            };

            HQ.Model.OrdersModel model = new HQ.Model.OrdersModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public HQ.Model.OrdersModel DataRowToModel(DataRow row)
        {
            HQ.Model.OrdersModel model = new HQ.Model.OrdersModel();
            if (row != null)
            {
                if (row["OrderId"] != null)
                {
                    model.OrderId = row["OrderId"].ToString();
                }
                if (row["OrderSn"] != null)
                {
                    model.OrderSn = row["OrderSn"].ToString();
                }
                if (row["PayTime"] != null && row["PayTime"].ToString() != "")
                {
                    model.PayTime = DateTime.Parse(row["PayTime"].ToString());
                }
                if (row["Status"] != null && row["Status"].ToString() != "")
                {
                    model.Status = int.Parse(row["Status"].ToString());
                }
                if (row["StatusDesc"] != null)
                {
                    model.StatusDesc = row["StatusDesc"].ToString();
                }
                if (row["GroupSuccessTime"] != null && row["GroupSuccessTime"].ToString() != "")
                {
                    model.GroupSuccessTime = DateTime.Parse(row["GroupSuccessTime"].ToString());
                }
                if (row["ReceiveTime"] != null && row["ReceiveTime"].ToString() != "")
                {
                    model.ReceiveTime = DateTime.Parse(row["ReceiveTime"].ToString());
                }
                if (row["OrderType"] != null && row["OrderType"].ToString() != "")
                {
                    model.OrderType = int.Parse(row["OrderType"].ToString());
                }
                if (row["ModifyTime"] != null && row["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(row["ModifyTime"].ToString());
                }
                if (row["PromotionAmount"] != null && row["PromotionAmount"].ToString() != "")
                {
                    model.PromotionAmount = decimal.Parse(row["PromotionAmount"].ToString());
                }
                if (row["Amount"] != null && row["Amount"].ToString() != "")
                {
                    model.Amount = decimal.Parse(row["Amount"].ToString());
                }
                if (row["GoodsPrice"] != null && row["GoodsPrice"].ToString() != "")
                {
                    model.GoodsPrice = decimal.Parse(row["GoodsPrice"].ToString());
                }
                if (row["GoodsQuantity"] != null && row["GoodsQuantity"].ToString() != "")
                {
                    model.GoodsQuantity = int.Parse(row["GoodsQuantity"].ToString());
                }
                if (row["GoodsThumbnailUrl"] != null)
                {
                    model.GoodsThumbnailUrl = row["GoodsThumbnailUrl"].ToString();
                }
                if (row["GoodsName"] != null)
                {
                    model.GoodsName = row["GoodsName"].ToString();
                }
                if (row["GoodsId"] != null)
                {
                    model.GoodsId = row["GoodsId"].ToString();
                }
                if (row["PId"] != null)
                {
                    model.PId = row["PId"].ToString();
                }
                if (row["CustomParameters"] != null)
                {
                    model.CustomParameters = row["CustomParameters"].ToString();
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["AgentId"] != null && row["AgentId"].ToString() != "")
                {
                    model.AgentId = int.Parse(row["AgentId"].ToString());
                }
                if (row["PlatType"] != null && row["PlatType"].ToString() != "")
                {
                    model.PlatType = int.Parse(row["PlatType"].ToString());
                }
            }
            return model;
        }

        #endregion  BasicMethod


        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="PlatType"></param>
        /// <param name="orderStatus"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OrdersModel> GetOroderList(int PlatType, int orderStatus, int pageIndex, int pageSize, string date)
        {
            string sqlWhere = "PlatType=" + PlatType;
            if (orderStatus != 0)
            {
                sqlWhere += " and Status=" + orderStatus;
            }
            if (!string.IsNullOrEmpty(date) || date.Equals("不限"))
            {
                DateTime startDate, endData;
                string time = string.Format("{0}-01 00:00:00", date);
                if (DateTime.TryParse(time, out startDate))
                {
                    endData = startDate.AddMonths(1);
                    sqlWhere += string.Format(" and PayTime>='{0}' and PayTime<='{1}'", startDate, endData);
                }
            }

            //初始化分页
            PagingModel paging = new PagingModel()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = 0,
                PageCount = 0
            };
            PageQueryModel pageQuery = new PageQueryModel()
            {
                TableName = "HQ_Orders with(nolock)",
                Fields = "OrderId,OrderSn,PayTime,Status,StatusDesc,GroupSuccessTime,ReceiveTime,OrderType,ModifyTime,PromotionAmount,Amount,GoodsPrice,GoodsQuantity,GoodsThumbnailUrl,GoodsName,GoodsId,PId,CustomParameters,UserId,AgentId,PlatType",
                OrderField = "PayTime desc",
                SqlWhere = sqlWhere
            };

            return new CommonPageDAL().GetPageData<OrdersModel>(ConfigHelper.MssqlDBConnectionString_Sync, pageQuery, paging);

        }
    }
}

