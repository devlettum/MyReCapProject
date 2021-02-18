using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carManager)
        {
            _carDal = carManager;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public List<Car> GetById(int Id)
        {
            return _carDal.GetById(Id);
        }
    }
}
