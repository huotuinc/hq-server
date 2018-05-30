using HQ.Common;
using HQ.Core.Enum;
using HQ.Core.Model.ShortMessage;
using LM.Core.Model;
using LM.Core.Model.ShortMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 短信发送负责人
    /// </summary>
    public class ShortMessageDispatcher
    {
        /// <summary>
        /// 给指定会员发送短消息
        /// </summary>
        /// <param name="toMobile">发送的手机号码</param>
        /// <param name="data">消息内容</param>
        /// <param name="errmsg">错误信息</param>
        /// <returns>是否成功</returns>
        public static bool Send(string toMobile, ShortMessageBase data, out string errmsg)
        {
            errmsg = "";
            try
            {
                //1、场景获得
                HQEnums.SmsSceneOptions scene = data.GetFitedScene();

                //2、获取对应的模板消息
                ShortMessageTemplateModel configInfo = ShortMessageTemplateBLL.Instance.GetModelBySceneType((int)scene);
                if (configInfo == null)
                {
                    errmsg = "没有找到对应的配置";
                    return false;
                }

                if (configInfo.Status != 1)
                {
                    errmsg = "配置未启用";
                    return false;
                }

                string msgContent = configInfo.Template;
                if (msgContent.Trim() == "")
                {
                    errmsg = "模板为空";
                    return false;
                }

                //3、反射读取当前对象的所有属性的值，替换模板
                System.Reflection.PropertyInfo[] propertys = data.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo p in propertys)
                {
                    string name = p.Name;
                    object objval = p.GetValue(data, null);
                    msgContent = msgContent.Replace("{" + name + "}", objval == null ? "" : objval.ToString());
                }
  
                //4、发送
                SmsProviderFactory.GetSmsProvider().SendSms(toMobile, msgContent, out errmsg);
                LogHelper.Write(string.Format("SendSms-->手机:{0},发送内容:{1} {2}", toMobile, msgContent, errmsg));
                return true;
            }
            catch (Exception ex)
            {
                errmsg = string.Format("发送短信异常(ShortMessageDispatcher->Send)：{0}", ex.Message);
                return false;
            }
        }
    }
}
