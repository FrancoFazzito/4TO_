using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class Product : IdentityBase
    {
        public Product()
        {
            this.CartItem = new HashSet<CartItem>();
            this.OrderDetail = new HashSet<OrderDetail>();
            this.Rating = new HashSet<Rating>();
        }

        [DataMember]
        [Required]
        [DisplayName("Nombre")]
        public string Title { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DataMember]
        [DisplayName("Imagen")]
        public string Image { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Precio")]
        public double Price { get; set; }

        [DataMember]
        [DisplayName("Cantidad vendida")]
        public int QuantitySold { get; set; }

        [DataMember]
        [DisplayName("Puntuación promedio")]
        public double AvgStars { get; set; }

        [DataMember]
        public int ArtistId { get; set; }

        [DataMember]
        public virtual Artist Artist { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}