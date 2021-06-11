using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId

                             join color in context.Colors
                             on c.ColorId equals color.ColorId

                             join user in context.Users
                             on customer.UserId equals user.UserId

                             select new RentalDetailDto
                             {
                                 Id = r.RentalId,
                                 CustomerName = user.FirstName + " " + user.LastName,
                                 BrandName = b.BrandName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 TotalPrice = Convert.ToDecimal(r.ReturnDate.Value.Day - r.RentDate.Day) * c.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
