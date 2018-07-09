using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Academy_5_ASP_NET.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            service = new UsersService();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetUser(int id)
        {
            return View(service.GetUserById(id));
        }

    }
}
