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
    public class CreditCardsController : ResponseControllerBase
    {
        private ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_creditCardService.GetAll());
        }

        [HttpGet("getusercreditcards")]
        public IActionResult GetUserCreditCards(int userId)
        {
            return ResponseResult(_creditCardService.GetCreditCardsByUserId(userId));
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_creditCardService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard creditCard)
        {
            return ResponseResult(_creditCardService.Add(creditCard));
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCard creditCard)
        {
            return ResponseResult(_creditCardService.Update(creditCard));
        }


        [HttpPost("delete")]
        public IActionResult Delete(CreditCard creditCard)
        {
            return ResponseResult(_creditCardService.Delete(creditCard));
        }
    }
}
