using System;
using System.Web;
using ASF.Framework.Utilities;

namespace ASF.Framework.Http
{
    /// <summary>
    /// Clase para agregar un ID unico a las peticiones de http y poder hacer un trace de los request
    /// </summary>
    public class HttpLoggingInterceptor : IHttpModule

    {
        private static readonly String REQUEST_ID = "request-id";
        private static readonly String HEADER_REQUEST_ID = "x-request-id";
        
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.EndRequest += OnEndRequest;
        }

        public void OnBeginRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication) sender;

            String requestId;
            if (StringUtils.IsNullEmpty(app.Request.Headers[HEADER_REQUEST_ID]))
            {
                requestId = Guid.NewGuid().ToString();
            }
            else
            {
                requestId = app.Request.Headers[HEADER_REQUEST_ID];
            }

            log4net.LogicalThreadContext.Properties[REQUEST_ID] = requestId;
            
        }

        public void OnEndRequest(object sender, EventArgs e)
        {
            log4net.LogicalThreadContext.Properties[REQUEST_ID] = null;
        }
        
        public void Dispose()
        {

        }
    }
}