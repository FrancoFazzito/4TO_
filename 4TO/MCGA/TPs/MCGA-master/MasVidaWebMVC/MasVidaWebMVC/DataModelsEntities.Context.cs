//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MasVidaWebMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MasVidaDataContext : DbContext
    {
        public MasVidaDataContext()
            : base("name=MasVidaDataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<FamilyGroup> FamiliesGroups { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionsTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UsersTypes { get; set; }
        public DbSet<Audit> Audits { get; set; }
    }
}
