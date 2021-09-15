using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class OrderProcess : ProcessComponent
    {
        public List<Order> GetAll()
        {
            var response = HttpGet<List<Order>>("/api/order/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }

        public Order Get(int id)
        {
            var response = HttpGet<Order>("api/order/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public Order Add(Order order)
        {
            var response = HttpPost<Order>("api/order/agregar", order, MediaType.Json);
            return response;
        }

        public void Edit(Order order)
        {
            HttpPost<Order>("api/order/editar", order, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<Order>("api/order/eliminar", id, MediaType.Json);
        }
    }
}
