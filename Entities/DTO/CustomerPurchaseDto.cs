using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CustomerPurchaseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ICollection<PurchaseDto>? Purchases { get; set; }
    }
}
