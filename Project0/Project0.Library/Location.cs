using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Location
    {
        public Dictionary<IVictual,int> MyProperty { get; set; }
        public List<Order> OrderHistory { get; set; }
    }
}
