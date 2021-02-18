using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=180,ModelYear=2006,Description="Şehir içi işleriniz için ideal"},
                new Car{CarId=2,BrandId=2,ColorId=1,DailyPrice=190,ModelYear=2008,Description="Uzun yol için ideal yakıt tüketimi"},
                new Car{CarId=3,BrandId=2,ColorId=2,DailyPrice=220,ModelYear=2009,Description="Bu araç şuanda kiralanamaz"},
                new Car{CarId=4,BrandId=3,ColorId=3,DailyPrice=220,ModelYear=2017,Description="Araç tamirde..."},
                new Car{CarId=5,BrandId=2,ColorId=1,DailyPrice=185,ModelYear=2009,Description="Her türlü işinizi görür."},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(deletedCar);
        }
        public void Update(Car car)
        {
            Car updatedCar = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }
    }
}
