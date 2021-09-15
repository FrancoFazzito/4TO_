using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// Order Metadata class
    /// </summary>
    [MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {
        public class OrderMetadata
        {
            /// <summary>
            /// Id
            /// </summary>        
            [DisplayName("Id")]
            [DataMember]
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
            [DisplayName("ID de usuario")]
            [DataMember]
            [Required(ErrorMessage = "Requerido")]
            public int UserId { get; set; }

            /// <summary>
            /// Order Date
            /// </summary>        
            [DisplayName("Order Date")]
            [DataMember]
            [Required(ErrorMessage = "Requerido")]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            public DateTime OrderDate { get; set; }
    
            [DisplayName("Precio total")]
            [DataMember]
            [Required(ErrorMessage = "Requerido")]
            public double
              TotalPrice
            {
                get;
                set;
            }

            [DisplayName("Número de orden")]
            [DataMember]
            [Required(ErrorMessage = "Requerido")]
            public int
              OrderNumber
            {
                get;
                set;
            }
            
            [DisplayName("Cantidad de productos")]
            [DataMember]
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
