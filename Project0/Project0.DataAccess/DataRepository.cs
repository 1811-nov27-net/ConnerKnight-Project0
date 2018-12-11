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
            catch (Exception)
            {

                //do nothing

            }
            db.SaveChanges();
            
            //db.Add(Mapper.Map(order));
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
