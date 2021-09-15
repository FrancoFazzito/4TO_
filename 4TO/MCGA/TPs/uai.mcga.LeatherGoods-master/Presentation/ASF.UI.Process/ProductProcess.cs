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
    public class ProductProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList()
        {
            var start = new DateTime().Millisecond;
            logger.Info("Realizando la busqueda");
            
            var response = HttpGet<AllResponse<Product>>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);

            var elapsedTime = DateTime.Now.Millisecond - start;
            logger.Info($"Termino la busqueda [elapsedTime: {elapsedTime}]");
            return response.Result;
        }

        public Product Find(int id)
        {
            var resp = HttpGet<FindResponse<Product>>("rest/Product/Find/" + id, new Dictionary<string, object>(),MediaType.Json);

            return resp.Result;

        }

        public void Edit(Product dto)
        {
            var resp = HttpPut<Product>("rest/Product/Edit", dto);
        }

        public void Add(Product dto)
        {

            var resp = HttpPost<Product>("rest/Product/Add", dto);

        }

        public void Delete(int id)
        {
            var resp = HttpDelete("rest/Product/Remove/" + id);

            var test = resp != null;
            
        }
    }
}