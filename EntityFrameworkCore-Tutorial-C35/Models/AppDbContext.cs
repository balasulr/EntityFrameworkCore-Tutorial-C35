using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Will not turn into the SQL table & this is a support class that EntityFramework will use
namespace EntityFrameworkCore_Tutorial_C35.Models {
    public class AppDbContext : DbContext { // Need DbContext
        // Identify the Customer Class
        public virtual DbSet<Customer> Customers { get; set; }
        // 2 Constructors because is a console app
        public AppDbContext() { } // Default Constructor
        // Constructor that takes 1 parameter & configures how things will work
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        // Methods & override methods in DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

            if(!builder.IsConfigured) {
                builder.UseSqlServer("server=localhost\\sqlexpress;database=SalesDb1;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {

        }
    }
}
