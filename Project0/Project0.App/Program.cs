using Project0.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> Users = new List<User>();
            List<Location> Locations = new List<Location>();
            User currentUser;

            Console.WriteLine("Welcome to Pizza Manager!");
            Console.WriteLine("Press L to (L)oad data");
            Console.WriteLine("Press N for (N)ew data");
            string input = Console.ReadLine().ToUpper();
            if (input.StartsWith('N'))
            {
                Console.WriteLine("You selected New Data");
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
                    currentUser = new User(firstName, lastName);
                    Users.Add(currentUser);
                    Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}");
                    Console.WriteLine("Press A to (A)dd Order");
                    Console.WriteLine("Press B to go (B)ack to Main Menu");
                    input = Console.ReadLine().ToUpper();
                    if(input.StartsWith('A'))
                    {
                        Console.WriteLine("Enter the name of the restaurant you would like to order from");
                        /*
                        input = Console.ReadLine();
                        Location chosenLocation = Locations.Where(a => a.Name.Equals(input)).First();
                        List < KeyValuePair<Pizza, int> > menu = chosenLocation.Inventory.ToList();
                        for(int i = 0; i < menu.Count; i++)
                        {
                            Console.WriteLine($"Press {i} to choose {menu[i].Key.Name}, num remaining: {menu[i].Value}");
                        }
                        input = Console.ReadLine();
                        int numPressed = int.Parse(input);
                        Order ChosenOrder = new Order(chosenLocation,currentUser,DateTime.Now,new List<IVictual> { menu[numPressed].Key});
                        Console.WriteLine("Order has been Placed");
                        */

                    }

                }


            }
        }
    }
}
