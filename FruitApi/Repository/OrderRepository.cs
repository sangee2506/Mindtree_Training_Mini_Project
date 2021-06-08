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

        internal bool CreateData(int userId, Order order)
        {
           List<Cart> cartList= db.Carts.ToList();
           
           foreach(Cart cart in cartList)
            {
                if (userId == cart.UserId)
                {
                    Order obj = new Order()
                    {
                        OrderQty = cart.CartQty,
                        OrderAmount = cart.CartAmount,
                        OrderDate = System.DateTime.Now.Date,
                        PaymentMethod = order.PaymentMethod,
                        BillingAddress = order.BillingAddress,
                        FruitId = cart.FruitId,
                        UserId = cart.UserId,
                        Status = "pending"
                    };
                    db.Orders.Add(obj);
                    db.SaveChanges();
                }                      
            }

            foreach (Cart cart in cartList)
            {
                if (userId == cart.UserId)
                {
                    db.Carts.Remove(cart);
                    db.SaveChanges();
                }           
            }
            return true;
        }

        internal List<Order> GetAllDataByUserId(int userId)
        {
            List<Order> orderList = db.Orders.ToList();
            List<Order> orderReturn = new List<Order>();
         
            foreach(Order order in orderList)
            {
                if(order.UserId==userId)
                {
                    orderReturn.Add(order);
                }                            
            }
            return orderReturn;
        }
    }
}
