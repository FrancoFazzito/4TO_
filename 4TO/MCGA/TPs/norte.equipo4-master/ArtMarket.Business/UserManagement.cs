using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class UserManagement
    {
        BaseDataService<User> db;

        public UserManagement()
        {
            db = new BaseDataService<User>();
        }

        public IList<User> GetAll()
        {
            return db.Get();
        }

        public User Get(string email)
        {
            return db.Get(x => x.Email == email).FirstOrDefault();
        }

        public User Get(int id)
        {
            return db.GetById(id);
        }

        public void Add(User user)
        {
            db.Create(user);
        }

        public void Update(User user)
        {
            db.Update(user, user.Id);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
	}
}
