using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private IBankService _bankService;
        private ICarService _carService;
        private ICreditCardService _creditCardService;
        private IRentalService _rentalService;
        public PaymentManager(IPaymentDal paymentDal, IBankService bankService, ICarService carService, ICreditCardService creditCardService, IRentalService rentalService)
        {
            _paymentDal = paymentDal;
            _bankService = bankService;
            _carService = carService;
            _creditCardService = creditCardService;
            _rentalService = rentalService;
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListed);
        }

        public IDataResult<List<OrderDetailDto>> GetAllUserOrders(int userId)
        {
            return new SuccessDataResult<List<OrderDetailDto>>(_paymentDal.GetAllOrderDetails(userId), Messages.GetAllUserOrders);
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id));
        }

        [TransactionScopeAspect()]
        public IResult Pay(PaymentInfoDto paymentInfo, bool creditCardSave=false)
        {
            //Gerçekten öyle bir araba var mı?
            IDataResult<Car> carResult = _carService.GetById(paymentInfo.CarId);
            if(!carResult.Success)
            {
                return carResult;
            }
            if(carResult.Data == null)
            {
                return new ErrorResult("Araba bilgisi hatalı");
            }

            Rental rental = new Rental
            {
                CarId = paymentInfo.CarId,
                CustomerId = paymentInfo.UserId,
                RentDate = paymentInfo.RentDate,
                ReturnDate = paymentInfo.ReturnDate
            };

            //Kiralanabilir mi?
            IResult rentalResult = _rentalService.Rentalable(rental);
            if(!rentalResult.Success)
            {
                return rentalResult;
            }


            IResult result = _bankService.Pay(paymentInfo.CreditCard, paymentInfo.Amount);
            if(!result.Success)
            {
                return result;
            }
            if(creditCardSave)
            {
                try
                {
                    paymentInfo.CreditCard.UserId = paymentInfo.UserId;
                    _creditCardService.Add(paymentInfo.CreditCard);
                } catch{}
            }

            IDataResult<Rental> addedRentalResult = _rentalService.Add2(rental);
            if(!addedRentalResult.Success || addedRentalResult.Data == null)
            {
                return new ErrorResult("Hata oluştu");
            }

            _paymentDal.Add(new Payment
            {
                RentalId = addedRentalResult.Data.Id,
                Amount = paymentInfo.Amount,
                CreditCardNumber = paymentInfo.CreditCard.CardNumber,
                Date = DateTime.Now
            });

            return new SuccessResult(Messages.PaySuccess);
        }

        public IDataResult<int> TotalMoneyEarned()
        {
            return new SuccessDataResult<int>(_paymentDal.GetTotalMoneyEarned());
        }
    }
}
