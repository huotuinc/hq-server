using HQ.Common;
using HQ.Core.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HQ.Service.WxTokenBuilder
{
    public partial class TokenBuildService : ServiceBase
    {
        WxTokenBuildJober jober = null;
        public TokenBuildService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LogHelper.Write("服务启动");
            try
            {
                int startDelayMinutes = Convert.ToInt32(ConfigHelper.GetConfigString("StartDelayMinutes", "5"));
                int repeatIntervalMinutes = Convert.ToInt32(ConfigHelper.GetConfigString("RepeatIntervalMinutes", "90"));
                int dueTime = startDelayMinutes * 60 * 1000;
                int cycle = repeatIntervalMinutes * 60 * 1000;
                jober = new WxTokenBuildJober();
                jober.StartJob(dueTime, cycle);
            }
            catch (Exception ex)
            {
                LogHelper.Write("服务启动异常：" + ex.Message + "|" + ex.StackTrace);
            }
        }

        protected override void OnStop()
        {
            if (jober != null)
            {
                jober.StopJob();
            }
            LogHelper.Write("服务停止");
        }
    }

    /// <summary>
    /// 定时生成作业
    /// </summary>
    public class WxTokenBuildJober
    {
        private Timer _asynTimer;
        //private int _dueTime = 5 * 60 * 1000; //启动延时时间，默认5分钟
        //private int _AsynCycle = 60 * 60 * 1000; //1小时执行1次

        /// <summary>
        /// 启动作业
        /// </summary>
        /// <param name="dueTime">第一次执行延迟秒数</param>
        /// <param name="cycle">每隔多少分钟执行</param>
        public void StartJob(int dueTime, int cycle)
        {
            _asynTimer = new Timer(new TimerCallback(delegate (object obj)
            {
                ExecuteJob();
            }), null, dueTime, cycle);
        }

        /// <summary>
        /// 停止作业
        /// </summary>
        public void StopJob()
        {
            if (_asynTimer != null)
            {
                _asynTimer.Dispose();
                _asynTimer = null;
            }
        }

        /// <summary>
        /// 执行作业
        /// </summary>
        public void ExecuteJob()
        {
            WxSecretTokenBuilder.Instance.Start();
        }
    }
}
