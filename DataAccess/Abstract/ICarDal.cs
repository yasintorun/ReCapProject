﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        List<CarDetailDto> GetCarDetailsByFilter(CarFilterDto carFilterDto);
        int GetTotalCarCount();
    }
}
