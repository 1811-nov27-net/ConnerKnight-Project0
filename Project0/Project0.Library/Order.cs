using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Order
    {
        public Location Location { get; set; }
        public User User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<IVictual> Contents { get; set; }

        /*
        public override bool Equals(object obj)
        {
            if((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Order o = (Order)obj;
                return 
            }
        }
        */

    }
}
