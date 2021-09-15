using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Web.Http;
using ArtMarket.Business;
using ArtMarket.Entities.Model;

namespace ArtMarket.Services.Http
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Artist")]
    public class ArtistService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="artist"> </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Agregar")]
        public Artist Add(Artist artist)
        {
            try
            {
                var am = new ArtistBusiness();
                am.Add(artist);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }

            return artist;
        }

        /// <summary>
        /// Updates an Artist info.
        /// </summary>
        /// <param name="artist">Artist to update</param>
        [HttpPut]
        [Route("Editar")]
        public void Edit(Artist artist)
        {
            try
            {
                var am = new ArtistBusiness();
                am.Edit(artist);
            }
            catch (Exception ex)
            {
                // Repack to Http error.
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id">ID of the Artist.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public Artist Find(int id)
        {
            try
            {
                var am = new ArtistBusiness();
                Artist artist = am.Find(id);

                return artist;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        /// Gets all artists.
        /// </summary>
        /// <returns>A List of Artists.</returns>
        [HttpGet]
        [Route("Listar")]
        public List<Artist> List()
        {
            try
            {
                var am = new ArtistBusiness();
                return (List<Artist>)am.List();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        /// Deletes an Artist by ID.
        /// </summary>
        /// <param name="id">ID of the Artist to delete.</param>
        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var am = new ArtistBusiness();
                am.Remove(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
