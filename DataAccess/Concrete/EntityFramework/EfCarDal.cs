using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //using bitince GarbegeCollector tarafından silinir
            //IDisposable pattenr implementation of C#
            using (RentCarContext context = new RentCarContext())
            {
                var addedEntity = context.Entry(entity); //veri kaynağı ile ilişkilendirmek
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedEntry = context.Entry(entity); //veri kaynağı ile ilişkilendirmek
                deletedEntry.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
                return filter == null 
                    ? context.Set<Car>().ToList() 
                    : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var updatedEntry = context.Entry(entity); //veri kaynağı ile ilişkilendirmek
                updatedEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
