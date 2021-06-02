using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int OrderQty { get; set; }//f.k
        [Required]
        public decimal OrderAmount { get; set; }
        [Required]
        public string OrderDate { get; set; }//check
        [Required]
        public string PaymentMethod{ get; set; }
        [Required]
        public string BillingAddress { get; set; }

        
        public int? FruitId { get; set; }//f.k
        public Fruit Fruit { get; set; }

        [Required]
        public int UserId { get; set; }//f.k
        public User User { get; set; }
      

    }
}
/*
oId(p.k)=int
fId =int
amount=double
aId =int
date=date
pm=string
placeAddress=string
 
 */