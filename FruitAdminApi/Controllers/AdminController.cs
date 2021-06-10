using FruitAdminApi.Repository;
using FruitUserApi.Models;//diff project
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitAdminApi.Controllers
{
    [Authorize(Roles ="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminRepository repo = null;
        public AdminController()
        {
            repo = new AdminRepository();
        }

       

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            List<Admin> list = repo.GetAll();
            if (list.Count == 0)
            {
                return NotFound("No content in list");
            }
            else
            {
                return Ok(list);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult GetAdminById(int id)
        {
            Admin admin = repo.GetAdminById(id);
            if (admin != null)
            {
                return Ok(admin);
            }
            else
            {
                return NotFound(id + "\t is present");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateNewAdmin(Admin admin)
        {

            Admin res = await repo.CreateAdmin(admin);
            
            return Ok(res.AdminName+"\t is created successfully");
            
            
        }
        //get user by id
        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetUserByUserId(int userId)
        {
            User user = await repo.GetUserById(userId);
            return Ok(user);
        }
        //get all feedbacks
        [HttpGet("feedback")]
        
        public ActionResult GetAllFeedbacks()
        {
            List<Feedback> list = repo.GetAllFeedbacks();
            return Ok(list);
        }



    }
}
