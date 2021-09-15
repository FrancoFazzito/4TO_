using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// Cart Metadata class
    /// </summary>
    [MetadataType(typeof(CartMetadata))]
    public partial class Cart
    {
        public class CartMetadata
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
            /// Cookie
            /// </summary>        
            [DisplayName("Cookie")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(50, ErrorMessage = "Cookie Longitud  50 caracteres")]
            public string
              Cookie
            {
                get;
                set;
            }

            /// <summary>
            /// Cart Date
            /// </summary>        
            [DisplayName("Cart Date")]
            [Required(ErrorMessage = "Requerido")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public System.DateTime
              CartDate
            {
                get;
                set;
            }

            /// <summary>
            /// Item Count
            /// </summary>        
            [DisplayName("Item Count")]
            [Required(ErrorMessage = "Requerido")]
            public int
              ItemCount
            {
                get;
                set;
            }
        }
    }
}
