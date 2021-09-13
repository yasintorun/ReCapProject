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
        public PaymentManager(IPaymentDal paymentDal, IBankService bankService, ICarService carService)
        {
            _paymentDal = paymentDal;
            _bankService = bankService;
            _carService = carService;
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListed);
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.Id == id));
        }

        [TransactionScopeAspect()]
        public IResult Pay(PaymentInfoDto paymentInfo)
        {
            IDataResult<Car> carResult = _carService.GetById(paymentInfo.CarId);
            if(!carResult.Success)
            {
                return carResult;
            }
            if(carResult.Data == null)
            {
                return new ErrorResult("Araba bilgisi hatalı");
            }
            int payAmount = carResult.Data.DailyPrice;

            IResult result = _bankService.Pay(paymentInfo.CreditCard, payAmount);
            if(!result.Success)
            {
                return result;
            }

            _paymentDal.Add(new Payment
            {
                UserId = paymentInfo.UserId,
                CarId = paymentInfo.CarId,
                Amount = payAmount,
                CreditCardNumber = paymentInfo.CreditCard.CardNumber,
                Date = DateTime.Now
            });

            return new SuccessResult(Messages.PaySuccess);
        }
    }
}
