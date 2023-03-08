using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("userapikeys")]
    public class UserApiKey
    {
        [Key]
        [Required]
        [Column("userapikey")]
        public string ApiKey { get; set; }
        [JsonIgnore]
        [Required]
        [Column("userId")]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
