using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class CartItemProcess : ProcessComponent
    {
        public CartItem Get(int id)
        {
            var response = HttpGet<CartItem>("api/cartitem/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public CartItem Add(CartItem cartitem)
        {
            var response = HttpPost<CartItem>("api/cartitem/agregar", cartitem, MediaType.Json);
            return response;
        }

        public void Edit(CartItem cartitem)
        {
            HttpPut<CartItem>("api/cartitem/editar", cartitem, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<CartItem>("api/cartitem/eliminar", id, MediaType.Json);
        }
    }
}
