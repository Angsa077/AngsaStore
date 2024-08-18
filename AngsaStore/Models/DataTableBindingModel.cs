using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngsaStore.Models
{
    public class DataTableBindingModel
    {
        public int? page { get; set; }
        public int? totalPage { get; set; } = 0;
        public string searchBox { get; set; }
        public string filter { get; set; }
    }
}