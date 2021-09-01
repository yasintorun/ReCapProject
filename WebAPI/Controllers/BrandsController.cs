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
    public class BrandsController : ResponseControllerBase
    {
        private IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_brandService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_brandService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand)
        {
            return ResponseResult(_brandService.Add(brand));
        }

        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            return ResponseResult(_brandService.Update(brand));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Brand brand)
        {
            return ResponseResult(_brandService.Delete(brand));
        }
    }
}
