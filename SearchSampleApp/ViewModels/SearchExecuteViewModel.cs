using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchSampleApp.ViewModels
{
    public class SearchExecuteViewModel
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

        public string Name { get; set; }
        public DateTime? Date { get; set; }
        public Decimal? Total { get; set; }
        public string Status { get; set; }
    }
}