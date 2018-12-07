using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.Library
{
    /// <summary>
    /// represents someone who places Orders at a Location
    /// </summary>
    public class User : IHistoryable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location DefaultLocation { get; set; }
        public List<Order> OrderHistory { get; set; }
        //public List<Order> OrderHistory;

        public User()
        {
            FirstName = null;
            LastName = null;
            OrderHistory = new List<Order>();
        }

        public User(string firstName, string lastName, List<Order> orderHistory = null)
        {
            FirstName = firstName;
            LastName = lastName;
            if(orderHistory == null)
            {
                OrderHistory = new List<Order>();
            }
            else
            {
                OrderHistory = orderHistory;
            }
        }

            public void PlaceOrder(Order o)
        {
            //do the two hour check
            double twoHoursInSeconds = 60 * 60 * 2;
            bool checkOrder = OrderHistory.Where(a => a.OrderTime.Subtract(o.OrderTime).TotalSeconds > (twoHoursInSeconds))
                .Any(b => b.Location.Equals(o.Location));
            if(checkOrder)
            {
                OrderHistory.Add(o);
            }
            else
            {
                throw new BadOrderException("order was placed within two hours of another order at the same location")
            }
            
        }

        public Order SuggestedOrder()
        {
            //returns the most recent
            if(OrderHistory != null && OrderHistory.Count > 0)
            {
                //return OrderHistory[OrderHistory.Count - 1];
                Order result = (Order)OrderHistory.GroupBy(o => o).OrderByDescending(og => og.Count()).First();
                return result;
            }
            return null;
            //other option
            //OrderHistory.GroupBy(o => o).Select(r => r.Key).OrderBy()
            //Order result = (Order)OrderHistory.GroupBy(o => o).OrderByDescending(og => og.Count()).First();
            //return result;
        }

        //display order history sorted by earliest, latest, cheapest, most expensive
        /*
        public List<Order> EarliestOrderedHistory()
        {
            return OrderHistory.OrderBy(h => h.OrderTime).ToList();
        }

        public List<Order> LatestOrderedHistory()
        {
            return OrderHistory.OrderByDescending(h => h.OrderTime).ToList();
        }

        public List<Order> CheapestOrderedHistory()
        {
            return OrderHistory.OrderBy(h => h.Price).ToList();
        }

        public List<Order> ExpensiveOrderedHistory()
        {
            return OrderHistory.OrderByDescending(h => h.Price).ToList();
        }
        */
    }
}
