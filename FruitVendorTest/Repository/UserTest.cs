using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitUserApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitUserApi.Models;

namespace FruitUserApi.Repository.Tests
{
    [TestClass()]
    public class UserTest
    {
        [TestMethod()]
        public async Task TestGetDataByUserId()
        {
            UserRepository repo = new UserRepository();
            User res = await repo.GetDataByUserId(10);
            bool expected = true;
            bool actual = false;

            if (res != null)
            {
                actual = true;
            }

            Assert.AreEqual(expected, actual);

            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");
        }

        [TestMethod()]
        public async Task TestUpdateDataTestAsync()
        {
            FruitUserApi.Models.User user = new FruitUserApi.Models.User()
            {
                UserId = 1,
                UserName = "Samar",
                UserPasswd = "pass",
                Gender = "M",
                Email = "e@g",
                MobNum = 123456789
            };
            UserRepository repo = new UserRepository();
            bool actual = await repo.UpdateData(user);
            bool expected = true;
            Assert.AreEqual(expected, actual);

            Console.WriteLine("TestUpdateDataTest is passed with actual value" + actual);

        }

        [TestMethod()]
        public async Task TestCreateDataAsyncTestAsync()
        {
            FruitUserApi.Models.User user = new FruitUserApi.Models.User()
            {
                UserId = 0,
                UserName = "Test1",
                UserPasswd = "pass",
                Gender = "M",
                Email = "e@g",
                MobNum = 123456789
            };
            UserRepository repo = new UserRepository();
            bool actual = await repo.CreateDataAsync(user);
            bool expected = true;
            Assert.AreEqual(expected, actual);

            Console.WriteLine("TestCreateDataAsync is passed with actual value" + actual);
        }

        [TestMethod()]
        public void UpdateQtyOfCartTest()
        {
            FruitUserApi.Models.Cart cart = new FruitUserApi.Models.Cart()
            {
                CartId = 1,
                CartQty = 5,
                CartAmount = 98,
                FruitId = 1,
                UserId = 10
            };
            CartRepository repo = new CartRepository();
            bool actual = repo.UpdateQtyOfCart(cart);
            bool expected = true;
            Assert.AreEqual(expected, actual);

            Console.WriteLine("TestUpdateDataTest is passed with actual value" + actual);
        }

        [TestMethod()]
        public void GetAllDataTest()
        {
            CartRepository repo = new CartRepository();

            int cnt = repo.GetAllData().Count();
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");
        }

        [TestMethod()]
        public void GetAllDataByUserIdTest()
        {
            CartRepository repo = new CartRepository();

            int cnt = repo.GetAllDataByUserId(10).Count();
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");
        }
    }
}