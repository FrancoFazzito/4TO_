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
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/Product")]
    public class ProductService : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"> </param>
        /// <returns></returns>
        [HttpPost]
        [Route("Agregar")]
        public Product Add(Product product)
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.Create(product);
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="product"> </param>
        [HttpPut]
        [Route("Editar")]
        public void Edit(Product product)
        {
            try
            {
                var bc = new ProductBusiness();
                bc.Edit(product);
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
        [Route("Buscar/{id}")]
        public Product Find(int id)
        {
            try
            {
                var bc = new ProductBusiness();
                var product = bc.GetById(id);
                if (product == null)
                {
                    var httpError = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        ReasonPhrase = "Product not found",
                    };

                    throw new HttpResponseException(httpError);
                }

                return product;
            }
            catch (HttpResponseException ex)
            {
                throw;
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
        /// <returns></returns>
        [HttpGet]
        [Route("Listar")]
        public List<Product> List()
        {
            try
            {
                var bc = new ProductBusiness();
                return bc.GetAll();
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
        /// </summary>
        /// <param name="id"> </param>
        [HttpDelete]
        [Route("Eliminar")]
        public void Remove(int id)
        {
            try
            {
                var bc = new ProductBusiness();
                bc.Delete(id);
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
