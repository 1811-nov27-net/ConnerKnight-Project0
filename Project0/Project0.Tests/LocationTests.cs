using Project0.Library;
using System;
using System.Collections.Generic;
using Xunit;

namespace Project0.Tests
{
    public class LocationTests
    {
        [Fact]
        public void BasicLocationCreateTest()
        {

            Location actLoc = new Location("Fortozo");

            Assert.Equal("Fortozo", actLoc.Name);

        }

        [Fact]
        public void NameMenuLocationCreateTest() {

            Pizza p1 = new Pizza("Pepperoni", new List<Ingredient> { Ingredient.Pepperoni }, 19.95m);
            Pizza p2 = new Pizza("Supreme", new List<Ingredient> { Ingredient.Mushroom, Ingredient.Pepper, Ingredient.Sausage }, 25.95m);
            Pizza p3 = new Pizza("Dessert", new List<Ingredient> { Ingredient.Cinnamon, Ingredient.Mushroom }, 7.95m);
            List<Pizza> menu = new List<Pizza>() { p1, p2, p3 };
            Location actLoc = new Location("Zanos", menu);

            Assert.Equal("Zanos", actLoc.Name);
            Assert.Equal(menu, actLoc.Menu);

        }

        [Fact]
        public void NameInventoryMenuCreateTest() {

            Pizza p1 = new Pizza("Pepperoni", new List<Ingredient> { Ingredient.Pepperoni }, 19.95m);
            Pizza p2 = new Pizza("Supreme", new List<Ingredient> { Ingredient.Mushroom, Ingredient.Pepper, Ingredient.Sausage }, 25.95m);
            Pizza p3 = new Pizza("Dessert", new List<Ingredient> { Ingredient.Cinnamon, Ingredient.Marshmallow }, 7.95m);
            List<Pizza> menu = new List<Pizza>() { p1, p2, p3 };
            Dictionary<Ingredient, int> inventory = new Dictionary<Ingredient, int>() {
                { Ingredient.Pepperoni, 5},
                { Ingredient.Mushroom, 3 },
                { Ingredient.Pepper, 2},
                { Ingredient.Sausage, 8},
            };
            Location actLoc = new Location("Zanos", inventory,menu);
            Assert.Equal("Zanos", actLoc.Name);
            Assert.Equal(menu, actLoc.Menu);
            Assert.Equal(inventory, actLoc.Inventory);

        }

            
        
    }
}