using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars = new List<Car>
        {
            new Car{Id=1, BrandId=1, DailyPrice=150000, ModelYear=2011, Description="2011 model temiz araba"},
            new Car{Id=2, BrandId=2, DailyPrice=250000, ModelYear=2017, Description="2017 model az kullanılmış araba"},
            new Car{Id=3, BrandId=1, DailyPrice=110000, ModelYear=2015, Description="2015 model sahibinden araba"},
            new Car{Id=4, BrandId=3, DailyPrice=540000, ModelYear=2019, Description="Son model araba"},
            new Car{Id=5, BrandId=2, DailyPrice=75000, ModelYear=2004, Description="2004 model temiz boyasız ucuz araba"},
        };
        public List<Car> GetAll()
        {
            return _cars;
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }
        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
