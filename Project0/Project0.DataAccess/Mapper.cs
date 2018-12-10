using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.DataAccess
{
    public static class Mapper
    {

        public static Library.User Map(User user) => new Library.User
        {
            //Id = restaurant.Id
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        public static User Map(Library.User user) => new User
        {
            //Id = restaurant.Id
            FirstName = user.FirstName,
            LastName = user.LastName,
            Order = new List<Order>()
        };

        public static Library.Location Map(Location location) => new Library.Location
        {
            //Id = location.id
            Name = location.Name,
            Inventory = Map(location.Inventory)
        };


    }
}
