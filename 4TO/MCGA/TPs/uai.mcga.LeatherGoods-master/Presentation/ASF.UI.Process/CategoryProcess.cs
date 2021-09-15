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
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var start = new DateTime().Millisecond;
            logger.Info("Buscando las categorias");
            
            var response = HttpGet<AllResponse<Category>>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);

            var elapsedTime = DateTime.Now.Millisecond - start;
            logger.Info($"Termino la busqueda de terminales [elapsedTime: {elapsedTime}]");
            return response.Result;
        }

        public Category GetCategory(int id)
        {
            var resp = HttpGet<FindResponse<Category>>("rest/Category/Find/" + id, new Dictionary<string, object>(),MediaType.Json);

            return resp.Result;

        }

        public void EditCategory(Category category)
        {
            var resp = HttpPut<Category>("rest/Category/Edit",category);
        }

        public void SaveCategory(Category category)
        {

            var resp = HttpPost<Category>("rest/Category/Add", category);

        }

        public void DeleteCategory(int id)
        {
            var resp = HttpDelete("rest/Category/Remove/" + id);

            var test = resp != null;
            
        }
    }
}