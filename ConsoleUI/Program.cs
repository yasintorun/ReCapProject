using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());

            Car newCar = new Car { Id = 6, BrandId = 4, DailyPrice = 100000, ModelYear = 2010, Description = "Temiz araba" };

            carService.Add(newCar);
            carService.Delete(new Car { Id=1});

            Car updateCar = new Car { Id = 2, BrandId = 5, DailyPrice = 190000, ModelYear = 2015, Description = "Güncellendi araba" };
            carService.Update(updateCar);



            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            Console.WriteLine("\n\n");

            Car myCar = carService.GetById(3);

            Console.WriteLine(myCar.Description);

        }
    }
}
