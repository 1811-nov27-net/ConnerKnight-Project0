using Project0.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project0.Tests
{
    public class UserTests
    {
        [Fact]
        public void CreateUserTest()
        {
            User u = new User("Bobby", "John");
            Assert.Equal("Bobby", u.FirstName);
            Assert.Equal("John", u.LastName);
        }

        [Fact]
        public void SuggestedOrderTest()
        {
            User u = new User("Bill", "Nolt");
            Location l = new Location("Baziznoz");
            DateTime d1 = new DateTime(1995, 1, 25);
            DateTime d2 = new DateTime(1995, 2, 5);
            DateTime d3 = new DateTime(1995, 4, 12);
            DateTime d4 = new DateTime(1994, 8, 10);
            Pizza p1 = new Pizza("Pepperoni", new List<Ingredient> { Ingredient.Pepperoni }, 19.95m);
            Pizza p2 = new Pizza("Supreme", new List<Ingredient> { Ingredient.Mushroom, Ingredient.Pepper, Ingredient.Sausage }, 25.95m);
            Pizza p3 = new Pizza("Dessert", new List<Ingredient> { Ingredient.Cinnamon, Ingredient.Mushroom }, 7.95m);
            List<Pizza> oFood1 = new List<Pizza>() { p1 };
            Order o1 = new Order(l, u, d1, oFood1);
            ISet<Pizza> oFood2 = new HashSet<Pizza>() { p2, p3 };
            Order o2 = new Order(l, u, d2, oFood2);
            ISet<Pizza> oFood3 = new HashSet<Pizza>() { p2 };
            Order o3 = new Order(l, u, d4, oFood3);
            ISet<Pizza> oFood4 = new HashSet<Pizza>() { p2, p3 };
            Order o4 = new Order(l, u, d3, oFood2);
            u.OrderHistory = new List<Order>() { o1, o2, o3, o4 };
            Order actSug = u.SuggestedOrder();
            Order expSug = new Order(l, u, d1, oFood2);
            Assert.Equal(expSug.Location,actSug.Location);
            Assert.Equal(expSug.Contents, actSug.Contents);
        }
    }
}
