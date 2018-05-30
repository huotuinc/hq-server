using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ViewModel
{
    public class ApiResult
    {
        public int resultCode;
        public string resultMsg;
        public object data;

        public static ApiResult resultWith(ApiResultEnum resultEnum, object data = null)
        {
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultEnum.ToString(),
                data = data
            };
        }

        public static ApiResult resultWith(ApiResultEnum resultEnum, string resultMsg, object data)
        {
            return new ApiResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultMsg,
                data = data
            };
        }

        public static ApiResult resultWith(int resultCode, string resultMsg = null,object data = null)
        {
            return new ApiResult
            {
                resultCode = resultCode,
                resultMsg = resultMsg,
                data = data
            };
        }

    }

    public enum ApiResultEnum
    {
        请求成功 = 1,
        处理失败 = 0,
        请求异常 = -1
    }
}
