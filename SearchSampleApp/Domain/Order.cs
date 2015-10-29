using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchSampleApp.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Total { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; } // FK

        // navigation
        public virtual Customer Customer { get; set; }

    }
}