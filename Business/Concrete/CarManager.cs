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
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            this._carDal = carDal;
        }

        //[SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [CacheAspect]
        public IResult Add(Car car)
        {
            if(car.Description.Length <= 2)
            {
                return new ErrorResult(Messages.CarNameAtLeast2Char);
            }
            if(car.DailyPrice < 0)
            {
                return new ErrorResult(Messages.CarDailyPriceNotZero);
            }
            try
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            } catch
            {
                return new ErrorResult(Messages.ErrorOccurred);
            }
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarGot);
        }

        public IDataResult<List<CarDetailDto>> GetCarByFilter(string brand, string color)
        {
            brand += ""; //null check control
            color += "";
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName.Contains(brand) && c.ColorName.Contains(color)), "Filtrelenmiş arabalar getirildi");
        }

        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.CarId == carId).FirstOrDefault(), "Araba detayı getirildi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(), Messages.CarListedInDetail);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(string brand)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brand), Messages.CarListedByBrand);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(string color)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == color), Messages.CarListedByColor);
        }

        [TransactionScopeAspect]
        public IResult TransactionalTest(Car car)
        {
            _carDal.Add(car);
            if(car.DailyPrice < 1000000)
            {
                throw new Exception("hata");
            }
            _carDal.Add(car);
            return new SuccessResult();

        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }   
    }
}
