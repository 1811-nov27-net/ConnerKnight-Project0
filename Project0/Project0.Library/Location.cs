using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
    public class Location
    {
        public string Name;
        public Dictionary<IVictual,int> Inventory { get; set; }
        public List<Order> OrderHistory { get; set; }

        public Location(string name, Dictionary<IVictual,int> inventory, List<Order> orderHistory)
        {
            Name = name;
            Inventory = inventory;
            OrderHistory = orderHistory;
        }

        public Location(string name, Dictionary<IVictual, int> inventory)
        {
            Name = name;
            Inventory = inventory;
            OrderHistory = new List<Order>();
        }
        public Location(string name)
        {
            Name = name;
            Inventory = new Dictionary<IVictual, int>();
            OrderHistory = new List<Order>();
        }

        public void PlaceOrder(Order o)
        {
            OrderHistory.Add(o);
        }

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
