﻿using ASF.UI.WbSite.Constants.ErrorController;

namespace ASF.UI.WbSite.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI;
    using ASF.UI.WbSite.Constants;

    /// <summary>
    /// Provides methods that respond to HTTP requests with HTTP errors.
    /// </summary>
    [RoutePrefix("error")]
    public sealed class ErrorController : Controller
    {
        #region Public Methods

        /// <summary>
        /// Returns a HTTP 400 Bad Request error view. Returns a partial view if the request is an AJAX call.
        /// </summary>
        /// <returns>The partial or full bad request view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.BadRequest)]
        [Route("badrequest", Name = ErrorControllerRoute.GetBadRequest)]
        public ActionResult BadRequest()
        {
            return this.GetErrorView(HttpStatusCode.BadRequest, ErrorControllerAction.BadRequest);
        }

        /// <summary>
        /// Returns a HTTP 403 Forbidden error view. Returns a partial view if the request is an AJAX call.
        /// Unlike a 401 Unauthorized response, authenticating will make no difference.
        /// </summary>
        /// <returns>The partial or full forbidden view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.Forbidden)]
        [Route("forbidden", Name = ErrorControllerRoute.GetForbidden)]
        public ActionResult Forbidden()
        {
            return this.GetErrorView(HttpStatusCode.Forbidden, ErrorControllerAction.Forbidden);
        }

        /// <summary>
        /// Returns a HTTP 500 Internal Server Error error view. Returns a partial view if the request is an AJAX call.
        /// </summary>
        /// <returns>The partial or full internal server error view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.InternalServerError)]
        [Route("internalservererror", Name = ErrorControllerRoute.GetInternalServerError)]
        public ActionResult InternalServerError()
        {
            return this.GetErrorView(HttpStatusCode.InternalServerError, ErrorControllerAction.InternalServerError);
        }

        /// <summary>
        /// Returns a HTTP 405 Method Not Allowed error view. Returns a partial view if the request is an AJAX call.
        /// </summary>
        /// <returns>The partial or full method not allowed view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.MethodNotAllowed)]
        [Route("methodnotallowed", Name = ErrorControllerRoute.GetMethodNotAllowed)]
        public ActionResult MethodNotAllowed()
        {
            return this.GetErrorView(HttpStatusCode.MethodNotAllowed, ErrorControllerAction.MethodNotAllowed);
        }

        /// <summary>
        /// Returns a HTTP 404 Not Found error view. Returns a partial view if the request is an AJAX call.
        /// </summary>
        /// <returns>The partial or full not found view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.NotFound)]
        [Route("notfound", Name = ErrorControllerRoute.GetNotFound)]
        public ActionResult NotFound()
        {
            return this.GetErrorView(HttpStatusCode.NotFound, ErrorControllerAction.NotFound);
        }

        /// <summary>
        /// Returns a HTTP 401 Unauthorized error view. Returns a partial view if the request is an AJAX call.
        /// </summary>
        /// <returns>The partial or full unauthorized view.</returns>
        [OutputCache(CacheProfile = CacheProfileName.Unauthorized)]
        [Route("unauthorized", Name = ErrorControllerRoute.GetUnauthorized)]
        public ActionResult Unauthorized()
        {
            return this.GetErrorView(HttpStatusCode.Unauthorized, ErrorControllerAction.Unauthorized);
        } 

        #endregion

        #region Private Methods

        private ActionResult GetErrorView(HttpStatusCode statusCode, string viewName)
        {
            this.Response.StatusCode = (int)statusCode;

            // Don't show IIS custom errors.
            this.Response.TrySkipIisCustomErrors = true;

            ActionResult result;
            if (this.Request.IsAjaxRequest())
            {
                // This allows us to show errors even in partial views.
                result = this.PartialView(viewName);
            }
            else
            {
                result = this.View(viewName);
            }

            return result;
        }

        #endregion
    }
}