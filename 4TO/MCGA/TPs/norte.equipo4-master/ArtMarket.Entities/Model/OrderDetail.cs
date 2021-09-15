using System;
using System.Runtime.Serialization;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    [DataContract]
    public partial class OrderDetail : IdentityBase
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [DataMember]
        public virtual Order Order { get; set; }
        
        [DataMember]
        public virtual Product Product { get; set; }
    }
}