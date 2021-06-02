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
        public ActionResult GetAllAdmins()
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
            Admin admin = repo.GetDataById(id);
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
        public ActionResult CreateNewAdmin(Admin admin)
        {

            Admin res = repo.CreateDataAsync(admin);
            
            return Ok(res.AdminName+"\t is created successfully");
            
            
        }


    }
}
