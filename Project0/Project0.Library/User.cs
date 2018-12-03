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
    }
}
