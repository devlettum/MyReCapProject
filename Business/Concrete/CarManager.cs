using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    //BİR İŞ SINIFI BAŞKA BİR SINIFI NEWLEMEZ !!!!!!
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal) //Bana kullandığının teknolojinin referansını ver.
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            //Business Codes
            if (car.CarName.Length < 2 && car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }
        public IResult Update(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult();
            }
            return new ErrorResult();

        }
        public Car Get(Expression<Func<Car, bool>> filter)
        {
           return _carDal.Get(filter);
        }

        public List<Car> GetAll()
        {
            //iş kodları        
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==id));
        }


        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        IDataResult<List<Car>> ICarService.GetAll()
        {
            throw new NotImplementedException();
        }

        //public List<Car> GetById(int Id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
