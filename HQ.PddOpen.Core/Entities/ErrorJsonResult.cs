using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Entities
{
    public class ErrorJsonResult : IPinduoduoJsonResult
    {
        public ErrorEntity error_response { get; set; }
    }

    [Serializable]
    public class ErrorEntity
    {
        public ReturnCode error_code { get; set; }

        public string error_msg { get; set; }
    }
}
