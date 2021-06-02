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
    public class FruitController : ControllerBase
    {
        FruitRepository repo = null;
        public FruitController()
        {
            repo = new FruitRepository();
        }

        [HttpGet]
        public ActionResult GetAllFruits()
        {
            List<Fruit> list = repo.GetAllData();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult GetFruitById(int id)
        {
            Fruit fruit = repo.GetDataById(id);
            if (fruit != null)
            {
                return Ok(fruit);
            }
            else
            {
                return NotFound(id + "\t is present");
            }
        }

        [HttpPut("{id}")]
        public ActionResult updateFruit(Fruit fruit)
        {

            if (fruit.FruitQty != 0)
            {
                repo.UpdateQtyOfFruit(fruit);
                return Ok("Updated Successfully");
            }
            else
            {
                return BadRequest("Update not done");
            }
        }
    }
}


//1)will able to perform Read,ReadById and Update(fQty) on Fruits table