using HQ.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ViewModel
{
    /// <summary>
    /// Description:数据请求返回数据实体类
    /// Author:xhl
    /// Time:2015/06/16
    /// </summary>
    public class ResultStatus
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int code { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { set; get; }

        /// <summary>
        /// 数据对象
        /// </summary>
        public object data { set; get; }

        public ResultStatus() { }

        public ResultStatus(int code, string msg, object data = null)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public ResultStatus(HQEnums.ResultOptionType optionType, string msg, object data)
        {
            this.code = (int)optionType;
            this.msg = msg;
            this.data = data;
        }

        public ResultStatus(HQEnums.ResultOptionType optionType, object data = null)
        {
            this.code = (int)optionType;
            this.msg = optionType.ToString();
            this.data = data;
        }

        public ResultStatus(HQEnums.ResultOptionType optionType)
        {
            this.code = (int)optionType;
            this.msg = optionType.ToString();
            this.data = null;
        }
    }
    /// <summary>
    /// Description:数据请求返回数据实体类
    /// Author:guomw
    /// Time:2015/08/04
    /// </summary>
    public class ResultModel
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int recordCount { get; set; }
        private object _resultData = new object();
        public object resultData
        {
            get { return _resultData; }
            set { _resultData = value; }
        }
    }
}
