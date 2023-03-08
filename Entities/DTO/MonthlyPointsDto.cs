using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class MonthlyPointsDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int MonthlySum { get; set; }
    }
}
