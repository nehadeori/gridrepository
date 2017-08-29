using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace JQxGrid.Models
{
    /// <summary>
    /// The DbContecxt class, this is used to Create 
    /// Database by reading Connection string from Web.Config file 
    /// and create tables in it  by executing the OnModelCreating 
    /// method where mapping and constraints are defined.
    /// </summary>
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public CustomerContext()
         : base("SalesConnectionString")
        {
        }

        /// <summary>
        /// The below Method is used to define the Maping
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("jq");
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);

            modelBuilder.Entity<Customer>().Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Customer>().Property(c =>
             c.Name).HasMaxLength(15);

            modelBuilder.Entity<Customer>()
                .Property(c =>c.Address)
                .HasMaxLength(50);

            modelBuilder.Entity<Customer>().Property(c =>
             c.Phone);

          //  modelBuilder.Entity<Customer>().Property(c => c.State).HasMaxLength(15);

            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Product>().HasKey(o => o.ProductId);

            modelBuilder.Entity<Customer>()
                .HasMany<Order>(s => s.Orders);

            //modelBuilder.Entity<Order>()
            //  .HasMany<Product>(e => e.Product)
            //  .WithMany(c => c.OrderId);  



            modelBuilder.Entity<Order>().Property(o =>
             o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

       //     modelBuilder.Entity<Order>().Property(o =>
        //     o.OrderedItem).HasMaxLength(50);
            
            //S3: Foreign Key for the Order Table fp the CustomerId
      //      modelBuilder.Entity<Order>().HasRequired(c => c.Customer)
       //      .WithMany(o => o.Orders).HasForeignKey(o => o.CustomerId);

            //The Cascade Delete from Customer to Orders
            //modelBuilder.Entity<Order>()
            // .HasRequired(c => c.Customer)
            // .WithMany(o => o.Orders)
            // .HasForeignKey(o => o.CustomerId)
            // .WillCascadeOnDelete(true);
            //base.OnModelCreating(modelBuilder);
        }
    }
}