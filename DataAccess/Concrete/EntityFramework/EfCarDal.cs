using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {

        public CarDetailDto GetCarDetailById(Expression<Func<Car, bool>> filter = null)
        {
            {
                using (RentCarContext context = new RentCarContext())
                {
                    var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                                 join b in context.Brands
                                        on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                        on c.ColorId equals co.ColorId
                                 select new CarDetailDto()
                                 {
                                     BrandName = b.BrandName,
                                     BrandId = b.BrandId,
                                     ColorId = co.ColorId,
                                     CarName = c.CarName,
                                     ColorName = co.ColorName,
                                     DailyPrice = c.DailyPrice,
                                     CarId = c.CarId,
                                     ModelYear = c.ModelYear,
                                     Description = c.Description,
                                     ImagePath = @"\images\default_img.png",
                                     CarImage = new List<CarImage>()
                                 };
                    return result.FirstOrDefault();
                };
            }

        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                                    on c.BrandId equals b.BrandId
                             join co in context.Colors
                                    on c.ColorId equals co.ColorId
                             select new CarDetailDto()
                             {
                                 BrandName = b.BrandName,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 CarName = c.CarName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.CarId,
                                 ModelYear = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();
            };
        }
    }
}

