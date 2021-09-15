using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// CartItem Metadata class
    /// </summary>
    [MetadataType(typeof(CartItemMetadata))]
    public partial class CartItem
    {
        public class CartItemMetadata
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
            /// Cart Id
            /// </summary>        
            [DisplayName("Cart Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              CartId
            {
                get;
                set;
            }

            /// <summary>
            /// Product Id
            /// </summary>        
            [DisplayName("Product Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              ProductId
            {
                get;
                set;
            }

            /// <summary>
            /// Price
            /// </summary>        
            [DisplayName("Price")]
            [Required(ErrorMessage = "Requerido")]
            public double
              Price
            {
                get;
                set;
            }

            /// <summary>
            /// Quantity
            /// </summary>        
            [DisplayName("Quantity")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Quantity
            {
                get;
                set;
            }

            

        }
    }
}
