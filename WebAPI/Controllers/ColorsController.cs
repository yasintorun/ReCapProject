using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ResponseControllerBase
    {
        private IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_colorService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_colorService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            return ResponseResult(_colorService.Add(color));
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            return ResponseResult(_colorService.Update(color));
        }


        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            return ResponseResult(_colorService.Delete(color));
        }
    }
}
