using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CustomerDto
    {
        public Guid IdCustomer { get; set; }        
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
