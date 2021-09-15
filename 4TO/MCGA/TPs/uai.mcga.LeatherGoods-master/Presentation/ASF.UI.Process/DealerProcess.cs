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
    public class DealerProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> SelectList()
        {
            var start = new DateTime().Millisecond;
            logger.Info("Realizando la busqueda");
            
            var response = HttpGet<AllResponse<Dealer>>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);

            var elapsedTime = DateTime.Now.Millisecond - start;
            logger.Info($"Termino la busqueda [elapsedTime: {elapsedTime}]");
            return response.Result;
        }

        public Dealer Find(int id)
        {
            var resp = HttpGet<FindResponse<Dealer>>("rest/Dealer/Find/" + id, new Dictionary<string, object>(),MediaType.Json);

            return resp.Result;

        }

        public void Edit(Dealer dto)
        {
            var resp = HttpPut<Dealer>("rest/Dealer/Edit", dto);
        }

        public void Add(Dealer dto)
        {

            var resp = HttpPost<Dealer>("rest/Dealer/Add", dto);

        }

        public void Delete(int id)
        {
            var resp = HttpDelete("rest/Dealer/Remove/" + id);

            var test = resp != null;
            
        }
    }
}