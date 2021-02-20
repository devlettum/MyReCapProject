using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    //BİR İŞ SINIFI BAŞKA BİR SINIFI NEWLEMEZ !!!!!!
    public class CarManager : ICarService,ICarDal
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) //Bana kullandığının teknolojinin referansını ver.
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba eklenemedi.İsim en az 2 karakter olmalı veya fiyatı 0'dan fazla olmalı.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
           return _carDal.Get(filter);
        }

        public List<Car> GetAll()
        {
            //iş kodları        
            return _carDal.GetAll();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll(filter);
        }


        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p=>p.BrandId==id);
        }


        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        //public List<Car> GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        public void Update(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Araba güncellenemedi.Güncellenen isim en az 2 karakter olmalı veya fiyatı 0'dan fazla olmalı.");
            }
        }
    }
}
