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
    public class CustomersController : ResponseControllerBase
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_customerService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_customerService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            return ResponseResult(_customerService.Add(customer));
        }

        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            return ResponseResult(_customerService.Update(customer));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(Customer customer)
        {
            return ResponseResult(_customerService.Delete(customer));
        }
    }
}
