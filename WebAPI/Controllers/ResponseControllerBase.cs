using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public abstract class ResponseControllerBase : ControllerBase
    {
        public IActionResult ResponseResult(IResult result)
        {
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
