using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binary_Academy_5_ASP_NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Academy_5_ASP_NET.Controllers
{
    [Produces("application/json")]
    [Route("api/Posts")]
    public class PostsController : Controller
    {
        private UsersService service;

        public PostsController()
        {
            service = new UsersService();
        }

        // GET: api/Posts
        [HttpGet]
        public IActionResult Index()
        {
            return View(service.GetPosts());
        }

        // GET: api/Posts/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return View(service.GetUserById(id));
        }
    }
}
