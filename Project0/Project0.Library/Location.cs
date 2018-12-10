using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.Library
{

    

    public class Location : IHistoryable
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        //was Dictionary<IVictual,int> had to make List<KeyValuePair<IVictual,int>> for serialization
        public Dictionary<Ingredient, int> Inventory { get; set; }
        //made it so only pizzas could be ordered
        public List<Pizza> Menu { get; set; }
        public List<Order> OrderHistory { get; set; }

        //wouldn't even conceivably ever use this constructor, doesn't make sense
        /*
        public Location(string name, Dictionary<Ingredient, int> inventory, List<Pizza> menu ,List<Order> orderHistory)
        {
            Name = name;
            Inventory = inventory;
            Menu = menu;
            OrderHistory = orderHistory;
        }
        */

        public Location(string name, Dictionary<Ingredient, int> inventory, List<Pizza> menu)
        {
            Name = name;
            Inventory = inventory;
            Menu = menu;
            OrderHistory = new List<Order>();
        }
        public Location(string name, List<Pizza> menu)
        {
            Name = name;
            Menu = menu;
            Inventory = new Dictionary<Ingredient, int>();
            OrderHistory = new List<Order>();
        }
        public Location(string name, Dictionary<Ingredient, int> inventory)
        {
            Name = name;
            Menu = new List<Pizza>();
            Inventory = inventory;
            OrderHistory = new List<Order>();
        }
        public Location(string name)
        {
            Name = name;
            Inventory = new Dictionary<Ingredient, int>();
            Menu = new List<Pizza>();
            OrderHistory = new List<Order>();
        }

        //not necesary if not using XML
        //needed for SQL
        public Location()
        {
            Name = null;
            Inventory = new Dictionary<Ingredient, int>();
            Menu = new List<Pizza>();
            OrderHistory = new List<Order>();
        }
        

        public void PlaceOrder(Order o, Dictionary<Ingredient, int> orderIngredients)
        {
            foreach(KeyValuePair<Ingredient,int> pair in orderIngredients)
            {
                Inventory[pair.Key] = Inventory[pair.Key] - pair.Value;
            }
            OrderHistory.Add(o);
        }

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
