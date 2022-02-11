using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Will not turn into the SQL table & this is a support class that EntityFramework will use
namespace EntityFrameworkCore_Tutorial_C35.Models {
    public class AppDbContext : DbContext { // Need DbContext

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        public virtual DbSet<Customer> Customers { get; set; } // Identify the Customer Class
        public virtual DbSet<Order> Orders { get; set; } // Adding Orders to the AppDbContext since the Up &
                                                         // Down was blank with the migration initially
        public virtual DbSet<Item> Items { get; set; }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 2 Constructors because is a console app
        public AppDbContext() { } // Default Constructor
        
        // Constructor that takes 1 parameter & configures how things will work
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methods & override methods in DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if(!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // Makes Code unique
            builder.Entity<Item>(
                e => e.HasIndex(x => x.Code)
                    .IsUnique(true)
            ); // After e.HasIndex is called fluentAPI to make unique
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
