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

        #region GetCountComments
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

        #endregion

        #region GetCommentsByUserId

        // GET: api/ManipulateData/GetCommentsByUserId
        [HttpGet("GetCommentsByUserId")]
        public IActionResult GetCommentsByUserId()
        {
            return View();
        }

        //POST: api/ManipulateData/GetCommentsByUserId
        [HttpPost("GetCommentsByUserId")]
        public IActionResult GetCommentsByUserId(int id)
        {
            List<Comment> comments = service.GetCommentsByUserId(id);
            ViewData["id"] = id;
            return View("GetCommentsByUserId", comments);
        }
        #endregion

        #region GetDoneTodosByUserId
        // GET: api/ManipulateData/GetDoneTodosByUserId
        [HttpGet("GetDoneTodosByUserId")]
        public IActionResult GetDoneTodosByUserId()
        {
            return View("GetDoneTodosByUserId");
        }

        //POST: api/ManipulateData/GetDoneTodosByUserId
        [HttpPost("GetDoneTodosByUserId")]
        public IActionResult GetDoneTodosByUserId(int id)
        {
            List<Todo> todos = service.GetDoneTodosByUserId(id);
            ViewData["id"] = id;
            return View("GetDoneTodosByUserId", todos);
        }
        #endregion

        #region GetOrderedListOfUsers
        // GET: api/ManipulateData/GetOrderedListOfUsers
        [HttpGet("GetOrderedListOfUsers")]
        public IActionResult GetOrderedListOfUsers()
        {
            List<User> users = service.GetOrderedListOfUsers();
            return View("GetOrderedListOfUsers", users);
        }

        #endregion

        #region GetInfoAboutPostById
        // GET: api/ManipulateData/GetInfoAboutPostById
        [HttpGet("GetInfoAboutPostById")]
        public IActionResult GetInfoAboutPostById()
        {
            return View();
        }

        //POST: api/ManipulateData/GetInfoAboutPostById
        [HttpPost("GetInfoAboutPostById")]
        public IActionResult GetInfoAboutPostById(int id)
        {
            int countComments = service.GetCountCommentsByUserId(id);
            ViewData["countComments"] = countComments;
            ViewData["id"] = id;
            return View("GetCountComments");
        }
        #endregion

    }
}
