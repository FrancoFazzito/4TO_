namespace ASF.Data
{
    using ASF.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class LeatherContext : DbContext
    {
        // Your context has been configured to use a 'LeatherContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ASF.Data.LeatherContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LeatherContext' 
        // connection string in the application configuration file.
        public LeatherContext()
            : base("name=DefaultConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<LeatherContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Dealer> Dealer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderNumber> OrderNumber { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Setting> Setting { get; set; }
        
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }


}