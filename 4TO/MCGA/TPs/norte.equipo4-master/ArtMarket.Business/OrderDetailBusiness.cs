using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class OrderDetailBusiness
    {
        private BaseDataService<OrderDetail> db = new BaseDataService<OrderDetail>();

        public List<OrderDetail> GetAll()
        {
            return db.Get();
        }

        public OrderDetail GetById(int id)
        {
            return db.GetById(id);
        }

        public OrderDetail Edit(OrderDetail orderDetail)
        {
            return db.Update(orderDetail, orderDetail.Id);
        }

        public OrderDetail Create(OrderDetail orderDetail)
        {
            return db.Create(orderDetail);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
