using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core
{
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ReturnCode
    {
        参数错误_可能错误原因_order_status仅支持_待发货状态 = 10000,
        系统内部错误 = 50000,
        OAuth认证失败 = 20000,
        多多客业务错误 = 20001,
        错误的client_id = 20002,
        缺少签名sign字段 = 20003,
        签名sign校验失败 = 20004,
        缺少参数type = 20005,
        参数type值有误 = 20006,
        缺少必填请求参数 = 20007,
        请求参数data_type值有误 = 20008,
        缺少生成签名的secret = 20009,
        时间戳格式有误 = 20017,
        获取店铺编号失败 = 20010,
        超过调用频率限制 = 20021,
        请求方法错误_仅支持POST = 10002,
        应用不存在 = 10010,
        应用已被驳回 = 10011,
        授权已被取消 = 10014,
        client_Id不正确 = 10016,
        access_token已过期 = 10035,
        未知错误 = 50001,
        用户没有授权访问此接口 = 20031,
        调用过于频繁_请调整调用频率 = 70031,
        当前接口因系统维护_暂时下线 = 70033,
        调用过于频繁_请调整调用频率x = 70032,
        access_token已过期x = 10019
    }
}
