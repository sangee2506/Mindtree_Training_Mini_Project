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
        
        public int OrderQty { get; set; }//f.k
        
        public decimal OrderAmount { get; set; }
   
        public string OrderDate { get; set; }//check
        
        public string PaymentMethod { get; set; }
       
        public string BillingAddress { get; set; }

        public int? FruitId { get; set; }//f.k
             
        public int UserId { get; set; }//f.k

    }
}
