using HQ.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ViewModel
{
    /// <summary>
    /// API接口返回实体
    /// </summary>
    public class ApiResult
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


        public static ApiResult ResultWith(HQEnums.ResultOptionType optionType, string msg, object data)
        {
            return new ApiResult() { code = (int)optionType, msg = msg, data = data };
        }

        public static ApiResult ResultWith(HQEnums.ResultOptionType optionType, object data)
        {
            return new ApiResult() { code = (int)optionType, msg = optionType.ToString(), data = data };
        }

        public static ApiResult ResultWith(HQEnums.ResultOptionType optionType)
        {
            return new ApiResult() { code = (int)optionType, msg = optionType.ToString(), data = null };
        }

        public ApiResult() { }

        public ApiResult(int code, string msg, object data = null)
        {
            this.code = code;
            this.msg = msg;
            this.data = data;
        }

        public ApiResult(HQEnums.ResultOptionType optionType, string msg, object data)
        {
            this.code = (int)optionType;
            this.msg = msg;
            this.data = data;
        }

        public ApiResult(HQEnums.ResultOptionType optionType, object data = null)
        {
            this.code = (int)optionType;
            this.msg = optionType.ToString();
            this.data = data;
        }

        public ApiResult(HQEnums.ResultOptionType optionType)
        {
            this.code = (int)optionType;
            this.msg = optionType.ToString();
            this.data = null;
        }
    }
}
