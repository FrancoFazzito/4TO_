using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public List<Product> GetAll()
        {
            var response = HttpGet<List<Product>>("/api/product/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Product Get(int id)
        {
            var response = HttpGet<Product>("api/product/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public Product Add(Product product)
        {
            var response = HttpPost<Product>("api/product/agregar", product, MediaType.Json);
            return response;
        }

        public void Edit(Product product)
        {
            HttpPut<Product>("api/product/editar", product, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<Product>("api/product/eliminar", id, MediaType.Json);
        }
    }
}
