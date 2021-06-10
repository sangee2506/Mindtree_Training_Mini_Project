using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitAdminApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitAdminApi.Repository;
using FruitUserApi.Models;
using FruitAdminApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FruitAdminApi.Controllers.Tests
{
    [TestClass()]
    public class AdminOrderControllerTests
    {
        [TestMethod()]
        public void GetAllOrdersTest()
        {
            AdminOrderRepository repo = new AdminOrderRepository();
            List<OrderDTO> OrderList = repo.GetAllOrders();
            int actual = OrderList.Count();
            int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetOrderByIdTest()
        {
            AdminOrderRepository repo = new AdminOrderRepository();
            Order actual = repo.GetOrderById(1);
            Order expected = new Order()
            {
                 OrderId = 1
                /*  UserName = "abc",
                  UserPasswd = "pass",
                  Gender = "male",
                  Email = "s@gmail.com",
                  MobNum = 7894561254*/

            };
            Assert.AreEqual(expected.OrderId, actual.OrderId);
        }
    }
}