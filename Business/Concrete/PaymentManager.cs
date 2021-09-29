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
        public PaymentManager(IPaymentDal paymentDal, IBankService bankService, ICarService carService, ICreditCardService creditCardService)
        {
            _paymentDal = paymentDal;
            _bankService = bankService;
            _carService = carService;
            _creditCardService = creditCardService;
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
        public IResult Pay(PaymentInfoDto paymentInfo, bool creditCardSave=false)
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

            _paymentDal.Add(new Payment
            {
                UserId = paymentInfo.UserId,
                CarId = paymentInfo.CarId,
                Amount = paymentInfo.Amount,
                CreditCardNumber = paymentInfo.CreditCard.CardNumber,
                Date = DateTime.Now
            });

            return new SuccessResult(Messages.PaySuccess);
        }
    }
}
