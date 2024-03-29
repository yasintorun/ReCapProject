﻿using Business.Abstract;
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

       // [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [CacheAspect]
        public IResult Add(Car car)
        {
            try
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            } catch
            {
                return new ErrorResult(Messages.ErrorOccurred);
            }
        }

        [TransactionScopeAspect]
        public IDataResult<Car> AddWithDetail(Car car)
        {
            Car addCar = _carDal.Add(car);
            return new SuccessDataResult<Car>(addCar, Messages.CarAdded);
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

        public IDataResult<List<CarDetailDto>> GetCarByFilter(CarFilterDto carFilterDto)
        {   
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsByFilter(carFilterDto), "Filtrelenmiş arabalar getirildi");
        }

        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.CarId == carId).FirstOrDefault(), "Araba detayı getirildi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(), Messages.CarListedInDetail);
        }

        public IDataResult<int> GetCarFindexScore(int carId)
        {
            IDataResult<CarDetailDto> carResult = this.GetCarDetail(carId);
            if(!carResult.Success || carResult.Data == null)
            {
                return new ErrorDataResult<int>(-1, carResult.Message);
            }
            return new SuccessDataResult<int>(carResult.Data.FindexPuan, Messages.GetCarFindexScore);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(string brand)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brand), Messages.CarListedByBrand);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(string color)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == color), Messages.CarListedByColor);
        }

        public IDataResult<int> GetCarTotalPrice(int carId, DateTime rentDate, DateTime returnDate)
        {
            IDataResult<Car> currentCarResult = this.GetById(carId);
            if(currentCarResult.Success == false || currentCarResult.Data == null)
            {
                return new ErrorDataResult<int>("Araba bulunamadı.");
            }

            int totalDays = (int)(returnDate - rentDate).TotalDays;
            int totalPrice = totalDays * currentCarResult.Data.DailyPrice;
            return new SuccessDataResult<int>(totalPrice);
        }

        public IDataResult<int> GetTotalCarCount()
        {
            return new SuccessDataResult<int>(_carDal.GetTotalCarCount());
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
