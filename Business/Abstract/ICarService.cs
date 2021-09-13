using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudService<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarsByColorId(string color);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(string brand);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarByFilter(string brand, string color);

        IDataResult<CarDetailDto> GetCarDetail(int carId);

        IResult TransactionalTest(Car car);
    }
}
