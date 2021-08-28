using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new EfCarDal());

            Car newCar = new Car { Id = 8, BrandId = 1, DailyPrice = 10, ModelYear = 2010, Description = "Tss" , ColorId=1};

            bool isAdded = carService.Add(newCar);

            Console.WriteLine(isAdded.ToString());

            /*List<Car> myCars = carService.GetCarsByColorId(1);

            foreach (var myCar in myCars)
            {
                Console.WriteLine(myCar.Description);
            }
            */

        }
    }
}
