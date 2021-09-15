using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArtMarket.Business;
using ArtMarket.Entities.Model;

namespace ArtMarket.Services.Http
{
    [RoutePrefix("api/CartItem")]
    public class CartItemService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartItem"></param>
        [HttpPost]
        [Route("Agregar")]
        public CartItem AddCart(CartItem cartItem)
        {
            try
            {
                var cib = new CartItemBusiness();
                return cib.Create(cartItem);
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
        public void Edit(CartItem cartItem)
        {
            try
            {
                var cib = new CartItemBusiness();
                cib.Edit(cartItem);
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public CartItem Find(int id)
        {
            try
            {
                var cib = new CartItemBusiness();
                return cib.GetById(id);
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
        /// Deletes an CartItem by ID.
        /// </summary>
        /// <param name="id">ID of the CartItem to delete.</param>
        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var cib = new CartItemBusiness();
                cib.Delete(id);
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
