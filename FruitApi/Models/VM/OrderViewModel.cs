using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Models.VM
{
    //get all cart map to a user
    public class OrderViewModel
    {
        
        public int OrderId { get; set; }
      
        public int OrderQty { get; set; }
         
        public decimal OrderAmount { get; set; }
         
        public DateTime OrderDate { get; set; }
         
        public string PaymentMethod { get; set; }
         
        public string BillingAddress { get; set; }

        public int? FruitId { get; set; }//f.k

        public string FruitName { get; set; }//new

        public string FruitImg { get; set; }//new

        public int UserId { get; set; }//f.k
        
        public string? Status { get; set; }//f.k

    }
}
