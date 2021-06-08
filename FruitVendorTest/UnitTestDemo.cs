using FruitUserApi.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using FruitUserApi.Models;

namespace FruitVendorTest
{
    [TestClass]
    public class UnitTestDemo
    {
        [TestInitialize]
        public void BeforeTest()
        {
            Console.WriteLine("The Operation is BeforeTest");
        }

        [TestCleanup]
        public void AfterTest()
        {
            Console.WriteLine("The Operation is AfterTest");
        }

      /*  [TestMethod]
        public async Task Test_CreateDataAsync()
        {

            FruitUserApi.Models.User user = new FruitUserApi.Models.User()
            {
                UserId = 1,
                UserName = "Test 1",
                UserPasswd = "pass",
                Gender = "Male",
                Email = "Test1@gmail.com",
                MobNum = 789654321
            };
            UserRepository repo = new UserRepository();
            bool actual = await repo.CreateDataAsync(user);
            bool expected = true;
            Assert.AreEqual(expected, actual);

            Console.WriteLine("Test_CreateDataAsync is passed with actual value" + actual);

        }*/
    }
}
