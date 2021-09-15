using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// OrderNumber Metadata class
    /// </summary>
    [MetadataType(typeof(OrderNumberMetadata))]
    public partial class OrderNumber
    {
        public class OrderNumberMetadata
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
            /// Number
            /// </summary>        
            [DisplayName("Number")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Number
            {
                get;
                set;
            }
        }
    }
}
