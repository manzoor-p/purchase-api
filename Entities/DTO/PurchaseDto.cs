using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class PurchaseDto
    {
        public Guid IdPurchase { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; } 
    }
}
