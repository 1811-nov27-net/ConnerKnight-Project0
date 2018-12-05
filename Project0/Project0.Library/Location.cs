using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{
    public class Location
    {
        public string Name;
        //was Dictionary<IVictual,int> had to make List<KeyValuePair<IVictual,int>> for serialization
        public List<KeyValuePair<IVictual, int>> Inventory { get; set; }
        public List<Order> OrderHistory { get; set; }

        public Location(string name, List<KeyValuePair<IVictual, int>> inventory, List<Order> orderHistory)
        {
            Name = name;
            Inventory = inventory;
            OrderHistory = orderHistory;
        }

        public Location(string name, List<KeyValuePair<IVictual, int>> inventory)
        {
            Name = name;
            Inventory = inventory;
            OrderHistory = new List<Order>();
        }
        public Location(string name)
        {
            Name = name;
            Inventory = new List<KeyValuePair<IVictual, int>>();
            OrderHistory = new List<Order>();
        }

        public Location()
        {
            Name = null;
            Inventory = new List<KeyValuePair<IVictual, int>>();
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
