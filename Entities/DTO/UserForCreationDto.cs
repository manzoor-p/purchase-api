using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class UserForCreationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [StringLength(45, ErrorMessage = "UserName can't be longer than 45 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [StringLength(45, ErrorMessage = "Email can't be longer than 45 characters")]
        public string Email { get; set; }
    }
}
