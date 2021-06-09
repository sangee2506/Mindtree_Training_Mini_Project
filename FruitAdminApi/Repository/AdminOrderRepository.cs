using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitAdminApi.ViewModels;

namespace FruitAdminApi.Repository
{
    public class AdminOrderRepository
    {
        private readonly FruitVendorContext db = null;
        public AdminOrderRepository()
        {
            db = new FruitVendorContext();
        }

        //get All Orders
        public List<Order> GetAllOrders()
        {
            return db.Orders.Include(x => x.Fruit).Include(x => x.User).ToList();
        }
        //get Order Details By id 
        public Order GetOrderById(int id)
        {
            Order order = db.Orders.Include(x=>x.Fruit).Include(x=>x.User).SingleOrDefault(x => x.OrderId == id);
            return order;           
        }


    }
}

