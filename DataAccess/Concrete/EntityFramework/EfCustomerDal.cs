using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (var context = new RentCarContext())
            {

                //join customer in contex.Customers on rental.CustomerId equals customer.id
                //join user in contex.Users on customer.UserId equals user.Id
                var result = from customer in context.Customers
                             join user in context.Users on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 id = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 CustomerName = user.FirstName + " " + user.LastName
                             };
                return result.ToList();

            }
        }
    }
}
