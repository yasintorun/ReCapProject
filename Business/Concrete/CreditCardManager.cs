using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(ExistsCreditCardNumber(creditCard));
            if(result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.CreditCardListed);
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(b => b.Id == creditCardId), Messages.CreditCardGot);
        }

        public IDataResult<List<CreditCard>> GetCreditCardsByUserId(int userId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.UserId == userId), Messages.CreditCardListedByUserId);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }


        public IResult ExistsCreditCardNumber(CreditCard card)
        {
            bool isExists = _creditCardDal.GetAll(c => c.CardNumber.Equals(card.CardNumber)).Any();
            if(isExists)
            {
                return new ErrorResult("Kredi kartı kayıtlı");
            }
            return new SuccessResult();
        }

    }
}
