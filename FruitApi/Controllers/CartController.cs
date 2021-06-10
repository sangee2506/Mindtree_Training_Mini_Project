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
    [Authorize(Roles = "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository repo = null;
        public CartController()
        {
            repo = new CartRepository();
        }

        [HttpGet]
        public ActionResult GetAllCarts()
        {
            List<CartViewModel> list = repo.GetAllData();
            return Ok(list);
        }

        // GET api/<TravellerController>/5
        [HttpGet("{userId}")]
        public ActionResult GetCartByUserId(int userId)
        {

            List<CartViewModel> list = repo.GetAllDataByUserId(userId);
            return Ok(list);
        }

        [HttpPost]
        public ActionResult CreateCart(Cart cart)
        {
           bool res = repo.CreateData(cart);
            if (res)
            {
                return Ok("added");
            }
            else
            {
                return BadRequest("not added");
            }          
        }

        // DELETE api/<TravellerController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCart(int id)
        {
            bool res=repo.DeleteData(id);
            if (res)
            {
                return Ok(" Deleted Successfully");
            }
            else
            {
                return NotFound(id + "\t is not present");
            }     
        }

        [HttpPut("{id}")]
        public ActionResult updateCartQty(Cart cart)
        {

            if (cart.CartQty != 0)
            {
                bool res=repo.UpdateQtyOfCart(cart);
                if (res)
                {
                    return Ok("Updated cart Qty Successfully");
                }
                else
                {
                    return BadRequest("cart Qty can not be updated due to bad data");
                }
               
            }
            else
            {
                return BadRequest("cart Qty can not be 0");
            }
        }
    }
}
