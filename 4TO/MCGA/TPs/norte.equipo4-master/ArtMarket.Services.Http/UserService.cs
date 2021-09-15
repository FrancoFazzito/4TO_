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
    [RoutePrefix("api/User")]
    public class UserService : ApiController
    {
        [HttpGet]
        [Route("Login")]
        public User Login(string email, string password)
        {
            User user = new User {Email = email};
            try
            {
                //var us = new UserBusiness();
                //User user = us.Login(email, password);
                
                if (user.Email == null)
                    throw new ArgumentException("User Not Found");
                else
                    return user;
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


        [HttpPost]
        [Route("Agregar")]
        public User Add(User user)
        {
            try
            {
                var us = new UserBusiness();
                us.Add(user);
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

            return user;
        }
    }
}
