using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCGA.Constants
{
    public class Application
    {
        public const string Name = "Clinica Alejandria";
        public const string ShortName = "Alejandria";
        public const int SeoDescriptionLength = 260;
        public const string Email = "info@sitio.com.ar";
        public const string Phone = "(+54-11) 5678-3211";
        public const string StreetAddress = "Ruta 67";
        public const string Locality = "CABA";
        public const string PostalCode = "5678";
        public const string Country = "Argentina";

        public const double Latitude = -69.667308627965596;
        public const double Longitude = -34.49549933992794;

        public static string Url => HttpContext.Current.Request.Url.AbsoluteUri;
    }
}