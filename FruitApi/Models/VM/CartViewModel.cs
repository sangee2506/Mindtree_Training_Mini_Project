using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models.VM
{
    public class CartViewModel
    {
       
        public int CartId { get; set; }
       
        public int CartQty { get; set; }
      
        public decimal CartAmount { get; set; }
        public int? FruitId { get; set; }//f.k       
        public string FruitImg { get; set; }

        public string FruitName { get; set; }

        public int UserId { get; set; }//f.k
        
    }
}
