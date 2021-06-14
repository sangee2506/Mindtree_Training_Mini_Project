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
        public async Task TestUserUpdateDataTestAsync()
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
        public async Task TestUserCreateDataAsyncTestAsync()
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

        /// <summary>
        /// cart
        /// </summary>
        [TestMethod()]
        public void GetAllCartDataTest()
        {
            CartRepository repo = new CartRepository();

            int cnt = repo.GetAllData().Count;
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
        public void GetAllCartDataByUserIdTest()
        {
            CartRepository repo = new CartRepository();

            int cnt = repo.GetAllDataByUserId(10).Count;
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
        public void CreateCartTest()
        {
            CartRepository repo = new CartRepository();

            FruitUserApi.Models.Cart cart = new FruitUserApi.Models.Cart()
            {
                CartId = 0,
                CartQty = 10,
                CartAmount = 111,
                FruitId = 1,
                Fruit=null,
                UserId = 1,
                User=null

            };
            bool actual = repo.CreateData(cart);
        
            bool expected = true;
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");
        }

        [TestMethod()]
        public void DeleteCartTest()
        {
            CartRepository repo = new CartRepository();
            bool actual = repo.DeleteData(1);
            bool expected = false;
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");


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

        /*   
         *   akash            
         */


        /// <summary>
        /// feedback
        /// </summary>

        //To get all feedback 
        [TestMethod()]
        public void GetAllFeedbackTest()
        {
            FeedbackRepository repo = new FeedbackRepository();

            int cnt = repo.GetAllFeedback().Count;
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByUserIdTest is passed with actual value=>");
        }
        // test case for creating feedback
        [TestMethod()]
        public void CreateFeedbackTest()
        {
            FeedbackRepository repo = new FeedbackRepository();

            FruitUserApi.Models.Feedback feedbck = new FruitUserApi.Models.Feedback()
            {
                FeedbackId = 0,
                UserId = 1,
                Message = "this fruit is osm",
                FruitId = 1
            };
            bool actual = repo.CreateFeedback(feedbck);
            bool expected = true;
            Assert.AreEqual(expected, actual);
            Console.WriteLine("TestCreateFeedback is passed with actual value" + actual);
        }
        //Get all feedback by id
        [TestMethod()]
        public void GetAllFeedbackDataByIdTest()
        {
            FeedbackRepository repo = new FeedbackRepository();

            int cnt = repo.GetAllDataById(10).Count;
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetAllfeedbackdataByIdTest is passed with actual value=>");
        }

        /// <summary>
        /// fruit
        /// </summary>

        //test case for getting all fruits 
        [TestMethod()]
        public void GetAllDataTest()
        {
            FruitRepository repo = new FruitRepository();

            int cnt = repo.GetAllData().Count;
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetAllDataTest is passed with actual value=>");
        }
        [TestMethod()]
        public void GetDataByIdDataTest()
        {
            FruitRepository repo = new FruitRepository();
            Fruit fruit = new Fruit();
            Fruit res = repo.GetDataById(1);
            bool expected = true;
            bool actual = false;
            if (res != null)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetDataByIdDataTest is passed with actual value=>");
        }

        [TestMethod()]
        public void UpdateQtyOfFruitTest()
        {
            FruitRepository repo = new FruitRepository();
            Fruit fruit = new Fruit();
            fruit.FruitId = 1;
            fruit.FruitName = "Apple";
            fruit.FruitPrice = 100;
            fruit.FruitQty = 250;
            fruit.FruitImg = "img";
            bool actual = repo.UpdateQtyOfFruit(fruit);
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        /// Order
        /// </summary>

        [TestMethod()]
        public void GetAllOrderDataTest()
        {
            OrderRepository repo = new OrderRepository();

            int cnt = repo.GetAllData().Count;
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetAllOrderDataTest is passed with actual value=>");
        }
        [TestMethod()]
        public void CreateOrderTest()
        {
            OrderRepository repo = new OrderRepository();

            FruitUserApi.Models.Order order = new FruitUserApi.Models.Order()
            {
                OrderId = 0,
                OrderQty = 10,
                OrderDate = System.DateTime.Now.Date,
                OrderAmount = 1000,
                FruitId = 1,
                UserId = 1,
                Status = "pending"

            };
            bool actual = repo.CreateData(1, order);

            bool expected = true;
            Assert.AreEqual(expected, actual);
            Console.WriteLine("CreateOrderTest is passed with actual value=>");
        }
        [TestMethod()]
        public void GetAllDataByUserIdTest()
        {
            OrderRepository repo = new OrderRepository();

            int cnt = repo.GetAllDataByUserId(10).Count;
            bool expected = true;
            bool actual = false;

            if (cnt > 0)
            {
                actual = true;
            }
            Assert.AreEqual(expected, actual);
            Console.WriteLine("GetAllDataByUserIdTest is passed with actual value=>");
        }

    }
}