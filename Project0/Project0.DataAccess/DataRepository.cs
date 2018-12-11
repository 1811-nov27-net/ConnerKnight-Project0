using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project0.Library;

namespace Project0.DataAccess
{
    public class DataRepository
    {
        private readonly Project0Context db;

        public DataRepository(Project0Context _db)
        {
            db = _db ?? throw new ArgumentNullException(nameof(_db));
        }

        public void AddUser(Library.User user)
        {
            User u = Mapper.Map(user);
            db.Add(u);
            db.SaveChanges();
            user.UserId = u.UserId;

        }

        public void DeleteUser(Library.User user)
        {
            db.Remove(db.User.Find(user.UserId));
        }

        //public void UpdateUser()

        public void AddLocation(Library.Location location)
        {
            Location l = Mapper.Map(location);
            db.Add(l);
            db.SaveChanges();
            foreach(var pair in location.Inventory)
            {
                Ingredient i = db.Ingredient.First(a => a.Name == pair.Key.Name);
                if(i == null)
                {
                    i = new Ingredient() { Name = pair.Key.Name };
                }
                l.Locationingredient.Add(new Locationingredient() { Ingredient = i, Location = l, Quantity = pair.Value });
                
            }
            location.LocationId = l.LocationId;
            db.SaveChanges();
        }

        public void DeleteLocation(Library.Location location)
        {
            db.Remove(db.Location.Find(location.LocationId));
        }


        public void AddOrder(Library.Order order)
        {
            try
            {
                Library.OrderManager.PlaceOrder(order);
                //dont know if this will work
                User u = db.User.Find(order.User.UserId);
                Location l = db.Location.Find(order.Location.LocationId);
                Order o = new Order() { User = u, Location = l };
                foreach(var pair in order.Contents)
                {
                    Content c = db.Content.First(a => a.ContentId == pair.Key.PizzaId);
                    if(c == null)
                    {
                        c = new Content() { Name=pair.Key.Name,Price= pair.Key.Price};
                    }
                    o.OrderContent.Add(new OrderContent() { Order=o,Content=c,Amount=pair.Value});

                }
                db.Order.Add(o);

            }
            catch (BadOrderException e)
            {

                //find a way to tell the user this information

            }
            db.SaveChanges();
            
            //db.Add(Mapper.Map(order));
        }

        public Library.User GetUser(string firstName, string lastName)
        {
            return Mapper.Map(db.User.Where(a => a.FirstName == firstName && a.LastName == lastName).First());
        }

        public List<Library.User> GetUsers()
        {
            List<User> users = db.User.Include(a => a.DefaultLocation).AsNoTracking().ToList();
            return users.Select(a => Mapper.Map(a)).ToList();
        }

        public List<Library.Location> GetLocations()
        {
            List<Location> locations = db.Location.Include(a => a.Locationingredient).ToList();
            List<Library.Location> result = new List<Library.Location>();
            foreach(var l in locations)
            {
                Dictionary<Library.Ingredient, int> tempInventory = new Dictionary<Library.Ingredient, int>();
                foreach(var i in l.Locationingredient)
                {
                    tempInventory[Mapper.Map(i.Ingredient)] = i.Quantity ?? 0;
                }
                Library.Location temp = new Library.Location() { Name = l.Name, Inventory = tempInventory };
                result.Add(temp);
            }

            return result;

        }

        public List<Library.Pizza> GetPizzas()
        {
            return db.Content.Select(a => new Library.Pizza() { Name = a.Name, Price = a.Price ?? 0 }).ToList();
        }

        public List<Library.Ingredient> GetIngredients()
        {
            return db.Ingredient.Select(a => new Library.Ingredient() { Name = a.Name, IngredientId = a.IngredientId }).ToList();
        }

        public List<Ingredient> GetIngredients2()
        {
            return db.Ingredient.ToList();
        }

        public List<Library.Order> GetUserOrderHistory(Library.User user)
        {
            List<Order> os = db.Order.Where(a => a.UserId == user.UserId).Include(a => a.User).Include(b => b.Location).ToList();
            List<Library.Order> result = new List<Library.Order>();
            foreach (var o in os)
            {
                Library.Location l = Mapper.Map(o.Location);
                Dictionary<Pizza,int> pizzas = new Dictionary<Pizza, int>();
                foreach(OrderContent oc in o.OrderContent)
                {
                    Pizza p = new Pizza() { Name = oc.Content.Name,Price = oc.Content.Price ?? 0};
                    pizzas[p] = oc.Amount ?? 0;
                }

                Library.Order tempOrder = new Library.Order() { User = user, Location = l, Contents = pizzas };
                result.Add(tempOrder);
            }

            return result;

        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
