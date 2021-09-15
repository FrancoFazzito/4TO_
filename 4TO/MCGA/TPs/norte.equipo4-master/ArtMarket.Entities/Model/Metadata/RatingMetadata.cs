using System; 
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// Rating Metadata class
    /// </summary>
    [MetadataType(typeof(RatingMetadata))]
    public partial class Rating
    {
        public class RatingMetadata
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
            /// User Id
            /// </summary>        
            [DisplayName("UserName")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(128, ErrorMessage = "User Id Longitud  128 caracteres")]
            public string
              UserName
            {
                get;
                set;
            }

            /// <summary>
            /// Product Id
            /// </summary>        
            [DisplayName("Product ID")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Product
            {
                get;
                set;
            }

            /// <summary>
            /// Stars
            /// </summary>        
            [DisplayName("Stars")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Stars
            {
                get;
                set;
            }

            /// <summary>
            /// Created On
            /// </summary>        
            [DisplayName("Created On")]
            [Required(ErrorMessage = "Requerido")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime
              CreatedOn
            {
                get;
                set;
            }

            /// <summary>
            /// Created By
            /// </summary>        
            [DisplayName("Created By")]
            [MaxLength(256, ErrorMessage = "Created By Longitud  256 caracteres")]
            public string
              CreatedBy
            {
                get;
                set;
            }

            /// <summary>
            /// Changed On
            /// </summary>        
            [DisplayName("Changed On")]
            [Required(ErrorMessage = "Requerido")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime
              ChangedOn
            {
                get;
                set;
            }

            /// <summary>
            /// Changed By
            /// </summary>        
            [DisplayName("Changed By")]
            [MaxLength(256, ErrorMessage = "Changed By Longitud  256 caracteres")]
            public string
              ChangedBy
            {
                get;
                set;
            }
        }
    }
}
