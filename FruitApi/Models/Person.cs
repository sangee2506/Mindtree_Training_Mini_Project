using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string PersonName { get; set; }
        [Required]
        public string PersonPasswd { get; set; }

        public string Role { get; set; }

        public int?UserId { get; set; }//f.k default value null
        public User User { get; set; }

        
        public int? AdminId { get; set; }//f.k default value null
        public Admin Admin { get; set; }

        
    }
}
