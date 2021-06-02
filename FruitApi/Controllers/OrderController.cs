using FruitUserApi.Models;
using FruitUserApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitUserApi.Controllers
{
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
        public ActionResult GetAllFruits()
        {
            List<Order> list = repo.GetAllData();
            return Ok(list);
        }

        [HttpPost]
        public ActionResult CreateCart(Order order)
        {
            bool res = repo.CreateData(order);
            if (res)
            {
                return Ok("order Placed");
            }
            else
            {
                return BadRequest("not added");
            }
        }


    }
}
//  3)will able to perform Create and Read Order Table