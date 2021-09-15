using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// Error Metadata class
    /// </summary>
    [MetadataType(typeof(ErrorMetadata))]
    public partial class Error
    {
        public class ErrorMetadata
        {
            /// <summary>
            /// Id
            /// </summary>        
            [DisplayName("Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Id
            {
                get;
                set;
            }

            /// <summary>
            /// User Name
            /// </summary>        
            [DisplayName("User Name")]
            [MaxLength(256, ErrorMessage = "User Name Longitud  256 caracteres")]
            public string
              UserName
            {
                get;
                set;
            }

            /// <summary>
            /// Error Date
            /// </summary>        
            [DisplayName("Error Date")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public Nullable<System.DateTime>
              ErrorDate
            {
                get;
                set;
            }

            /// <summary>
            /// Ip Address
            /// </summary>        
            [DisplayName("Ip Address")]
            [MaxLength(50, ErrorMessage = "Ip Address Longitud  50 caracteres")]
            public string
              IpAddress
            {
                get;
                set;
            }

            /// <summary>
            /// User Agent
            /// </summary>        
            [DisplayName("User Agent")]
            public string
              UserAgent
            {
                get;
                set;
            }

            /// <summary>
            /// Exception
            /// </summary>        
            [DisplayName("Exception")]
            public string
              Exception
            {
                get;
                set;
            }

            /// <summary>
            /// Message
            /// </summary>        
            [DisplayName("Message")]
            public string
              Message
            {
                get;
                set;
            }

            /// <summary>
            /// Everything
            /// </summary>        
            [DisplayName("Everything")]
            public string
              Everything
            {
                get;
                set;
            }

            /// <summary>
            /// Http Referer
            /// </summary>        
            [DisplayName("Http Referer")]
            [MaxLength(500, ErrorMessage = "Http Referer Longitud  500 caracteres")]
            public string
              HttpReferer
            {
                get;
                set;
            }

            /// <summary>
            /// Path And Query
            /// </summary>        
            [DisplayName("Path And Query")]
            [MaxLength(500, ErrorMessage = "Path And Query Longitud  500 caracteres")]
            public string
              PathAndQuery
            {
                get;
                set;
            }
        }
    }
}
