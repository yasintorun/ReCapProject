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

        private BankAccount _bankAccount;

        public FakeBankManager()
        {
            //Fake bilgi kullandığımız için tüm bilgileri kendimiz oluşturacağız.
            _bankAccount = new BankAccount
            {
                Card = new CreditCardDto //Kart bilgileri
                {
                    CardName = "User us",
                    CardNumber = "1254586958987452",
                    CVV = "094",
                    ExpirationDate = "04/22"
                },
                MoneyAmount = 1500000 //Kullanıcının hesabındaki para miktarı
            };
        }

        public IResult Pay(CreditCardDto card, int payAmount)
        {
            IResult result = BusinessRules.Run(CheckCreditCard(card), CheckEnoughMoney(payAmount));
            if(result != null)
            {
                return result;
            }
            
            _bankAccount.MoneyAmount -= payAmount;
            return new SuccessResult("Ödeme başarılı");

        }

        IResult CheckCreditCard(CreditCardDto card)
        {
            if(!card.CardName.ToLower().Equals(_bankAccount.Card.CardName.ToLower())
                || !card.CardNumber.Equals(_bankAccount.Card.CardNumber)
                || !card.CVV.Equals(_bankAccount.Card.CVV)
                || !card.ExpirationDate.Equals(_bankAccount.Card.ExpirationDate))
            {
                return new ErrorResult("Kredi kartı hatalı!");
            }
            return new SuccessResult();
        }

        IResult CheckEnoughMoney(int money)
        {
            if(_bankAccount.MoneyAmount < money)
            {
                return new ErrorResult("Bakiye yetersiz");
            }
            return new SuccessResult();
        }

    }

    class BankAccount
    {
        public int MoneyAmount { get; set; }
        public CreditCardDto Card { get; set; }
    }


}
