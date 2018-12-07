using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
    /// <summary>
    /// Used to Place orders for a user at a location
    /// </summary>
    class OrderManager
    {

        public void PlaceOrder(Order o)
        {
            o.User.PlaceOrder(o);
            o.Location.PlaceOrder(o);
        }

        //display order history sorted by earliest, latest, cheapest, most expensive
        public List<Order> EarliestOrderedHistory(IHistoryable input)
        {
            return input.OrderHistory.OrderBy(h => h.OrderTime).ToList();
        }

        public List<Order> LatestOrderedHistory(IHistoryable input)
        {
            return input.OrderHistory.OrderByDescending(h => h.OrderTime).ToList();
        }

        public List<Order> CheapestOrderedHistory(IHistoryable input)
        {
            return input.OrderHistory.OrderBy(h => h.Price).ToList();
        }

        public List<Order> ExpensiveOrderedHistory(IHistoryable input)
        {
            return input.OrderHistory.OrderByDescending(h => h.Price).ToList();
        }
    }
}
