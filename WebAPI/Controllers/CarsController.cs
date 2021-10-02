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
    public class CarsController : ResponseControllerBase
    {
        private ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_carService.GetAll());
        }

        [HttpGet("getcartotalprice")]
        public IActionResult GetCarTotalPrice(int carId, DateTime rentDate, DateTime returnDate)
        {
            return ResponseResult(_carService.GetCarTotalPrice(carId, rentDate, returnDate));
        }

        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            return ResponseResult(_carService.GetCarDetails());
        }
        [HttpGet("getcarbyfilter")]
        public IActionResult GetCarByFilter(string brands, string colors, int minPrice, int maxPrice)
        {
            CarFilterDto filter = new CarFilterDto 
            { 
                Brands = brands?.Split(',')?.Select(p => Convert.ToInt32(p))?.ToList(),
                Colors = colors?.Split(',')?.Select(p => Convert.ToInt32(p))?.ToList(),
                MinPrice = minPrice,
                MaxPrice = maxPrice,
            };
            return ResponseResult(_carService.GetCarByFilter(filter));
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int carId)
        {
            return ResponseResult(_carService.GetCarDetail(carId));
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_carService.GetById(id));
        }

        [HttpGet("getcarsbycolor")]
        public IActionResult GetCarsByColorId(string color)
        {
            return ResponseResult(_carService.GetCarsByColorId(color));
        }

        [HttpGet("getcarsbybrand")]
        public IActionResult GetCarsByBrandId(string brand)
        {
            return ResponseResult(_carService.GetCarsByBrandId(brand));
        }



        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            return ResponseResult(_carService.Add(car));
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            return ResponseResult(_carService.Update(car));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Car car)
        {
            return ResponseResult(_carService.Delete(car));
        }

        [HttpPost("TransactionalTest")]
        public IActionResult TransactionalTest(Car car)
        {
            return ResponseResult(_carService.TransactionalTest(car));
        }


        [HttpGet("totalcarcount")]
        public IActionResult GetTotalCarCount()
        {
            return ResponseResult(_carService.GetTotalCarCount());
        }
    }
}
