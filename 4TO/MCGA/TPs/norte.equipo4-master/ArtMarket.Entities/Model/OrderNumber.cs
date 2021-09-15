using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtMarket.Entities.Model
{
    [Serializable]
    public partial class OrderNumber : IdentityBase
    {
        public int Number { get; set; }
    }
}
