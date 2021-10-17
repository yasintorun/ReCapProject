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
        IDataResult<Car> AddWithDetail(Car car);

        IDataResult<List<CarDetailDto>> GetCarsByColorId(string color);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(string brand);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<CarDetailDto> GetCarDetail(int carId);

        IResult TransactionalTest(Car car);

        IDataResult<int> GetCarTotalPrice(int carId, DateTime rentDate, DateTime returnDate);
        IDataResult<List<CarDetailDto>> GetCarByFilter(CarFilterDto carFilterDto);

        IDataResult<int> GetCarFindexScore(int carId);
        IDataResult<int> GetTotalCarCount();
    }
}
