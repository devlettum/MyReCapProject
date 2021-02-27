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
            
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CompanyName = "ABC Company"});
            customerManager.Add(new Customer { CompanyName = "XYZ Company"});
            customerManager.Add(new Customer { CompanyName = "QWE Company"});

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("Şirket Adı : {0}",customer.CompanyName);
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
