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
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Location DefaultLocation { get; set; }
        public List<Order> OrderHistory { get; set; }

        //not using XML so don't need this onstructor
        
        public User()
        {
            FirstName = null;
            LastName = null;
            OrderHistory = new List<Order>();
        }
        


        //wouldn't concievably ever use this constructor
        /*
        public User(string firstName, string lastName, List<Order> orderHistory)
        {
            FirstName = firstName;
            LastName = lastName;
            OrderHistory = orderHistory;
            
        }
        */

        /// <summary>
        /// constructor to create a new User with given firstName and lastName and an empty OrderHistory
        /// </summary>
        /// <param name="firstName"> the FirstName of the new user</param>
        /// <param name="lastName"> the LastName of the new user</param>
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            OrderHistory = new List<Order>();
        }

        /// <summary>
        /// adds the given order to this users orderhistory, should not ever be called directly by anybody but OrderManager
        /// </summary>
        /// <param name="o"> the ordear to be added to OrderHistory</param>
        public void PlaceOrder(Order o)
        {
             //OrderHistory.Add(o); 
        }

        /// <summary>
        /// suggests an order for the user to place based on the most common order in their history
        /// </summary>
        /// <returns> the users most common order with the current time as the ordertime</returns>
        public Order SuggestedOrder()
        {
            //returns the most recent
            if(OrderHistory != null && OrderHistory.Count > 0)
            {
                //return OrderHistory[OrderHistory.Count - 1];
                var result = OrderHistory.GroupBy(o => new { o.Location,o.Contents }).OrderByDescending(og => og.Count()).First();
                return new Order(result.Key.Location, this, DateTime.UtcNow, result.Key.Contents);
            }
            return null;
            //other option
            //OrderHistory.GroupBy(o => o).Select(r => r.Key).OrderBy()
            //Order result = (Order)OrderHistory.GroupBy(o => o).OrderByDescending(og => og.Count()).First();
            //return result;
        }

        /*
        public override bool Equals(Object obj)
        {
            if((obj == null) || this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                User other = (User)obj;
                return (FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && DefaultLocation.Equals(other.DefaultLocation) && )
            }
        }
        */

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
