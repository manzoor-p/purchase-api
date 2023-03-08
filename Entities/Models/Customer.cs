using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("idCustomer")]
        public Guid IdCustomer { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(45, ErrorMessage ="Name can't be longer than 45 characters")]
        public string? Name { get; set; }  
        
        public string? Email { get; set; }

        public ICollection<Purchase>? Purchases { get; set; }
    }
}
