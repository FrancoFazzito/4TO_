using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Dealer")]
    public class DealerService : ApiController
    {

        private DealerBusiness dealerBusiness = new DealerBusiness();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("Add")]
        public Dealer Add(Dealer dto)
        {

            logger.Info("Start to add new cateory");
            try
            {
                return dealerBusiness.Save(dto);
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
        public AllResponse<Dealer> All()
        {
            try
            {
                var response = new AllResponse<Dealer>();

                response.Result = dealerBusiness.All();
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
        public Dealer Edit(Dealer dealer)
        {
            try
            {
                return dealerBusiness.Save(dealer);
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
        public FindResponse<Dealer> Find(int id)
        {

            logger.Info($"Inicio de la busqueda de la categoria con id {id}");
            try
            {
                var response = new FindResponse<Dealer>();
                response.Result = dealerBusiness.Find(id);
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
                dealerBusiness.Remove(id);
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