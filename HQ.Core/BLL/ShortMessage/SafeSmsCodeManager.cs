using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HQ.Core.BLL.ShortMessage
{
    /// <summary>
    /// 短信安全管理人
    /// 后期可改成在redis中记录
    /// </summary>
    public class SafeSmsCodeManager
    {
        private static SafeSmsCodeManager instance = new SafeSmsCodeManager();
        private int safeCodeTriggerNum = 3;
        private int frequentlySeconds = 60;

        private SafeSmsCodeManager() { }

        public static SafeSmsCodeManager Current
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// 获得发送间隔时间
        /// </summary>
        public int FrequentlySeconds
        {
            get
            {
                return frequentlySeconds;
            }
        }

        /// <summary>
        /// 是否需要触发安全码（图形验证码）
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool IsTriggerSafeCode(string mobile, int customerId)
        {
            SafeSmsCodeLog model = this.GetLog(mobile, customerId);
            if (model != null)
            {
                if (model.LastTime.Date == DateTime.Now.Date)//还是今天的
                {
                    if (model.TodaySendTimes >= safeCodeTriggerNum)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 是否属于频繁触发
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public bool IsFrequentlySend(string mobile, int customerId)
        {
            SafeSmsCodeLog model = this.GetLog(mobile, customerId);
            if (model != null)
            {
                if (DateTime.Now.Subtract(model.LastTime).TotalSeconds < frequentlySeconds)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 获取发送记录
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public SafeSmsCodeLog GetLog(string mobile, int customerId)
        {
            string key = this.GetCacheKey(mobile, customerId);
            if (HttpContext.Current.Session[key] != null)
            {
                return HttpContext.Current.Session[key] as SafeSmsCodeLog;
            }
            return null;
        }

        /// <summary>
        /// 记录发送记录
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="customerId"></param>
        public void SetLog(string mobile, int customerId)
        {
            string key = this.GetCacheKey(mobile, customerId);
            SafeSmsCodeLog model = this.GetLog(mobile, customerId);
            if (model != null)
            {
                if (model.LastTime.Date != DateTime.Now.Date)//每天清零
                {
                    model = new SafeSmsCodeLog() { LastTime = DateTime.Now, TodaySendTimes = 1 };
                }
                else
                {
                    model.TodaySendTimes += 1;
                    model.LastTime = DateTime.Now;
                }
            }
            else
            {
                model = new SafeSmsCodeLog() { LastTime = DateTime.Now, TodaySendTimes = 1 };
            }
            HttpContext.Current.Session[key] = model;
        }

        private string GetCacheKey(string mobile, int customerId)
        {
            return string.Format("SAFESMCODE_{0}_{1}", mobile, customerId);
        }
    }

    [Serializable]
    public class SafeSmsCodeLog
    {
        /// <summary>
        /// 最后一次发送时间
        /// </summary>
        public DateTime LastTime { get; set; }
        /// <summary>
        /// 今日发送次数
        /// </summary>
        public int TodaySendTimes { get; set; }
    }
}
