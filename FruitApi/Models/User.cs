using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPasswd { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long MobNum { get; set; }

        public List<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Person Person { get; set; }

    }
}
/*
aId(p.k)=int
name=string
pass=string
gender=string
email=string
mobNum=long
 */