using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
    public class Order
    {

        public Location Location { get; set; }
        public User User { get; set; }
        public DateTime OrderTime { get; set; }
        public List<IVictual> Contents { get; set; }
        public decimal Price;

        public Order(Location l, User u, DateTime ot, List<IVictual> c)
        {
            Location = l;
            User = u;
            OrderTime = ot;
            Contents = c;
            Price = Contents.Sum(s => s.Price);
            User.PlaceOrder(this);
            Location.PlaceOrder(this);
        }

        //serializing order is going to break everything
        //going to have to do this another way, maybe ...
        //don't know thinkabout this
        public Order()
        {
            Location = new Location();
            User = new User();
            OrderTime = new DateTime();
            Contents = new List<IVictual>();
        }


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
