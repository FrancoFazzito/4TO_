using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ArtMarket.Business;
using ArtMarket.Entities.Model;

namespace ArtMarket.Services.Http
{
    [RoutePrefix("api/Cart")]
    public class CartService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        [HttpPost]
        [Route("Agregar")]
        public Cart AddCart(Cart cart)
        {
            try
            {
                var bc = new CartBusiness();
                return bc.Create(cart);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message + "+" + ex.InnerException),
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public void Edit(Cart cart)
        {
            try
            {
                var bc = new CartBusiness();
                bc.EditProduct(cart);
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
        /// <param name="id"> </param>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public Cart Find(int id)
        {
            try
            {
                var bc = new CartBusiness();
                return bc.GetById(id);
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
