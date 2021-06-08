using FruitUserApi.CustomException;
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
    [Authorize(Roles = "user")]
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
            try
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
            catch(Exception e)
            {
                return Ok("Ooops! Exception is caught=>"+e.Message);
            }
           
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUserByUserId(int userId)
        {
            User user= await repo.GetDataByUserId(userId);
            return Ok(user);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(User user)
        {
            try
            {
                if (user != null)
                {
                    bool res = await repo.UpdateData(user);
                    if (res)
                    {
                        return Ok("Updated user Successfully");
                    }
                    else
                    {
                        return BadRequest("User can not be updated due to bad data");
                    }
                }
                else
                {
                    throw new NullValuesException("Dear user Please Fill all fields :(");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Ooops! Exception is caught=>" + e.Message);
            }

        }
    }
}
