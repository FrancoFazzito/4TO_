using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Framework.Utilities;

namespace ASF.UI.Process
{
    /// <summary>
    /// Base class for UI Controllers (not the ASP.NET MVC Controllers).
    /// This class is purposely renamed to ProcessComponent to avoid confusion from the MVC controllers.
    /// </summary>
    public abstract class ProcessComponent
    {
        
        protected readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        
        /// <summary>
        /// Sends a Http Get request to a URL with querystring style parameters.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="path">The path to the service.</param>
        /// <param name="parameters">A dictionary containing the parameters and values to form the query.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        protected T HttpGet<T>(string path, Dictionary<string, object> parameters, string mediaType)
        {
            
            UriBuilder builder = new UriBuilder
            {
                Path = path,
                Query = string.Join("&", parameters.Where(p => p.Value != null)
                    .Select(p => string.Format("{0}={1}",
                        HttpUtility.UrlEncode(p.Key),
                        HttpUtility.UrlEncode(p.Value.ToString()))))
            };

            return HttpGet<T>(builder.Uri.PathAndQuery, mediaType);
        }

        /// <summary>
        /// Sends a Http Get request to a URL with parameters separated by /.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="path">The path to the service.</param>
        /// <param name="values">A list of parameter values to form the query.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <return
        protected T HttpGet<T>(string path, List<object> values, string mediaType)
        {
            string query = string.Empty;
            string pathAndQuery = path.EndsWith("/") ? path : path += "/";

            if (values != null && values.Count > 0)
                query = string.Join("/", values.ToArray());

            if (!string.IsNullOrWhiteSpace(query))
                pathAndQuery += query;

            return HttpGet<T>(pathAndQuery, mediaType);
        }

        /// <summary>
        /// Sends a Http Get request to a URL.
        /// </summary>
        /// <typeparam name="T">The returned type from the call.</typeparam>
        /// <param name="pathAndQuery">The path and query to call.</param>
        /// <param name="mediaType">The media type to use i.e. application/xml or application/json.</param>
        /// <returns>An object specified in the generic type.</returns>
        private T HttpGet<T>(string pathAndQuery, string mediaType)
        {
            T result = default(T);

            // Execute the Http call.
            using (HttpClient client = CreateHttpClient(mediaType))
            {

                var response = client.GetAsync(pathAndQuery).Result;
                response.EnsureSuccessStatusCode();
                

                var content = response.Content.ReadAsAsync<T>();
                logger.Info($"se finalizo el get a {pathAndQuery} : HttpResult={response.StatusCode}");
            
                result = content.Result;
            }

            return result;
        }

        public T HttpPost<T>(string path,T value)
        {
            return HttpPost<T>(path, value, MediaType.Json);
        }

        public T HttpPost<T>(string path, T value, string mediaType)
        {
            
            var pathAndQuery = path.EndsWith("/") ? path : path + "/";
            using (var client = CreateHttpClient(mediaType))
            {
                var response = client.PostAsJsonAsync(pathAndQuery, value).Result;
                response.EnsureSuccessStatusCode();
                return value;
            }

        }


        public HttpResponseMessage HttpPut<T>(string path, T value, String mediaType = "serviceUrl")
        {
            var pathAndQuery = path.EndsWith("/") ? path : path + "/";

            using (var client = CreateHttpClient(mediaType))
            {
                var response = client.PutAsJsonAsync(pathAndQuery,value).Result;
                response.EnsureSuccessStatusCode();

                return response;
            }


        }

        public HttpResponseMessage HttpDelete(string path)
        {
            return HttpDelete(path, MediaType.Json);
        }

        public HttpResponseMessage HttpDelete(string path, string mediaType = MediaType.Json)
        {
            var pathAndQuery = path.EndsWith("/") ? path : path + "/";

            using (var client = CreateHttpClient(mediaType))
            {
                var response = client.DeleteAsync(pathAndQuery).Result;
                response.EnsureSuccessStatusCode();
                return response;
            }
        }

        private HttpClient CreateHttpClient(string mediaType)
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["serviceUrl"]);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            client.DefaultRequestHeaders.Add("x-request-id",LogUtils.GetRequestId());

            return client;
        }

        private Dictionary<String,String> GetDefaultHeaders()
        {
            var headers = new Dictionary<string,string>();
            
            headers.Add("x-request-id",LogUtils.GetRequestId());

            return headers;
        }
    }
}
