using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQ.PddOpen.Core.Exceptions
{
    public class PttException : ApplicationException
    {
        public PttException(string message)
            : base(message, null)
        {
        }

        public PttException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
