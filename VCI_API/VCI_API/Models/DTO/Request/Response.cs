using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VCI_API.Models.Utils;

namespace VCI_API.Models.DTO.Request
{
    public class Response<T>
    {
        public T Result { get; set; }
        public bool Success { get; set; }
        public Error Error { get; set; }
    }
}