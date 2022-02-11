using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial_C35.Models {
    
    public class Customer {
        // Properties that want customer to have:
        public int Id { get; set; } // Entity framework assumes the first one is the Primary key & will auto-generate the value
        [Required] // Has to do with null values
        [StringLength(50)] // These 2 are for Customer Name
        public string Name { get; set; } // Customer Name
        public bool Active { get; set; } // Can mark if the customer is Active or Inactive
        [Column(TypeName = "decimal(9,2)")]
        public decimal Sales { get; set; }
        public DateTime Updated { get; set; } // Time last updated

    }
}
