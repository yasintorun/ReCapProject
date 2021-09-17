using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ResponseControllerBase
    {
        private ICarImageService _carImageService;
        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            return ResponseResult(_carImageService.GetAll());
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            return ResponseResult(_carImageService.GetById(id));
        }

        [HttpGet("getfirstimagebycarid")]
        public IActionResult GetFirstOrDefaultByCarId(int carId)
        {
            return ResponseResult(_carImageService.GetFirstOrDefaultByCarId(carId));
        }

        [HttpGet("getCarImagesByCarId")]
        public IActionResult GetCarImagesByCarId(int carId)
        {
            return ResponseResult(_carImageService.GetCarImagesByCarId(carId));
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile imageFile, [FromForm] CarImage carImage)
        {
            return ResponseResult(_carImageService.UploadCarImage(imageFile, carImage));
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            return ResponseResult(_carImageService.Update(carImage));
        }


        [HttpDelete("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            //return Ok(ImageFileHelper.GetDefaultCarImagePath());
            return ResponseResult(_carImageService.Delete(carImage));
        }
    }
}
