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
    [RoutePrefix("api/OrderDetail")]
    public class OrderDetailService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderDetail"></param>
        [HttpPost]
        [Route("Agregar")]
        public OrderDetail Add(OrderDetail orderDetail)
        {
            try
            {
                var odb = new OrderDetailBusiness();
                return odb.Create(orderDetail);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message + "+" + ex.InnerException,
                    Content = new StringContent(ex.Message)
                };
                throw new HttpResponseException(httpError);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public void Edit(OrderDetail orderDetail)
        {
            try
            {
                if (orderDetail == null)
                {
                    throw new Exception("Object can not be null!");
                }

                var odb = new OrderDetailBusiness();
                odb.Edit(orderDetail);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message,
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
        public OrderDetail Find(int id)
        {
            try
            {
                var odb = new OrderDetailBusiness();
                return odb.GetById(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message,
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
        public List<OrderDetail> List()
        {
            try
            {
                var odb = new OrderDetailBusiness();
                return odb.GetAll();
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message,
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
                var odb = new OrderDetailBusiness();
                odb.Delete(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message,
                    Content = new StringContent(ex.Message)
                };

                throw new HttpResponseException(httpError);
            }
        }
    }
}
