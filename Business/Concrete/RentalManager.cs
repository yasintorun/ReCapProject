using Business.Abstract;
using Business.Adapters.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private IPaymentService _paymentService;
        private IFindexScoreService _findexScoreService;
        private ICarService _carService;
        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService, IFindexScoreService findexScoreService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
            _findexScoreService = findexScoreService;
            _carService = carService;
        }

        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [TransactionScopeAspect()]
        public IResult RentCar(PaymentInfoDto paymentDto)
        {
            Rental rental = new Rental
            {
                CarId = paymentDto.CarId,
                CustomerId = paymentDto.UserId,
                RentDate = paymentDto.RentDate,
                ReturnDate = paymentDto.ReturnDate
            };

            IDataResult<int> carFindexScoreResult = _carService.GetCarFindexScore(rental.CarId);
            IResult result = BusinessRules.Run(carFindexScoreResult, CheckRentCar(rental.CarId), CheckUserFindexScore(carFindexScoreResult.Data, rental.CustomerId));
            if (result != null)
            {
                return result;
            }
            
            IResult payResult = _paymentService.Pay(paymentDto);
            if(!payResult.Success)
            {
                return payResult;
            }

            this.Add(rental);

            return new SuccessResult("Ödeme başarılı, Araç kiralandı.");
        }

        public IResult CheckRentCar(int carId)
        {
            Rental isCarRented = this.GetByCarId(carId).Data;
            if (isCarRented != null && isCarRented.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarRented);
            }
            return new SuccessResult();
        }

        public IResult CheckUserFindexScore(int minRequiredFindexScore, int userId)
        {
            int userFindexScore = _findexScoreService.GetUserFindexScore(userId);

            if(userFindexScore < minRequiredFindexScore)
            {
                return new ErrorResult(Messages.UserFindexScoreInsufficient);
            }
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId), Messages.RentalGetCarId);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.RentalGot);
        }

        public IDataResult<List<RentalDetailDto>> getRentalsDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.rentalDetails(), "Araba kiraları listelendi");
        }

        

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
