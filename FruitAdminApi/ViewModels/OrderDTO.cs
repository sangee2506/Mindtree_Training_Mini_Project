using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.ViewModels
{
    public class OrderDTO
    {
        public int OrderId { get; set; }//f.k

        public int OrderQty { get; set; }//f.k
        
        public decimal OrderAmount { get; set; }
        
        public string OrderDate { get; set; }//check
        
        public string PaymentMethod { get; set; }
        
        public string BillingAddress { get; set; }

        public int? FruitId { get; set; }//f.k
        public Fruit Fruit { get; set; }

        
        public int UserId { get; set; }//f.k
        public User User { get; set; }

        public string? Status { get; set; }//f.k
    }
}
