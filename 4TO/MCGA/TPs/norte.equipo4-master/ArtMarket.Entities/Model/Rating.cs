using System;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    public partial class Rating : IdentityBase
    {
        public int Stars { get; set; }

        public string UserName { get; set; }

        public virtual Product Product { get; set; }
    }
}