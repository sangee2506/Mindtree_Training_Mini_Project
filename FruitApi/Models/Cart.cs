using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }
        [Required]
        public int CartQty { get; set; }
        [Required]
        public decimal CartAmount { get; set; }

       
        public int? FruitId { get; set; }//f.k
        public Fruit Fruit { get; set; }

        [Required]
        public int UserId { get; set; }//f.k
        public User User { get; set; }

    }
}

/*
cId (p.k)=int
fId (F.k)=int
cQty =int
uid (F.k)=int
amount =double

 
 */