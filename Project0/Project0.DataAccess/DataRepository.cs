using System;
using System.Collections.Generic;
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
            db.Add(Mapper.Map(user));
        }

        public void DeleteUser(Library.User user)
        {
            db.Remove(db.User.Find(user.UserId));
        }

        //public void UpdateUser()

        public void AddLocation(Library.Location location)
        {
            db.Add(Mapper.Map(location));
        }

        public void DeleteLocation(Library.Location location)
        {
            db.Remove(db.Location.Find(location.LocationId));
        }

        public void AddOrder(Library.Order order)
        {
            db.Add(Mapper.Map(order));
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
