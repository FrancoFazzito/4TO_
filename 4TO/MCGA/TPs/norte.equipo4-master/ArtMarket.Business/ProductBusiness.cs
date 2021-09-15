using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Data.EntityFramework;
using ArtMarket.Entities.Model;

namespace ArtMarket.Business
{
    public class ProductBusiness
    {
        private BaseDataService<Product> db = new BaseDataService<Product>();

        public List<Product> GetAll()
        {
            return db.Get(includeEntities: "Artist");
        }

        public Product GetById(int id)
        {
            return db.GetById(id);
        }

        public Product Edit(Product product)
        {
            return db.Update(product, product.Id);
        }

        public Product Create(Product product)
        {
            return db.Create(product);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }
    }
}
