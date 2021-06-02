using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.Repository
{
    public class AdminFruitRepository
    {
        private readonly FruitVendorContext db = null;
        public AdminFruitRepository()
        {
            db = new FruitVendorContext();
        }

        

        //  add get by id method
        //  add edit by id method
        //  add delete by id method
    }
}
