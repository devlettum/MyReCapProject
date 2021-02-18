using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.DailyPrice);
            }
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
           
        }
    }
}
