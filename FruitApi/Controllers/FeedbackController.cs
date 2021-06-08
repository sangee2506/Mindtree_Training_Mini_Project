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
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackRepository repo = null;
        public FeedbackController()
        {
            repo = new FeedbackRepository();
        }
        [HttpGet]
        public ActionResult GetAllFeedbacks()
        {
            List<Feedback> list = repo.GetAllFeedback();
            return Ok(list);
        }

        [HttpGet("{userId}")]
        public ActionResult GetAllFeedbacksByUserId(int userId)
        {
            List<Feedback> list = repo.GetAllDataById(userId);
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound(userId + "\t is present");
            }
        }

        [HttpPost]
        public ActionResult CreateFeedbacks(Feedback feedback)
        {
            bool res = repo.CreateFeedback(feedback);
            if (res)
            {
                return Ok("added");
            }
            else
            {
                return BadRequest("not added");
            }
        }

    }
}
