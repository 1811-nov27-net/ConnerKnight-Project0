using System;
using System.Collections.Generic;

namespace Project0.DataAccess
{
    public partial class Location
    {
        public Location()
        {
            Order = new HashSet<Order>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
