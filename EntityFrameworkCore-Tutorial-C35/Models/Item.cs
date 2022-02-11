using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCore_Tutorial_C35.Models {
    
    public class Item {
        // Properties
        public int Id { get; set; } // Primary Key
        [Required] // Can not be Null so put Required & the using statement using Show potential fixes
        [StringLength(30)]
        public string Code { get; set; } // Want each to be unique for each row
        [Required] // For the Name Property
        [StringLength(30)]
        public string Name { get; set; } // Similar to Description but called Name
        [Column(TypeName = "decimal(7,2)")]
        public decimal Price { get; set; }

    }
}
