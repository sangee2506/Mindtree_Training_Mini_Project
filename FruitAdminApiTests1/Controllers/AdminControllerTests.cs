using Microsoft.VisualStudio.TestTools.UnitTesting;
using FruitAdminApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitAdminApi.Repository;
using FruitUserApi.Models;

namespace FruitAdminApi.Controllers.Tests
{
    [TestClass()]
    public class AdminControllerTests
    {
        [TestMethod()]
        public void GetAllAdminsTest()
        {
            AdminRepository repo = new AdminRepository();
            List<Admin> AdminsList = repo.GetAll();
            int actual = AdminsList.Count();
            int expected = 1;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public void GetAllFeedbacksTest()
        {
            AdminRepository repo = new AdminRepository();
            List<Feedback> FeedbackList = repo.GetAllFeedbacks();
            int actual = FeedbackList.Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod()]
        public async Task GetUserByUserIdTestAsync()
        {
            AdminRepository repo = new AdminRepository();
            User actual = await repo.GetUserById(1);
            User expected = new User()
            {
                UserId = 1,
              /*  UserName = "abc",
                UserPasswd = "pass",
                Gender = "male",
                Email = "s@gmail.com",
                MobNum = 7894561254*/

            };
            Assert.AreEqual(expected.UserId, actual.UserId);


        }
    }
}