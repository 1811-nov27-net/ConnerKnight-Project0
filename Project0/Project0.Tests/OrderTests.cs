using Project0.Library;
using System;
using System.Collections.Generic;
using Xunit;


namespace Project0.Tests
{
    public class OrderTests
    {
        [Fact]
        public void OrderCreateTest()
        {
            
            User u = new User("Bobby","Gogurt");
            Location l = new Location("Piozos");
            DateTime d = new DateTime(1995, 1, 25);
            Pizza p = new Pizza("Pepperoni", new List<Ingredient> { Ingredient.Pepperoni }, 19.95m);
            List<Pizza> oFood = new List<Pizza>() { p};
            Order oAct = new Order(l,u,d,oFood);
            
            Assert.Equal(u,oAct.User);
            Assert.Equal(l,oAct.Location);
            Assert.Equal(d, oAct.OrderTime);
            Assert.Equal(oFood,oAct.Contents);


        }
    }
}
