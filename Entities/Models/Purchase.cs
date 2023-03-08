using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Purchase
    {
        [Key]
        [Column("idPurchase")]
        public Guid IdPurchase { get; set; }
                
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid IdCustomer { get; set; }
        public Customer? Customer { get; set; }
    }
}
