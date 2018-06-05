using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HQ.Core.Model.ViewModel
{
    /// <summary>
    /// 返回JSON，一般用于后台ajax请求包装
    /// </summary>
    public class AjaxResult
    {
        public int resultCode;
        public string resultMsg;
        public object data;

        public static AjaxResult resultWith(AjaxResultEnum resultEnum, object data = null)
        {
            return new AjaxResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultEnum.ToString(),
                data = data
            };
        }

        public static AjaxResult resultWith(AjaxResultEnum resultEnum, string resultMsg, object data)
        {
            return new AjaxResult
            {
                resultCode = (int)resultEnum,
                resultMsg = resultMsg,
                data = data
            };
        }

        public static AjaxResult resultWith(int resultCode, string resultMsg = null,object data = null)
        {
            return new AjaxResult
            {
                resultCode = resultCode,
                resultMsg = resultMsg,
                data = data
            };
        }

    }

    public enum AjaxResultEnum
    {
        请求成功 = 1,
        处理失败 = 0,
        请求异常 = -1
    }
}
