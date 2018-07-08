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
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            service = new UsersService();
        }
        
        // GET: api/Users
        [HttpGet]
        public IActionResult Index()
        {
            return View(service.GetUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return View(service.GetUserById(id));
        }
        
        // POST: api/Users
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
