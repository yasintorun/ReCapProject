using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //Bu sınıf fake servis için kullanılmıştır.
    public class FakeBankManager : IBankService
    {
        public FakeBankManager()
        {

        }

        public IResult Pay(CreditCard card, int payAmount)
        {
            IResult result = BusinessRules.Run(CheckCreditCard(card), CheckEnoughMoney(payAmount));
            if(result != null)
            {
                return result;
            }

            return new SuccessResult("Ödeme başarılı");

        }

        IResult CheckCreditCard(CreditCard card)
        {
            if(card.CardNumber.Length != 16)
            {
                return new ErrorResult("Kredi kartı hatalı!");
            }
            return new SuccessResult();
        }

        IResult CheckEnoughMoney(int money)
        {
            if(money > 100000) //Yüz binden büyük ise bakiye yetersiz olsun.
            {
                return new ErrorResult("Bakiye yetersiz");
            }
            return new SuccessResult();
        }

    }
}
