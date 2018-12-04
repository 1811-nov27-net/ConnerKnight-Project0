using Project0.Library;
using System;
using System.Collections.Generic;
using Xunit;


namespace Project0.Tests
{
    public class OrderTests
    {
        [Fact]
        public void BasicPlaceOrder()
        {
            //arrange
            User u = new User("Bobby","Gogurt");
            Location l = new Location("Piozos");
            DateTime d = new DateTime(1995, 1, 25);
            Pizza p = new Pizza("Pepperoni", 19.95m);
            List<IVictual> oFood = new List<IVictual>();
            oFood.Add(p);
            Order o = new Order(l,u,d,oFood);
            //act
            bool res1 = u.OrderHistory.Contains(o);
            bool res2 = l.OrderHistory.Contains(o);
            //assert
            Assert.True(res1);
            Assert.True(res2);
        }
    }
}
