using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models
{
    public class Fruit
    {
        [Key]
        public int FruitId { get; set; }
        [Required]
        public string FruitName { get; set; }
        [Required]
        public decimal FruitPrice { get; set; }
        [Required]
        public int FruitQty { get; set; }
        [Required]
        public string FruitImg { get; set; }

        public List<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
/*
 * 
 fId (p.k)=int
fName =string
fPrice =double
fQty =int
fImg =varBinary
 
 */