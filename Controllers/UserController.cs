using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager2.Context;
using TaskManager2.Models;

namespace TaskManager2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _dbContext;

        public UserController(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/user
        [HttpGet]
        public IActionResult GetUsers()
        {
            // Retrieve all users from the database
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        // POST api/user
        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            // Add the new user to the database
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok(user);
        }     
    }
}