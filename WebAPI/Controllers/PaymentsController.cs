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
    public class PaymentsController : ResponseControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_paymentService.GetAll());
        }

        [HttpGet("getalluserorders")]
        public IActionResult GetAllUserOrders(int userId)
        {
            return ResponseResult(_paymentService.GetAllUserOrders(userId));
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_paymentService.GetById(id));
        }

        [HttpPost("pay")]
        public IActionResult Pay(PaymentInfoDto paymentInfo, bool save)
        {
            return ResponseResult(_paymentService.Pay(paymentInfo, save));
        }
    }
}
