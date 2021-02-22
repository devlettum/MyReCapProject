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
            //CategoryTest(carManager);
            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3}",c.CarName,c.BrandName,c.ColorName,c.DailyPrice);
            }
            
        }

        private static void CategoryTest(CarManager carManager)
        {
            //Tüm ürün açıklamalarını listeleme
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
