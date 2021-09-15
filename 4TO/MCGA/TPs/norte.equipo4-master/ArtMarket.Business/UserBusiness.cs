using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;
using ArtMarket.Data;

namespace ArtMarket.Business
{
    public class UserBusiness
    {
        public User Login(User users)
        {
            var userDac = new UserDAC();
            return userDac.Login(users.Email, "password");
        }
        
        public User Add(User user)
        {
            User result = default(User);

            var userDAC = new UserDAC();
 
            result = userDAC.Create(user);
            return result;
        }

        public void Update(User user)
        {
            //db.Update(user);
        }

        public void Delete(int id)
        {
            //db.Delete(id);
        }
	}
}
