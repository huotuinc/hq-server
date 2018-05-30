using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace HQ.Common
{
    public class LogHelper
    {
        private LogHelper() { }
        private static Object FileObject = new object();

        private static Object FileObject_Success = new object();
        private static Object FileObject_Error = new object();

        #region 写日志
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="content"></param>
        public static void Write(object content)
        {
            string sLogDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logPath = "Log";
            string logPathFull = null;
            if (HttpContext.Current != null)
            {
                logPath = Path.DirectorySeparatorChar + logPath;
                logPathFull = HttpContext.Current.Server.MapPath(logPath);
            }
            else//非web情况下使用
            {
                logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
            }

            //判断文件目录是否存在
            if (!System.IO.Directory.Exists(logPathFull))
                System.IO.Directory.CreateDirectory(logPathFull);

            string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            //判断文件是否存在
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }
            lock (FileObject)
            {
                FileStream fs = new FileStream(logFile, FileMode.Append);
                StringBuilder sw = new StringBuilder();
                sw.AppendLine("**************************************************");
                sw.AppendLine("添加日期：" + sLogDate);
                sw.AppendLine("日志信息：" + content);
                sw.AppendLine("**************************************************");
                byte[] data = new UTF8Encoding().GetBytes(sw.ToString());
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
            }
        }


        /// <summary>
        /// 写入成功日志
        /// </summary>
        /// <param name="content">写入内容</param>        
        /// <param name="IsCreateHoursLogFile">是否创建按小时记录的日志文件，默认为false</param>        
        /// <param name="IsCreateDayFolder">是否创建以当天日期为名称的文件夹,默认为false</param>
        /// <param name="prefix">日志文件前缀，默认Success_</param>
        public static void WriteSuccess(object content, bool IsCreateHoursLogFile = false, bool IsCreateDayFolder = true, string prefix = "Success_")
        {
            lock (FileObject_Success)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    string sLogDate = date.ToString("yyyy-MM-dd HH:mm:ss");
                    string logPath = "Log";
                    if (IsCreateDayFolder)
                        logPath += "/" + date.ToString("yyyy-MM-dd");
                    string logPathFull = null;
                    if (System.Web.HttpContext.Current != null)
                    {
                        logPath = Path.DirectorySeparatorChar + logPath;
                        logPathFull = System.Web.HttpContext.Current.Server.MapPath(logPath);
                    }
                    else//非web情况下使用
                    {
                        logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
                    }

                    //判断文件目录是否存在
                    if (!System.IO.Directory.Exists(logPathFull))
                        System.IO.Directory.CreateDirectory(logPathFull);
                    string logFileName = "";
                    if (IsCreateDayFolder)
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("HH") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }
                    else
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("yyyy-MM-dd-HH") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }

                    string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + prefix + logFileName;

                    //判断文件是否存在
                    if (!File.Exists(logFile))
                    {
                        File.Create(logFile).Close();
                    }
                    StreamWriter rw = new StreamWriter(logFile, true, System.Text.Encoding.Default);
                    rw.WriteLine(string.Format(@"{0},{1} INFO {2}", date.ToString(), date.Millisecond, content));
                    rw.Flush();
                    rw.Close();
                }
                catch (Exception) { }
            }
        }
        /// <summary>
        /// 写入成功日志
        /// </summary>
        /// <param name="content">写入内容</param>        
        /// <param name="prefix">日志文件前缀，默认Success_</param>
        public static void WriteSuccess(object content, string prefix)
        {
            lock (FileObject_Success)
            {
                try
                {
                    bool IsCreateHoursLogFile = false;
                    bool IsCreateDayFolder = true;
                    DateTime date = DateTime.Now;
                    string sLogDate = date.ToString("yyyy-MM-dd HH:mm:ss");
                    string logPath = "Log";
                    if (IsCreateDayFolder)
                        logPath += "/" + date.ToString("yyyy-MM-dd");
                    string logPathFull = null;
                    if (System.Web.HttpContext.Current != null)
                    {
                        logPath = Path.DirectorySeparatorChar + logPath;
                        logPathFull = System.Web.HttpContext.Current.Server.MapPath(logPath);
                    }
                    else//非web情况下使用
                    {
                        logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
                    }

                    //判断文件目录是否存在
                    if (!System.IO.Directory.Exists(logPathFull))
                        System.IO.Directory.CreateDirectory(logPathFull);
                    string logFileName = "";
                    if (IsCreateDayFolder)
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("HH") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }
                    else
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("yyyy-MM-dd-HH") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }

                    string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + prefix + logFileName;

                    //判断文件是否存在
                    if (!File.Exists(logFile))
                    {
                        File.Create(logFile).Close();
                    }
                    StreamWriter rw = new StreamWriter(logFile, true, System.Text.Encoding.Default);
                    rw.WriteLine(string.Format(@"{0},{1} INFO {2}", date.ToString(), date.Millisecond, content));
                    rw.Flush();
                    rw.Close();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// 写入错误日志
        /// </summary>
        /// <param name="content">写入内容</param>
        /// <param name="IsCreateHoursLogFile">是否创建按小时记录的日志文件，默认为false</param>        
        /// <param name="IsCreateDayFolder">是否创建以当天日期为名称的文件夹,默认为true</param>
        /// <param name="prefix">日志文件前缀，默认Error_</param>
        public static void WriteError(object content, bool IsCreateHoursLogFile = false, bool IsCreateDayFolder = true, string prefix = "Error_")
        {
            lock (FileObject_Error)
            {
                try
                {
                    DateTime date = DateTime.Now;
                    string sLogDate = date.ToString("yyyy-MM-dd HH:mm:ss");
                    string logPath = "Log";
                    if (IsCreateDayFolder)
                        logPath += "/" + date.ToString("yyyy-MM-dd");
                    string logPathFull = null;
                    if (System.Web.HttpContext.Current != null)
                    {
                        logPath = Path.DirectorySeparatorChar + logPath;
                        logPathFull = System.Web.HttpContext.Current.Server.MapPath(logPath);
                    }
                    else//非web情况下使用
                    {
                        logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
                    }

                    //判断文件目录是否存在
                    if (!System.IO.Directory.Exists(logPathFull))
                        System.IO.Directory.CreateDirectory(logPathFull);
                    string logFileName = "";
                    if (IsCreateDayFolder)
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("HH-mm-dd") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }
                    else
                    {
                        if (IsCreateHoursLogFile)
                            logFileName = date.ToString("yyyy-MM-dd-HH") + ".log";
                        else
                            logFileName = date.ToString("yyyy-MM-dd") + ".log";
                    }

                    string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + prefix + logFileName;

                    //判断文件是否存在
                    if (!File.Exists(logFile))
                    {
                        File.Create(logFile).Close();
                    }
                    StreamWriter rw = new StreamWriter(logFile, true, System.Text.Encoding.Default);
                    rw.WriteLine(string.Format(@"{0},{1} ERROR {2}", date.ToString(), date.Millisecond, content));
                    rw.Flush();
                    rw.Close();

                }
                catch (Exception) { }
            }
        }
        #endregion



        #region 20150727
        private static Object LogDebugObject = null;
        private static Object LogInfoObject = null;
        private static Object LogErrorObject = null;

        /// <summary>
        /// debug日志  只在debug环境下输出
        /// </summary>
        /// <param name="content"></param>
        public static void Debug(object content)
        {
            #if DEBUG
            if (LogDebugObject == null)
                LogDebugObject = new object();
            lock (LogDebugObject)
            {
                WriteLog("DEBUG", content);
            }
            #endif
        }

        /// <summary>
        /// Info日志
        /// </summary>
        /// <param name="content"></param>
        public static void Info(object content)
        {
            if (LogInfoObject == null)
                LogInfoObject = new object();
            lock (LogInfoObject)
            {
                WriteLog("INFO", content);
            }
        }
        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="content"></param>
        public static void Error(object content)
        {
            if (LogErrorObject == null)
                LogErrorObject = new object();
            lock (LogErrorObject)
            {
                WriteLog("ERROR", content);
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="content"></param>
        private static void WriteLog(string tag, object content)
        {
            DateTime date = DateTime.Now;
            string sLogDate = date.ToString("yyyy-MM-dd HH:mm:ss");
            string logPath = "Log";
            string logPathFull = null;
            if (HttpContext.Current != null)
            {
                logPath = Path.DirectorySeparatorChar + logPath;
                logPathFull = HttpContext.Current.Server.MapPath(logPath);
            }
            else//非web情况下使用
            {
                logPathFull = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logPath);
            }

            //判断文件目录是否存在
            if (!System.IO.Directory.Exists(logPathFull))
                System.IO.Directory.CreateDirectory(logPathFull);

            string logFile = logPathFull + System.IO.Path.DirectorySeparatorChar.ToString() + date.ToString("yyyy-MM-dd") + "-" + tag + ".log";

            //判断文件是否存在
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Close();
            }
            StreamWriter rw = new StreamWriter(logFile, true, System.Text.Encoding.UTF8);
            rw.WriteLine(string.Format(@"{0},{1} {2} {3}", date.ToString(), date.Millisecond, tag, content));
            rw.Flush();
            rw.Close();
        } 
        #endregion
    }
}
