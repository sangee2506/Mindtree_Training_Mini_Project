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
            List<Cart> list = repo.GetAllData();
            return Ok(list);
        }

        // GET api/<TravellerController>/5
        [HttpGet("{id}")]
        public ActionResult GetCartById(int id)
        {
            Cart cart = repo.GetDataById(id);
            if (cart!=null)
            {
                return Ok(cart);
            }
            else
            {
                return NotFound(id + "\t is present");
            }           
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
    }
}
