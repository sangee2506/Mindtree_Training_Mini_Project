using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.Repository
{
    public class AdminOrderRepository
    {
        private readonly FruitVendorContext db = null;
        public AdminOrderRepository()
        {
            db = new FruitVendorContext();
        }

        
    }
}
//  add get by id method
//  add get all method
