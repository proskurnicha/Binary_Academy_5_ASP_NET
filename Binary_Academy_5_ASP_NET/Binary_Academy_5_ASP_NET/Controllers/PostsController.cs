﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binary_Academy_5_ASP_NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Academy_5_ASP_NET.Controllers
{
    public class PostsController : Controller
    {
        private UsersService service;

        public PostsController()
        {
            service = new UsersService();
        }

        // GET: Posts
        [HttpGet]
        public IActionResult Index()
        {
            return View(service.GetPosts());
        }


        [HttpGet("{id}", Name = "GetPost")]
        public IActionResult GetPost(int id)
        {
            return View(service.GetPostById(id));
        }
    }
}
