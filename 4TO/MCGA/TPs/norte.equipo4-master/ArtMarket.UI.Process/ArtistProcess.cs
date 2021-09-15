using System;
using System.Collections.Generic;
using System.Text;
using ArtMarket.Entities.Model;

namespace ArtMarket.UI.Process
{
    public class ArtistProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Artist> GetAll()
        {
            var response = HttpGet<List<Artist>>("/api/artist/listar", new Dictionary<string, object>(), MediaType.Json);
            return response;
        }
        
        public Artist Get(int id)
        {
            var response = HttpGet<Artist>("api/artist/buscar", new List<object>() { id }, MediaType.Json);
            return response;
        }

        public Artist Add(Artist artist)
        {
            var response = HttpPost<Artist>("api/artist/agregar", artist, MediaType.Json);
            return response;
        }

        public void Edit(Artist artist)
        {
            HttpPut<Artist>("api/artist/editar", artist, MediaType.Json);
        }

        public void Delete(int id)
        {
            HttpDelete<Artist>("api/artist/eliminar", id, MediaType.Json);
        }
    }
}
