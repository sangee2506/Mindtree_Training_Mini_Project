using FruitUserApi.Models;
using FruitUserApi.Models.VM;
using FruitUserApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Controllers
{
    /*[Authorize(Roles = "user")]*/
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        OrderRepository repo = null;
        public OrderController()
        {
            repo = new OrderRepository();
        }

        [HttpGet]
        public ActionResult GetAllOrders()
        {
            List<Order> list = repo.GetAllData();
            return Ok(list);
        }
        
        [HttpPost("{userId}")]
        //[HttpPost]
        public ActionResult MoveCartToOrders(int userId,Order order)
        {
            bool res = repo.CreateData(userId,order);
            if (res)
            {
                return Ok("order Placed");
            }
            else
            {
                return BadRequest("not added");
            }
        }

        [HttpGet("{userId}")]
        public ActionResult GetAllOrdersByUserId(int userId)
        {
            List<OrderViewModel> list = repo.GetAllDataByUserId(userId);
            return Ok(list);
        }


        /*[HttpGet("{userId}")]
        public ActionResult GetAllOrdersByUserId(int userId)
        {
            List<Order> list = repo.GetAllDataByUserId(userId);
            return Ok(list);
        }*/
    }
}
//  3)will able to perform Create and Read Order Table