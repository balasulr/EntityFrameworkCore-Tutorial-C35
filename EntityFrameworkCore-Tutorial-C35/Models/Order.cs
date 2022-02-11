using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial_C35.Models {
    
    public class Order {
        //////////////////////////////////////////////////////
        public int Id { get; set; } // Primary Key Property
        // Add attributes to make sure SQL defines correctly
       
        [Required] // Don't want Description to be null & have to use the using statement
        [StringLength(80)] // Control the string length for Description & how long should it be
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(11,2)")]
        public decimal Total { get; set; }

        /// Without this, every customer has to have a Customer Id
        //public int? CustomerId { get; set; } // Means that there can be customers without a CustomerId
        public int CustomerId { get; set; } // Foreign key
        
        // Property for Customer Instance
        public virtual Customer Customer { get; set; } // Virtual means is in the class and not the database
        

        //////////////////////////////////////////////////////


        //////////////////////////////////////////////////////

        //////////////////////////////////////////////////////


    }
}
