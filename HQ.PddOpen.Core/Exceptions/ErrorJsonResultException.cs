using HQ.PddOpen.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Exceptions
{
    public class ErrorJsonResultException : PttException
    {
        public ErrorJsonResult JsonResult { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        /// <param name="jsonResult"></param>
        /// <param name="url"></param>
        public ErrorJsonResultException(string message, Exception inner, ErrorJsonResult jsonResult, string url = null)
            : base(message, inner)
        {
            JsonResult = jsonResult;
            Url = url;

            //WeixinTrace.ErrorJsonResultExceptionLog(this);
        }
    }
}
