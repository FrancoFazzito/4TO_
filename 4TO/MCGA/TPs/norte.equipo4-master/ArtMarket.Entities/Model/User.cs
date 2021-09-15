using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArtMarket.Entities.Model
{
    public partial class User : IdentityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime SignUpDate { get; set; }
        public int OrderCount { get; set; }
    }
}
