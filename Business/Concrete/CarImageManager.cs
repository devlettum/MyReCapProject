using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run
                (
                CheckIfCarImageLimitExceeded(carImage.CarId));

            if (result!=null)
            {
                return result;
            }
            CarImage newCarImage = CreatedFile(file, carImage);
            _carImageDal.Add(newCarImage);

            return new SuccessResult();
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfCarImageIdIsNotExists(carImage.Id),
                CheckIfCarImageLimitExceeded(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            var newImage = UpdatedFile(file, carImage);
            _carImageDal.Update(newImage);

            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {

            IResult result = BusinessRules.Run(
                CheckIfCarImageIdIsNotExists(carImage.Id)
                );

            if (result != null)
            {
                return result;
            }

            DeletedFile(carImage);
            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetImageById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }



        private CarImage CreatedFile(IFormFile file, CarImage carImage)
        {
            var newImagePath = FileHelper.CreateFile(file).Data;
            var time = DateTime.Now;

            return new CarImage
            {
                CarId = carImage.CarId,
                Date = time,
                ImagePath = newImagePath
            };
        }
        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private IResult CheckIfCarImageIdIsNotExists(int carImageId)
        {
            var result = _carImageDal.Get(c => c.Id == carImageId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarImageIsNotExists);
            }

            return new SuccessResult();
        }
        private CarImage UpdatedFile(IFormFile file, CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);
            var newImagePath = FileHelper.UpdateFile(file, image.ImagePath).Data;
            var time = DateTime.Now;

            image.CarId = carImage.CarId;
            image.Date = time;
            image.ImagePath = newImagePath;


            return image;
        }
        private void DeletedFile(CarImage carImage)
        {
            var image = _carImageDal.Get(c => c.Id == carImage.Id);

            FileHelper.DeleteFile(image.ImagePath);
        }
    }
}
