using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class Cart : IdentityBase
    {
        public Cart()
        {
            this.CartItem = new HashSet<CartItem>();
        }

        [DataMember]
        [DisplayName("Cookie")]
        public string Cookie { get; set; }

        [DataMember]
        [DisplayName("Fecha de creación")]
        public DateTime CartDate { get; set; }

        [DataMember]
        [DisplayName("Cantidad de ítems")]
        public int ItemCount { get; set; }

        public virtual ICollection<CartItem> CartItem { get; set; }
    }
}