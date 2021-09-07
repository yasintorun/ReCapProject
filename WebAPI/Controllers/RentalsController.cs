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
    public class RentalsController : ResponseControllerBase
    {
        private IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_rentalService.GetAll());
        }

        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            return ResponseResult(_rentalService.getRentalsDetails());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_rentalService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            return ResponseResult(_rentalService.Add(rental));
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            return ResponseResult(_rentalService.Update(rental));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Rental rental)
        {
            return ResponseResult(_rentalService.Delete(rental));
        }
    }
}
