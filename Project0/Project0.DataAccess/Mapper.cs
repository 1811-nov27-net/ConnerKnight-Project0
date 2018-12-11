using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project0.DataAccess
{
    public static class Mapper
    {

        public static Library.User Map(User user) => new Library.User
        {
            //Id = restaurant.Id
            FirstName = user.FirstName,
            LastName = user.LastName,
            DefaultLocation = Map(user.DefaultLocation)
        };

        public static User Map(Library.User user) => new User
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Order = new List<Order>()
        };

        public static Library.Location Map(Location location) => new Library.Location
        {
            //Id = location.id
            Name = location.Name
            //Inventory = Map(location.Locationingredient)
        };

        public static Location Map(Library.Location location) => new Location
        {
            //Id = location.id
            Name = location.Name
            //List < Locationingredient > result = new List<Locationingredient>();
            /*
            foreach(KeyValuePair<Ingredient, int> pair in location.Inventory)
            {
                result.Add(new Locationingredient() { })
            }
            */
        };

        public static Library.Ingredient Map(Ingredient ingredient) => new Library.Ingredient
        {
            //IngredientId = ingredient.IngredientId,
            Name = ingredient.Name
        };

        public static Ingredient Map(Library.Ingredient ingredient) => new Ingredient
        {
            //IngredientId = ingredient.IngredientId,
            Name = ingredient.Name
        };

        public static ICollection<OrderContent> Map(ICollection<Library.Pizza> pizzas) => pizzas.Select(Map)

        //public static OrderContent Map(Library.Pizza pizza) =>


        //public static ICollection<Locationingredient> Map(Dictionary<Library.Ingredient, int> ingredients)
        //{}

        public static Library.Order Map(Order order) => new Library.Order
        {

        };

        public static Order Map(Library.Order order) => new Order
        {

        };


    }
}
