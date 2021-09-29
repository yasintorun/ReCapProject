using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new CarDetailDto {Name = c.Name, Description = c.Description, BrandName = b.Name, ColorName = clr.Name, CarId = c.Id, DailyPrice = c.DailyPrice, FindexPuan=c.FindexPuan };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByFilter(CarFilterDto carFilterDto)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where (carFilterDto.Brands ==null || carFilterDto.Brands.Contains(b.Id))
                                && (carFilterDto.Colors == null || carFilterDto.Colors.Contains(clr.Id))
                                && (c.DailyPrice >= carFilterDto.MinPrice)
                                && (carFilterDto.MaxPrice == 0 || c.DailyPrice <= carFilterDto.MaxPrice)
                             select new CarDetailDto { Name = c.Name, Description = c.Description, BrandName = b.Name, ColorName = clr.Name, CarId = c.Id, DailyPrice = c.DailyPrice, FindexPuan=c.FindexPuan };
                return result.ToList();
            }
        }
    }
}
