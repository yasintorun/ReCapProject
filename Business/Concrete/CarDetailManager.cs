using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Transaction;
using System.Linq;

namespace Business.Concrete
{
    public class CarDetailManager : ICarDetailService
    {
        private ICarDetailDal _carDetailDal;

        public CarDetailManager(ICarDetailDal carDetailDal)
        {
            _carDetailDal = carDetailDal;
        }

        public IResult Add(CarDetail entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarDetail entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetail>> GetAll()
        {
            return new SuccessDataResult<List<CarDetail>>(_carDetailDal.GetAll());
        }

        public IDataResult<CarDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
