using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Country")]
    public class CountryService : ApiController
    {
        private CountryBusiness countryBusiness = new CountryBusiness();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpPost]
        [Route("Add")]
        public Country Add(Country dto)
        {

            logger.Info("Start to add new cateory");
            try
            {
                return countryBusiness.Save(dto);
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
        public AllResponse<Country> All()
        {
            try
            {
                var response = new AllResponse<Country>();

                response.Result = countryBusiness.All();
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
        public void Edit(Country country)
        {
            try
            {
                countryBusiness.Save(country);
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
        public FindResponse<Country> Find(int id)
        {

            logger.Info($"Inicio de la busqueda de la categoria con id {id}");
            try
            {
                var response = new FindResponse<Country>();
                response.Result = countryBusiness.Find(id);
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
                countryBusiness.Remove(id);
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
