using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : ICrudService<CarImage>
    {
        IResult UploadCarImage(IFormFile imageFile, CarImage carId);

        IDataResult<List<CarImage>> GetCarImagesByCarId(int carId);
        IDataResult<CarImage> GetFirstOrDefaultByCarId(int carId);
    }
}
