using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ArtMarket.Entities.Model;

namespace ArtMarket.Data
{
    public class ArtShopDbContext : DbContext
    {
        public ArtShopDbContext() : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItem> CartItem { get; set; }
        public virtual DbSet<Error> Error { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<OrderNumber> OrderNumber { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
