using FruitUserApi.Data;
using FruitUserApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Repository
{
    public class OrderRepository
    {
        private readonly FruitVendorContext db ;
        public OrderRepository()
        {
            db = new FruitVendorContext();
        }

        public List<Order> GetAllData()
        {
            return db.Orders.ToList();
        }

        internal bool CreateData(Order order)
        {
           List<Cart> cartList= db.Carts.ToList();
           
           foreach(Cart cart in cartList)
            {
                Order obj = new Order()
                {
                    OrderAmount = cart.CartAmount,
                    OrderDate = order.OrderDate,
                    PaymentMethod = order.PaymentMethod,
                    BillingAddress =order.BillingAddress,
                    FruitId = cart.FruitId,
                    UserId =cart.UserId
                 };
                db.Orders.Add(obj);
                db.SaveChanges();            
            }

            foreach (Cart cart in cartList)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
            return true;
        }
    }
}
