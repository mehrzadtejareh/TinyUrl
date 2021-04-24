using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TinyUrl.Common
{
    public class TinyActionResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
