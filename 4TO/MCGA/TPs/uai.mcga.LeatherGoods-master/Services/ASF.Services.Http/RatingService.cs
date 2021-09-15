using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Rating")]
    public class RatingService : ApiController
    {
        private RatingBusiness ratingBusiness = new RatingBusiness();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("Add")]
        public Rating Add(Rating dto)
        {

            logger.Info("Start to add new cateory");
            try
            {
                return ratingBusiness.Save(dto);
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
        public AllResponse<Rating> All()
        {
            try
            {
                var response = new AllResponse<Rating>();

                response.Result = ratingBusiness.All();
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
        public Rating Edit(Rating rating)
        {
            try
            {
                return ratingBusiness.Save(rating);
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
        public FindResponse<Rating> Find(int id)
        {

            logger.Info($"Inicio de la busqueda de la categoria con id {id}");
            try
            {
                var response = new FindResponse<Rating>();
                response.Result = ratingBusiness.Find(id);
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
                ratingBusiness.Remove(id);
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