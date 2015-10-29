using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchSampleApp.Domain
{
    public class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        // navigation
        public virtual ICollection<Order> Orders { get; set; }

    }
}