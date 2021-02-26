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
            Car car1 = new Car { BrandId =7, ColorId = 2, CarName = "Seat Leon", DailyPrice = 260, Description = "Şuan kiralık!", ModelYear = 2017 };
            //carManager.Add(car1);
            var result = carManager.GetCarDetails();
            //CategoryTest(carManager);
            if (result.Success)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3}", c.CarName, c.BrandName, c.ColorName, c.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
