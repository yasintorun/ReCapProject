using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentInfoDto : IDto
    {
        public int UserId { get; set; }
        public int CarId { get; set; }
        public int Amount { get; set; }
        public CreditCardDto CreditCard { get; set; }
        public DateTime? RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
