using FruitAdminApi.Repository;
using FruitAdminApi.ViewModels;
using FruitUserApi.Models;
using Microsoft.AspNetCore.Authorization;
using FruitAdminApi.Custom_Exceptions;
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
            List<OrderDTO> orders = repo.GetAllOrders();
            return Ok(orders);
        }

        //Get Order Details By id
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int? id)
        {
            try
            {
                Order order = repo.GetOrderById(id);
                return Ok(order);
            }
            catch(NullValueException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
