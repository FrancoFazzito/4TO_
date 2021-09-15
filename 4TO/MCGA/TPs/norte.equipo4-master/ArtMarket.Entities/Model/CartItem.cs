using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class CartItem : IdentityBase
    {
        [DataMember]
        [Required]
        [DisplayName("Precio")]
        public double Price { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Cantidad")]
        public int Quantity { get; set; }

        [DataMember]
        [Required]
        [DisplayName("ID de Carrito")]
        public int CartId { get; set; }

        [DataMember]
        [Required]
        [DisplayName("ID de producto")]
        public int ProductId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}