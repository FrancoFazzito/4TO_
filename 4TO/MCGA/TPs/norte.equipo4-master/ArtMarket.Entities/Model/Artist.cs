using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class Artist : IdentityBase
    {
        public Artist()
        {
            this.Products = new HashSet<Product>();
        }

        [DataMember]
        [Browsable(false)]
        [Required]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Edad")]
        public string LifeSpan { get; set; }

        [DataMember]
        [Required]
        [DisplayName("País")]
        public string Country { get; set; }

        [DataMember]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        [DataMember]
        [Required]
        [DisplayName("Cantidad de productos")]
        public int TotalProducts { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
