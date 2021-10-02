using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfPaymentDal : EfEntityRepositoryBase<Payment, ReCapContext>, IPaymentDal
    {
        public List<OrderDetailDto> GetAllOrderDetails(int userId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var results = from p in context.Payments
                              join r in context.Rentals on p.RentalId equals r.Id
                              join c in context.Cars on r.CarId equals c.Id
                              join b in context.Brands on c.BrandId equals b.Id
                              where (userId == r.CustomerId)
                              select new OrderDetailDto { BrandName = b.Name, CarName = c.Name, RentDate = r.RentDate, ReturnDate = r.ReturnDate, TotalAmount = p.Amount };
                return results.ToList();
            }
        }

        public int GetTotalMoneyEarned()
        {
            using (ReCapContext context = new ReCapContext())
            {
                int sum = context.Payments.Select(p => p.Amount).Sum();
                return sum;
            }
        }
    }
}
