using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zappts.Domain.Returns
{

    public class ReturnResponse
    {
        public ReturnResponse()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public object Result { get; set; }

    }
}
