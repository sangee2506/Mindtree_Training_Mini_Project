using FruitAdminApi.Repository;
using FruitUserApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrderController : ControllerBase
    {
        readonly AdminOrderRepository repo = null;
        public AdminOrderController()
        {
            repo = new AdminOrderRepository();
        }

        //Get All Orders
        [HttpGet("")]
        public IActionResult GetAllOrders()
        {
            List<Order> orders = repo.GetAllOrders();
            return Ok(orders);
        }

        //Get Order Details By id
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            Order order= repo.GetOrderById(id);
            return Ok(order);
        }
    }
}
