using FruitUserApi.Data;
using FruitUserApi.Models;
using FruitAdminApi.Custom_Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FruitAdminApi.ViewModels;
using System.Globalization;

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
        public List<OrderDTO> GetAllOrders()
        {
            List < Order > OrdersList=  db.Orders.Include(x => x.Fruit).Include(x => x.User).ToList();
            List<OrderDTO> NewOrdersList = new List<OrderDTO>();
            
            foreach (var order in OrdersList)
            {
                OrderDTO obj = new OrderDTO();
               
                obj.OrderDate = order.OrderDate.ToString();
                obj.OrderAmount = order.OrderAmount;
                obj.OrderQty = order.OrderQty;
                obj.OrderId = order.OrderId;
                obj.PaymentMethod = order.PaymentMethod;
                obj.Status = order.Status;
                obj.UserId = order.UserId;
                obj.FruitId = order.FruitId;
                obj.Fruit = order.Fruit;
                obj.User = order.User;


                NewOrdersList.Add(obj);
            }
            return NewOrdersList;
        }
        //get Order Details By id 
        public Order GetOrderById(int? id)
        {
            if(id==null)
            {
                throw new NullValueException("Order Id Cant be empty");
            }
            Order order = db.Orders.Include(x=>x.Fruit).Include(x=>x.User).SingleOrDefault(x => x.OrderId == id);
            return order;
            
        }


    }
}

