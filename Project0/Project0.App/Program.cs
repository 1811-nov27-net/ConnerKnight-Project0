using Microsoft.EntityFrameworkCore;
using Project0.DataAccess;
using Lib = Project0.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.App
{
    class Program
    {
        static DbContextOptions<Project0Context> options;

        static void Main(string[] args)
        {
            var connectionString = SecretConfiguration.ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<Project0Context>();
            optionsBuilder.UseSqlServer(connectionString);
            options = optionsBuilder.Options;

            var repo = new DataRepository(new Project0Context(options));

            //using (var v = new Project0Context(options))
            //{
            //    Console.WriteLine("Im here");
            //    Console.WriteLine(v.Content.First().Name); 
            //}

            //List<Ingredient> igns = repo.GetIngredients2();

            //foreach (var i in igns)
            //{
            //    Console.WriteLine($"Ingredient: {i.Name}");
            //}


            //List<Lib.User> Users = new List<User>();
            //List<Location> Locations = new List<Location>();
            Lib.User currentUser;

            Console.WriteLine("Welcome to Pizza Manager!");
            //Console.WriteLine("Press L to (L)oad data");
            //Console.WriteLine("Press N for (N)ew data");
            string input; //= Console.ReadLine().ToUpper();
            //if (input.StartsWith('N'))
            //{
            //Console.WriteLine("You selected New Data");
            Console.WriteLine("Press C to (C)reate User Account");
            Console.WriteLine("Press U to Log into (U)ser Account");
            Console.WriteLine("Press L to Add a new (L)ocation");
            input = Console.ReadLine().ToUpper();
            if(input.StartsWith('C'))
            {
                Console.WriteLine("Enter First Name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Last Name");
                string lastName = Console.ReadLine();
                currentUser = new Lib.User(firstName, lastName);
                //adding to database
                repo.AddUser(currentUser);
                //Users.Add(currentUser);
                Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}");
                Console.WriteLine("Press A to (A)dd Order");
                Console.WriteLine("Press B to go (B)ack to Main Menu");
                input = Console.ReadLine().ToUpper();
                if (input.StartsWith('A'))
                {
                    List<Lib.Location> posLoc = repo.GetLocations();
                    Console.WriteLine("Possible Locations: ");
                    foreach (var l in posLoc)
                    {
                        Console.WriteLine(l.Name);
                    }
                    Console.WriteLine("Enter the name of the restaurant you would like to order from");

                    input = Console.ReadLine();
                    Lib.Location chosenLocation = posLoc.Where(a => a.Name.Equals(input)).First();
                    //List < KeyValuePair<Pizza, int> > menu = chosenLocation.Inventory.ToList();
                    List<Lib.Pizza> menu = repo.GetPizzas();
                    Dictionary<Lib.Pizza, int> chosenPizzas = new Dictionary<Lib.Pizza, int>();
                    Console.WriteLine("Choose your pizza(s) to order, Press Q to stop ordering");
                    for (int i = 0; i < menu.Count; i++)
                    {
                        Console.WriteLine($"Press {i} to choose {menu[i].Name}, Price: {menu[i].Price}");
                    }
                    input = Console.ReadLine();
                    int numPressed = int.Parse(input);
                    chosenPizzas[menu[numPressed]] += 1;

                    Lib.Order ChosenOrder = new Lib.Order(chosenLocation, currentUser, DateTime.Now, chosenPizzas);
                    repo.AddOrder(ChosenOrder);
                    Console.WriteLine("Order has been Placed");

                }
            } else if (input.StartsWith('L'))
            {
                Console.WriteLine("Enter the name of your location");
                input = Console.ReadLine();
                Console.WriteLine("choose your inventory package");
                Console.WriteLine("beginner package");
            }
        }
    }
}
