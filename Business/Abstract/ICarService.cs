using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByColorId(int ColorId);
        IDataResult<List<Car>> GetCarsByBrandId(int BrandId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsByBrandid(int Brandid);
        IDataResult<List<CarDetailDto>> GetCarsByColorid(int Colorid);
        IDataResult<List<CarDetailDto>> GetCarDetailById(int CarId);

        IDataResult<List<CarDetailDto>> GetFilterCar(int BrandId, int ColorId);
    }
}
