using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDetailsController : ResponseControllerBase
    {
        private ICarDetailService _carDetailService;

        public CarDetailsController(ICarDetailService carDetailService)
        {
            _carDetailService = carDetailService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_carDetailService.GetAll());
        }

        [HttpPost("add")]
        public IActionResult Add(CarDetail carDetail)
        {
            return ResponseResult(_carDetailService.Add(carDetail));
        }

    }
}
