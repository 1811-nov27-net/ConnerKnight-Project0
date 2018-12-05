using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.Library
{
    /// <summary>
    /// represents someone who places Orders at a Location
    /// </summary>
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> OrderHistory;

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
            OrderHistory.Add(o);
        }

        public Order SuggestedOrder()
        {
            //returns the most recent
            if(OrderHistory != null && OrderHistory.Count > 0)
            {
                return OrderHistory[OrderHistory.Count - 1];
            }
            return null;
            //other option
            //OrderHistory.GroupBy(o => o).Max(m => m.Count()).Select(r => r.Key)
        }

        //display order history sorted by earliest, latest, cheapest, most expensive
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
    }
}
