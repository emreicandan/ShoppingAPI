using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingAPI.Entities;
using ShoppingAPI.Repositories.Abstract;
using ShoppingAPI.Repositories.Concretes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }


        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_userRepository.Get(user => user.Id == id));
        }


        [HttpPost("Add")]
        public IActionResult Add([FromBody]User user)
        {
                return Ok(_userRepository.Add(user));
        }


        [HttpPut("Update")]
        public IActionResult Update([FromBody]User user)
        {
            return Ok(_userRepository.Update(user));
        }


        [HttpDelete("DeleteById/{id}")]
        public IActionResult Delete(Guid id)
        {
            var user = _userRepository.Get(user => user.Id == id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(_userRepository.Delete(user));
        }
    }
}

