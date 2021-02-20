using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id); //Markaya göre
        List<Car> GetCarsByColorId(int id); //Markaya göre
        //List<Car> GetById(int Id);
    }
}
