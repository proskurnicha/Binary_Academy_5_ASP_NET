using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Binary_Academy_5_ASP_NET.Models;
namespace Binary_Academy_5_ASP_NET.Controllers
{
    [Produces("application/json")]
    [Route("api/ManipulateData")]
    public class ManipulateDataController : Controller
    {
        UsersService service;

        public ManipulateDataController()
        {
            service = new UsersService();
        }

        // GET: api/ManipulateData/GetCountComments
        [HttpGet("GetCountComments")]
        public IActionResult GetCountComments()
        {
            return View();
        }

        //POST: api/ManipulateData/GetCountComments
        [HttpPost("GetCountComments")]
        public IActionResult GetCountComments(int id)
        {
            int countComments = service.GetCountCommentsByUserId(id);
            ViewData["countComments"] = countComments;
            ViewData["id"] = id;
            return View("GetCountComments");
        }


        // GET: api/ManipulateData/GetCommentsByUserId
        [HttpGet("GetCommentsByUserId")]
        public IActionResult GetCommentsByUserId()
        {
            return View();
        }

        //POST: api/ManipulateData/GetCountComments
        [HttpPost("GetCommentsByUserId")]
        public IActionResult GetCommentsByUserId(int id)
        {
            List<Comment> comments = service.GetCommentsByUserId(id);
            ViewData["id"] = id;
            return View(comments);
        }


        // GET: api/ManipulateData/GetDoneTodosByUserId
        [HttpGet("GetDoneTodosByUserId")]
        public IActionResult GetDoneTodosByUserId()
        {
            return View();
        }

        //POST: api/ManipulateData/GetDoneTodosByUserId
        [HttpPost("GetDoneTodosByUserId")]
        public IActionResult GetDoneTodosByUserId(int id)
        {
            List<Todo> todos = service.GetDoneTodosByUserId(id);
            ViewData["id"] = id;
            return View(todos);
        }

        

        // POST: api/ManipulateData
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/ManipulateData/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
