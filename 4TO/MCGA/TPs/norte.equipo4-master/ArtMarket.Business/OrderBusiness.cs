using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class OrderBusiness
    {
        private BaseDataService<Order> db = new BaseDataService<Order>();

        public List<Order> GetAll()
        {
            return db.Get();
        }

        public Order GetById(int id)
        {
            return db.GetById(id);
        }

        public Order Edit(Order order)
        {
            return db.Update(order, order.Id);
        }

        public Order Create(Order order)
        {
            return db.Create(order);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
