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
    [Route("api/Todos")]
    public class TodosController : Controller
    {
        private UsersService service;

        public TodosController()
        {
            service = new UsersService();
        }
        // GET: api/Todos/id
        [HttpGet("GetTodo")]
        public IActionResult GetTodo(int id)
        {
            return View(service.GetTodoById(id));
        }
    }
}
