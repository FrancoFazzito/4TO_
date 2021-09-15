using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/CartItem")]
    public class CartItemService : ApiController
    {
       
        private CartItemBusiness cartItemBusiness = new CartItemBusiness();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("Add")]
        public CartItem Add(CartItem dto)
        {

            logger.Info("Start to add new cateory");
            try
            {
                return cartItemBusiness.Save(dto);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("All")]
        public AllResponse<CartItem> All()
        {
            try
            {
                var response = new AllResponse<CartItem>();

                response.Result = cartItemBusiness.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public FindResponse<CartItem> Edit(CartItem cart)
        {
            try
            {
                var response = new FindResponse<CartItem> {Result = cartItemBusiness.Save(cart)};
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Find/{id}")]
        public FindResponse<CartItem> Find(int id)
        {

            logger.Info($"Inicio de la busqueda de la categoria con id {id}");
            try
            {
                var response = new FindResponse<CartItem>();
                response.Result = cartItemBusiness.Find(id);
                return response;
            }
            catch (Exception ex)
            {
                logger.Error($"Error al obtener la categoria {id}", ex);
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpDelete]
        [Route("Remove/{id}")]
        public void Remove(int id)
        {
            try
            {
                cartItemBusiness.Remove(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
        
    }
}