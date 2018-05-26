using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VCI.Utils;

namespace VCI.DTO.Request
{
    public class Response<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public Error Error { get; set; }
    }
}