using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {

        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetImageById(int id);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);
        IResult Add(CarImage carImage, IFormFile files);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
