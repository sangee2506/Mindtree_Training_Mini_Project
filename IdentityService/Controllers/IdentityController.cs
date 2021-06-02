using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using IdentityService.Repository;
using FruitUserApi.Models;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly SignInRepository repo = null;
        public IdentityController()
        {
            repo = new SignInRepository();
        }

        //Authenticate User
        [AllowAnonymous]
        [HttpPost("authenticate/person")]
        public IActionResult AuthenticateUser([FromBody] Person person)
        {
           
            Task<Values> values = repo.LoginUserAsync(person);
            return Ok(values);
        }
      
    }
}
