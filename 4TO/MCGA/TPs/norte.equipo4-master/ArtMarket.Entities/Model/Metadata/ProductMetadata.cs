using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtMarket.Entities.Model
{
    /// <summary>
    /// Product Metadata class
    /// </summary>
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        public class ProductMetadata
        {
            [DisplayName("Id")]
            [Required(ErrorMessage = "Requerido")]
            public int Id
            {
                get;
                set;
            }

            [DisplayName("Title")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(100, ErrorMessage = "Title Longitud  100 caracteres")]
            public string
              Title
            {
                get;
                set;
            }

            [DisplayName("Description")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(2000, ErrorMessage = "Description Longitud  2000 caracteres")]
            public string
              Description
            {
                get;
                set;
            }

            [DisplayName("Artist Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              ArtistId
            {
                get;
                set;
            }

            [DisplayName("Image")]
            [Required(ErrorMessage = "Requerido")]
            [MaxLength(128, ErrorMessage = "Image Longitud  128 caracteres")]
            public string
              Image
            {
                get;
                set;
            }

            [DisplayName("Price")]
            [Required(ErrorMessage = "Requerido")]
            public double
              Price
            {
                get;
                set;
            }

            [DisplayName("Quantity Sold")]
            [Required(ErrorMessage = "Requerido")]
            public int
              QuantitySold
            {
                get;
                set;
            }

            [DisplayName("Avg Stars")]
            [Required(ErrorMessage = "Requerido")]
            public double
              AvgStars
            {
                get;
                set;
            }
        }
    }
}
