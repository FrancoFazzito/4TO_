using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CartProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> SelectList()
        {
            var start = new DateTime().Millisecond;
            logger.Info("Realizando la busqueda");
            
            var response = HttpGet<AllResponse<Cart>>("rest/Cart/All", new Dictionary<string, object>(), MediaType.Json);

            var elapsedTime = DateTime.Now.Millisecond - start;
            logger.Info($"Termino la busqueda [elapsedTime: {elapsedTime}]");
            return response.Result;
        }

        public Cart Find(int id)
        {
            var resp = HttpGet<FindResponse<Cart>>("rest/Cart/Find/" + id, new Dictionary<string, object>(),MediaType.Json);

            return resp.Result;

        }

        public void Edit(Cart cart)
        {
            var resp = HttpPut<Cart>("rest/Cart/Edit",cart);
        }

        public void Add(Cart cart)
        {

            var resp = HttpPost<Cart>("rest/Cart/Add", cart);

        }

        public void Delete(int id)
        {
            var resp = HttpDelete("rest/Category/Remove/" + id);

            var test = resp != null;
            
        }
    }
}