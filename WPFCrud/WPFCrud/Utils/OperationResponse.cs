using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCrud.Utils
{
    class OperationResponse
    {
        public int Code { get; set; }
        public Object Data { get; set; }

        public OperationResponse(int code, object data=null)
        {
            Code = code;
            Data = data;
        }
    }
}
