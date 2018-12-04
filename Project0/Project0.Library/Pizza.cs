using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    public class Pizza : IVictual
    {
        public string Name { get ; set ; }
        public decimal Price { get ; set ; }

        public Pizza(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}
