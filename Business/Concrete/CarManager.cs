using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal carDal;

        public CarManager(ICarDal carDal)
        {
            this.carDal = carDal;
        }

        public void Add(Car car)
        {
            carDal.Add(car);
        }

        public void Delete(Car car)
        {
            carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return carDal.GetById(id);
        }

        public void Update(Car car)
        {
            carDal.Update(car);
        }
    }
}
