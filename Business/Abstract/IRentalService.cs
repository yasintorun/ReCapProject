﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : ICrudService<Rental>
    {
        IDataResult<List<RentalDetailDto>> getRentalsDetails();

        IDataResult<Rental> GetByCarId(int carId);

        IResult CheckRentCar(int carId);
        IResult RentCar(PaymentInfoDto payment, bool creditCardSave = false);
    }
}
