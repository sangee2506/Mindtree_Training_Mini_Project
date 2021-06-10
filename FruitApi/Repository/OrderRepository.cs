using FruitUserApi.Data;
using FruitUserApi.Models;
using FruitUserApi.Models.VM;
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


        internal List<OrderViewModel> GetAllDataByUserId(int userId)
        {
            List<Order> orderList = db.Orders.ToList();
            List<Fruit> fruitList = db.Fruits.ToList();

            List<OrderViewModel> orderReturn = new List<OrderViewModel>();

            Fruit fruitItem = null;
            OrderViewModel orderViewModelItem = null;

            foreach (Order order in orderList)
            {
                if (order.UserId == userId)
                {
                    fruitItem = db.Fruits.Find(order.FruitId);
                    orderViewModelItem = new OrderViewModel()
                    {
                        OrderId=order.OrderId,
                        OrderQty=order.OrderQty,
                        OrderAmount=order.OrderAmount,
                        OrderDate=order.OrderDate,
                        PaymentMethod=order.PaymentMethod,
                        BillingAddress=order.BillingAddress,
                        FruitId=fruitItem.FruitId,
                        FruitName=fruitItem.FruitName,
                        FruitImg=fruitItem.FruitImg,
                        UserId=order.UserId,
                        Status=order.Status
                    };
                    orderReturn.Add(orderViewModelItem);
                }
            }//forreach
            return orderReturn;
        }


        /*internal List<Order> GetAllDataByUserId(int userId)
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
        }*/
    }
}
