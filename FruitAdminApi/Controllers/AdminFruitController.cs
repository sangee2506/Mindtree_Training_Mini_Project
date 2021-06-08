using FruitAdminApi.Repository;
using FruitAdminApi.ViewModels;
using FruitUserApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace FruitAdminApi.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminFruitController : ControllerBase
    {
        IWebHostEnvironment _appEnvironment;
        readonly AdminFruitRepository repo = null;

        public AdminFruitController(IWebHostEnvironment hostingEnvironment)
        {
            repo = new AdminFruitRepository();
            _appEnvironment = hostingEnvironment;
        }

        //Get All Fruits
        [HttpGet("")]
        public IActionResult GetAllFruits()
        {
            List<Fruit> fruits = repo.GetAllFruits();
            return Ok(fruits);
        }

        //Get Fruit Details By id
        [HttpGet("{id}")]
        public IActionResult GetFruitById(int id)
        {
            Fruit fruit = repo.GetFruitById(id);
            return Ok(fruit);
        }
        //edit fruit by id
        [HttpPut("{id}")]
        public async Task<IActionResult> EditFruitById(int id, [FromBody] FruitDTO model)
        {
            Fruit editedFruit = new Fruit();
            if (model.FruitImgFile==null)
            {
                Fruit selectedFruit = repo.GetFruitById(id);
                selectedFruit.FruitName=model.FruitName;
                selectedFruit.FruitPrice = model.FruitPrice;
                selectedFruit.FruitQty = model.FruitQty;
                editedFruit = await repo.EditFruitByIdAsync(id,selectedFruit);
            }
            else
            {
                byte[] bytes = Convert.FromBase64String(model.FruitImgFile);
                Image image;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    image = Image.FromStream(ms);
                }

                string[] path = new string[] { "Z:/FruitVendor/", "FruitVendor_MVC/", "wwwroot/", "Images/" };
                string folderPath = Path.Combine(path);  //Create a Folder in your Root directory on your solution.
                string fileName = Guid.NewGuid().ToString() + "img.png";
                string imagePath = folderPath + fileName;
                image.Save(imagePath);

                Fruit obj = new Fruit()
                {
                    FruitName = model.FruitName,
                    FruitPrice = model.FruitPrice,
                    FruitQty = model.FruitQty,
                    FruitImg = fileName
                };
                editedFruit = await repo.EditFruitByIdAsync(id, obj);
                
            }
            return Ok(editedFruit);
        }

        // delete Fruit By id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruitById(int id)
        {
            bool status = await repo.DeleteFruitByIdAsync(id);
            return Ok(status);
        }

        // Add Fruit
        [HttpPost("")]
        public async Task<IActionResult> AddFruit([FromBody]FruitDTO model)
        {
            byte[] bytes = Convert.FromBase64String(model.FruitImgFile);
            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
       
            string[] path = new string[] {"Z:/FruitVendor/","FruitVendor_MVC/","wwwroot/", "Images/" };
            string folderPath = Path.Combine(path);  //Create a Folder in your Root directory on your solution.
            string fileName = Guid.NewGuid().ToString() + "img.png";
            string imagePath = folderPath + fileName;
            image.Save(imagePath);
          
             Fruit obj = new Fruit()
             {
                 FruitName = model.FruitName,
                 FruitPrice = model.FruitPrice,
                 FruitQty=model.FruitQty,
                 FruitImg = fileName
             };

             Fruit fruit = await repo.AddFruitAsync(obj);
             return Ok(fruit);
           

        }
    }
}




