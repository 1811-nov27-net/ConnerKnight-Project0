using Project0.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project0.Tests
{
    public class LocationTests
    {
        [Fact]
        public void TestOrderHistoryEarliest()
        {
            //arrange
            User u = new User("Sorry", "Cart");
            Location l = new Location("Baziznoz");
            DateTime d1 = new DateTime(1995, 1, 25);
            DateTime d2 = new DateTime(1995, 2, 5);
            DateTime d3 = new DateTime(1995, 4, 12);
            DateTime d4 = new DateTime(1994, 8, 10);
            Pizza p1 = new Pizza("Pepperoni", 19.95m);
            Pizza p2 = new Pizza("Supreme", 25.95m);
            Pizza p3 = new Pizza("Dessert", 7.95m);
            List<IVictual> oFood1 = new List<IVictual>() { p1};
            Order o1 = new Order(l, u, d1, oFood1);
            List<IVictual> oFood2 = new List<IVictual>() { p2,p3};
            Order o2 = new Order(l, u, d2, oFood2);
            List<IVictual> oFood3 = new List<IVictual>() { p2 };
            Order o3 = new Order(l, u, d4, oFood3);
            //act
            List<Order> exp1 = new List<Order> { o3, o1, o2 };
            List<Order> act1 = l.EarliestOrderedHistory();

            List<Order> exp2 = new List<Order> { o2, o1, o3 };
            List<Order> act2 = l.LatestOrderedHistory();

            List<Order> exp3 = new List<Order> { o1, o3, o2 };
            List<Order> act3 = l.CheapestOrderedHistory();

            List<Order> exp4 = new List<Order> { o2, o3, o1 };
            List<Order> act4 = l.ExpensiveOrderedHistory();

            //Assert
            Assert.Equal(exp1, act1);
            Assert.Equal(exp2, act2);
            Assert.Equal(exp3, act3);
            Assert.Equal(exp4, act4);
        }
    }
}