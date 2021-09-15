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
    [RoutePrefix("api/Order")]
    public class OrderService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="order"></param>
        [HttpPost]
        [Route("Agregar")]
        public Order Add(Order order)
        {
            try
            {
                var ob = new OrderBusiness();
                return ob.Create(order);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    Content = new StringContent(ex.Message + ". Excepción interna: " + ex.InnerException),
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public void Edit(Order order)
        {
            try
            {
                if (order == null)
                {
                    throw new Exception("Object can not be null!");
                }

                var ob = new OrderBusiness();
                ob.Edit(order);
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
        ///
        /// </summary>
        /// <param name="id"> </param>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public Order Find(int id)
        {
            try
            {
                var ob = new OrderBusiness();
                return ob.GetById(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message + "+" + ex.InnerException,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        public List<Order> List()
        {
            try
            {
                var ob = new OrderBusiness();
                return ob.GetAll();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message + "+" + ex.InnerException,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="id"> </param>
        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var ob = new OrderBusiness();
                ob.Delete(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message + "+" + ex.InnerException,
                    Content = new StringContent(ex.Message),
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
