using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //Tüm ürün açıklamalarını listeleme
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            //Car car2 = new Car {Description = "Çok hızlı gider",BrandId=4,ColorId=3,DailyPrice=160,ModelYear=2008 };
            //carManager.Add(car2);
            Console.WriteLine("---------------FILTRELEME---------------");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.DailyPrice);
            }
        }
    }
}
