using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class CartItemBusiness
    {
        private BaseDataService<CartItem> db = new BaseDataService<CartItem>();

        public List<CartItem> GetAll()
        {
            return db.Get();
        }

        public CartItem GetById(int id)
        {
            return db.GetById(id);
        }
        
        public CartItem Edit(CartItem cartItem)
        {
            return db.Update(cartItem, cartItem.Id);
        }

        public CartItem Create(CartItem cartItem)
        {
            return db.Create(cartItem);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
