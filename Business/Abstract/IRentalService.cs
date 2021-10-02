using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : ICrudService<Rental>
    {
        IDataResult<Rental> Add2(Rental rental);
        IDataResult<List<RentalDetailDto>> getRentalsDetails();

        IDataResult<Rental> GetByCarId(int carId);

        IResult CheckRentCar(int carId);
        IResult Rentalable(Rental rental);
        IDataResult<int> GetTotalRentalCount();
    }
}
