using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngsaStore.Models
{
    public class DatabaseActionResultModel
    {
        public string Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}