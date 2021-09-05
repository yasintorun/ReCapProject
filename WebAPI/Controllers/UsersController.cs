using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core.Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ResponseControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_userService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_userService.GetById(id));
        }

        /*[HttpPost("add")]
        public IActionResult Add(User user)
        {
            return ResponseResult(_userService.Add(user));
        }*/

        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            return ResponseResult(_userService.Update(user));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            return ResponseResult(_userService.Delete(user));
        }
    }
}
