using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Pay(PaymentInfoDto paymentInfo, bool creditCardSave=false);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int id);
    }
}
