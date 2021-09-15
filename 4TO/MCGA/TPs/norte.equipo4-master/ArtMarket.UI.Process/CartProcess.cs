using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class CartProcess : ProcessComponent
    {
        public List<Cart> GetAll()
        {
            var response = HttpGet<List<Cart>>("/api/cart/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Cart Get(int id)
        {
            var response = HttpGet<Cart>("api/cart/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public Cart Add(Cart cart)
        {
            var response = HttpPost<Cart>("api/cart/agregar", cart, MediaType.Json);
            return response;
        }

        public void Edit(Cart cart)
        {
            HttpPut<Cart>("api/cart/editar", cart, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<Cart>("api/cart/eliminar", id, MediaType.Json);
        }
    }
}
