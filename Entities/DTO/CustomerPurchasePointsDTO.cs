using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CustomerPurchasePointsDTO
    {
        public string? CustomerName { get; set; }
        public string? Email { get; set; }
        public IEnumerable<MonthlyPointsDto>? MonthlyPoints { get; set; }
        public int TotalPoints { get; set; }
    }
}
