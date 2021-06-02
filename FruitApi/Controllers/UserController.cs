using FruitUserApi.Models;
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
    [Authorize(Roles="user")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        UserRepository repo = null;
        public UserController()
        {
            repo = new UserRepository();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            List<User> list = await repo.GetAllDataAsync();
            return Ok(list);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> CreateNewUser(User user)
        {
            
            bool res = await repo.CreateDataAsync(user);
            if (res)
            {
                return Ok(user.UserName + "\t is created successfully");
            }
            else
            {
                return BadRequest(user.UserName + "\t not added");
            }
        }
    }
}
