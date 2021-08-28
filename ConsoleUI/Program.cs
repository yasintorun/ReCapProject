﻿using Business.Abstract;
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
            CarTest();

            //ColorTest();

            //BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand newBrand = new Brand { Id = 10, Name = "Honda" };
            bool isAdded = brandManager.Add(newBrand);
            Console.WriteLine(isAdded + "\n");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }

            newBrand.Name = "Supra";
            brandManager.Update(newBrand);

            Console.WriteLine("\n" + brandManager.GetById(10).Name);

            brandManager.Delete(newBrand);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Add
            Color newColor = new Color { Id = 6, Name = "Yeşil" };
            bool isAdded = colorManager.Add(newColor);
            Console.WriteLine(isAdded);

            //GetAll
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }

            //Update
            newColor.Name = "Mor";
            colorManager.Update(newColor);

            //GetById
            Console.WriteLine(colorManager.GetById(6).Name);

            //delete
            colorManager.Delete(newColor);

            //GetAll
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
        }

        private static void CarTest()
        {
            ICarService carService = new CarManager(new EfCarDal());

            foreach (var car in carService.GetCarDetails())
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName);
            }
            /*Car newCar = new Car { Id = 8, BrandId = 1, DailyPrice = 10, ModelYear = 2010, Description = "Tss", ColorId = 1 };

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
